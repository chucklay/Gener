#include <boost/filesystem.hpp>
#include <boost/thread.hpp>
#include <boost/thread/scoped_thread.hpp>
#include <boost/archive/text_iarchive.hpp>
#include <boost/archive/text_oarchive.hpp>
#include <fstream>
#include <fstream>
#include <iostream>
#include <QApplication>
#include <QIcon>
#include <QListWidget>
#include <QListWidgetItem>
#include <QString>
#include <string>
#include <sys/stat.h>
#include "mainwindow.h"
#include "settings.h"
#include "game.h"
#include "backup.h"

using namespace std;

std::vector<Game*> game_list;
Settings *program_settings;

int main(int argc, char *argv[])
{
    QApplication a(argc, argv);
    MainWindow w;
    w.show();

    if(boost::filesystem::exists(SETTINGS_PATH)) {
        // Settings exist. Read them in.
        std::ifstream ifs(SETTINGS_PATH);
        boost::archive::text_iarchive ia(ifs);
        ia >> program_settings;
    } else {
        program_settings = new Settings;
    }

    if(boost::filesystem::exists(DATA_PATH)) {
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
        QListWidgetItem *item = new QListWidgetItem;
        item->setText(QString::fromStdString(game_list.at(i)->name));
        if(game_list.at(i)->icon_path == ""){
            item->setIcon(QIcon(":/questionmark.png"));
        } else {
            item->setIcon(QIcon(QString::fromStdString(game_list.at(i)->icon_path)));
        }
        item->setSizeHint(QSize(250, 50));
        game_list_view->addItem(item);
    }
    game_list_view->setCurrentRow(0);

    if(program_settings->enabled && boost::filesystem::is_directory(program_settings->default_backup_path)){
        // Launch the process in another thread.
        boost::scoped_thread<> backup_thread{boost::thread{backup_loop}};
    }

    return a.exec();
}
