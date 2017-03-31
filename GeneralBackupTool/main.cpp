#include <fstream>
#include "game.h"
#include <fstream>
#include <iostream>
#include "mainwindow.h"
#include <QApplication>
#include "settings.h"
#include <string>
#include <sys/stat.h>

#define DATA_PATH  "data.bin"
#define SETTINGS_PATH "settings.bin"

using namespace std;

int main(int argc, char *argv[])
{
    QApplication a(argc, argv);
    MainWindow w;
    w.show();
    Game *game_list;
    Settings *program_settings;

    struct stat buffer;
    if(stat (SETTINGS_PATH, &buffer) == 0) {
        // Settings exist. Read them in.
        std::ifstream ifs(SETTINGS_PATH);
        boost::archive::text_iarchive ia(ifs);
        ia >> program_settings;
    } else {
        program_settings = new Settings;
    }

    if(stat (DATA_PATH, &buffer) == 0) {
        // There is existing data.
        std::ifstream ifs(DATA_PATH);
        boost::archive::text_iarchive ia(ifs);
        ia >> game_list;
    } else {
        // There is no data. Create a placeholder game.
        game_list = new Game[1];
    }
    return a.exec();
}
