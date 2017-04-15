#include "backup.h"
#include "settings.h"
#include <boost/thread.hpp>
#include <boost/thread/scoped_thread.hpp>
#include <boost/chrono.hpp>
#include <boost/filesystem.hpp>
#include <boost/lexical_cast.hpp>
#include <QStringList>
#include <stdio.h>
#include <windows.h>
#include <tchar.h>
#include <psapi.h>


using namespace std;

extern Settings *program_settings;
extern std::vector<Game *> game_list;

void backup_game(Game *game){
    if(game->backups_enabled){
        if(boost::filesystem::is_directory(game->save_path)){
            if(game->override && boost::filesystem::is_directory(game->override_path)){

            } else {
                boost::filesystem::path dest_path(program_settings->default_backup_path);
                dest_path = operator /(dest_path, game->name);
                dest_path = operator /(dest_path, game->profiles.at(game->active_profile));
                dest_path = operator /(dest_path, boost::lexical_cast<std::string>(game->active_slot));

                if(!boost::filesystem::is_directory(dest_path)){
                    boost::filesystem::create_directories(dest_path);
                }

                boost::filesystem::copy_directory(game->save_path, dest_path);
            }
        }
    }
}

void backup_loop(){
    while(true){
        // Get the list of processes. Using QStringList so I can reuse code
        // because I'm lazy.
        QList<QString> pNameList;
        DWORD aProcesses[1024], cbNeeded, cProcesses;
        unsigned int i;
        if( EnumProcesses( aProcesses, sizeof(aProcesses), &cbNeeded)) {
            cProcesses = cbNeeded / sizeof(DWORD);
            for (i = 0; i < cProcesses; i++) {
                if(aProcesses[i] != 0) {
                    TCHAR szProcessName[MAX_PATH] = TEXT("<unknown>");

                    HANDLE hProcess = OpenProcess(PROCESS_QUERY_INFORMATION |
                                                  PROCESS_VM_READ,
                                                  FALSE, aProcesses[i]);

                    if(NULL != hProcess) {
                        HMODULE hMod;
                        DWORD cbNeeded;

                        if(EnumProcessModules(hProcess, &hMod, sizeof(hMod), &cbNeeded)) {
                            GetModuleBaseName(hProcess, hMod, szProcessName, sizeof(szProcessName)/sizeof(TCHAR));
                        }
                    }

                    QString pname;

                    #ifdef UNICODE
                    pname = QString::fromStdWString(szProcessName);
                    #else
                    pname = QString::fromStdString(szProcessName);
                    #endif
                    if(pname != "<unknown>" && !pNameList.contains(pname)) {
                        pNameList.append(pname);
                    }
                    CloseHandle(hProcess);
                }
            }
        }
        boost::this_thread::sleep_for(boost::chrono::minutes{5});
        for(auto i = 0; i < game_list.size(); i++){
            Game *current_game = game_list.at(i);
            if(pNameList.contains(QString::fromStdString(current_game->name))){
                backup_game(current_game);
            }
        }
    }
}

void test_thread(){
    while(true){
        cout << "In thread test loop...\n";
        boost::this_thread::sleep_for(boost::chrono::seconds(15));
    }
}
