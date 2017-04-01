#include <fstream>
#include "game.h"
#include <fstream>
#include <iostream>
#include "mainwindow.h"
#include <QApplication>
#include <QIcon>
#include <QListWidget>
#include <QListWidgetItem>
#include <QString>
#include "settings.h"
#include <string>
#include <sys/stat.h>

#define DATA_PATH  "data.bin"
#define SETTINGS_PATH "settings.bin"

using namespace std;


std::vector<Game*> game_list;
Settings *program_settings;

int main(int argc, char *argv[])
{
    QApplication a(argc, argv);
    MainWindow w;
    w.show();

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
        Game *default_game = new Game;
        game_list = {default_game};
    }

    QListWidget *game_list_view = w.get_games_list_view();

    for(unsigned int i = 0; i < game_list.size(); i++){
        QListWidgetItem *item;
        if(game_list.at(i)->icon_path != ""){
            item = new QListWidgetItem(QIcon(":/questionmark.png"), QString::fromStdString(game_list.at(i)->name), game_list_view);
        } else {
            item = new QListWidgetItem(QIcon(QString::fromStdString(game_list.at(i)->icon_path)), QString::fromStdString(game_list.at(i)->name), game_list_view);
        }
    }
    return a.exec();
}
