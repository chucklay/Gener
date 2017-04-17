#include "backup.h"
#include "settings.h"
#include <boost/thread.hpp>
#include <boost/thread/scoped_thread.hpp>
#include <boost/chrono.hpp>
#include <boost/filesystem.hpp>
#include <boost/lexical_cast.hpp>
#include <boost/archive/text_oarchive.hpp>
#include <QStringList>
#include <stdio.h>
#include <windows.h>
#include <tchar.h>
#include <psapi.h>
#include <Windows.h>
#include <Shlwapi.h>
#pragma comment(lib, "Shlwapi.lib")

using namespace std;

extern Settings *program_settings;
extern std::vector<Game *> game_list;

namespace fs = boost::filesystem;

void backup_game(Game *game){
    if(game->backups_enabled){
        if(boost::filesystem::is_directory(game->save_path)){
            if(game->override && boost::filesystem::is_directory(game->override_path)){

            } else {
                boost::filesystem::path dest_path(program_settings->default_backup_path);

                dest_path.append(game->name);
                dest_path.append(game->profiles.at(game->active_profile));
                dest_path.append(boost::lexical_cast<std::string>(game->active_slot));

                if(!boost::filesystem::is_directory(dest_path)){
                    boost::filesystem::create_directories(dest_path);
                }

                for(fs::directory_iterator file(game->save_path); file != fs::directory_iterator(); ++file){
                    fs::path current(file->path());
                    if(!fs::is_directory(current)){
                        fs::copy_file(current, dest_path/current.filename(), fs::copy_option::overwrite_if_exists);
                    }
                }
                game->active_slot++;
                if(game->active_slot > game->save_slots){
                    game->active_slot = 1;
                }
                std::ofstream ofs(DATA_PATH);
                boost::archive::text_oarchive oa(ofs);
                oa & game_list;
            }
        }
    }
}

void backup_loop(){
    cout << "backup loop running.\n";
    while(true){
        // Get the list of processes. Using QStringList so I can reuse code
        // because I'm lazy.
        bool found = false;
        QList<QString> pNameList;
        HWND hwnd_current = GetWindow(GetDesktopWindow(), GW_CHILD);
        QStringList process_list;
        do {
            wchar_t str_window_name[MAX_PATH];
            DWORD pid;
            DWORD exStyles = (DWORD)GetWindowLongPtr(hwnd_current, GWL_EXSTYLE);
            DWORD styles = (DWORD)GetWindowLongPtr(hwnd_current, GWL_STYLE);

            if(!((exStyles & WS_EX_TOOLWINDOW) == 0 && (styles & WS_CHILD) == 0)){
                continue;
            }
            if(!GetWindowText(hwnd_current, str_window_name, MAX_PATH)){
                continue;
            }
            GetWindowThreadProcessId(hwnd_current, &pid);
            if(pid == GetCurrentProcessId()){
                continue;
            }

            wchar_t fileName[MAX_PATH];
            LPWSTR file_name;
            HANDLE hProcess;
            hProcess = OpenProcess(PROCESS_QUERY_LIMITED_INFORMATION | PROCESS_VM_READ | PROCESS_VM_WRITE, FALSE, pid);
            if(hProcess){
                DWORD dwSize = MAX_PATH;
                QueryFullProcessImageName(hProcess, 0, fileName, &dwSize);
                file_name = PathFindFileName(fileName);
            }
            CloseHandle(hProcess);
            QString boxString = QString("[");
            #ifdef UNICODE
            QString q_file_name = QString::fromStdWString(file_name);
            QString q_str_window_name = QString::fromStdWString(str_window_name);
            #else
            QString q_file_name = QString::fromStdString(file_name);
            QString q_str_window_name = QString::fromStdString(str_window_name);
            #endif
            boxString.append(q_file_name);
            boxString.append("] ");
            boxString.append(q_str_window_name);

            if(!q_file_name.isEmpty() && !q_str_window_name.isEmpty() && !pNameList.contains(boxString) && !process_list.contains(q_file_name)){
                if(!q_str_window_name.endsWith("MSCTFIME UI") && !q_str_window_name.endsWith("Default IME")){
                    pNameList.append(q_file_name);
                }
            }

        } while (hwnd_current = GetNextWindow(hwnd_current, GW_HWNDNEXT));
        for(auto i = 0; i < game_list.size(); i++){
            Game *current_game = game_list.at(i);
            string process = current_game->process_name.substr(current_game->process_name.find_first_of('[')+1, current_game->process_name.find_last_of(']')-1);
            cout << process;
            if(pNameList.contains(QString::fromStdString(process))){
                backup_game(current_game);
                found = true;
                boost::this_thread::sleep_for(boost::chrono::minutes(current_game->interval));
            }
        }
        if(!found){
            boost::this_thread::sleep_for(boost::chrono::minutes{5});
        }
    }
}

void test_thread(){
    while(true){
        cout << "In thread test loop...\n";
        boost::this_thread::sleep_for(boost::chrono::seconds(15));
    }
}
