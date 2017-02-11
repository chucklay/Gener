#include "main.h"
#include "ui_main.h"
#include <fstream>
#include <iostream>
#include <QApplication>
#include <QStringList>

using namespace std;

Main::Main(QWidget *parent) :
    QMainWindow(parent),
    ui(new Ui::Main)
{
    ui->setupUi(this);
}

Main::~Main()
{
    delete ui;
}

std::vector<QListWidgetItem> getGamelist();

int main(int argc, char**argv)
{
    /**
     * @brief Main program loop
     * @return Exit code
     */
    QApplication app(argc, argv);
    QMainWindow *widget = new QMainWindow;
    Ui::Main ui;
    ui.setupUi(widget);

    std::vector<QListWidgetItem> gameList = getGamelist();
    ui.gameListWidget->setViewMode(QListView::ListMode);
    for (int i=0; i<gameList.size(); i++){
        ui.gameListWidget->addItem(&(gameList.at(i)));
    }

    widget->show();
    return app.exec();
}

std::vector<QListWidgetItem> getGamelist()
{
    std::vector<QListWidgetItem> gameList;
    fstream gameListFile;
    gameListFile.open("games.bin", ios::binary);
    if(gameListFile.good()){
        // Game list exists. Read it in.
        QListWidgetItem itm;
        while(gameListFile.read(reinterpret_cast<char*>(&itm), sizeof(itm)))
        {
            gameList.push_back(itm);
        }
    }
    return gameList;
}

