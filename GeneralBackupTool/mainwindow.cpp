#include "mainwindow.h"
#include "ui_mainwindow.h"

extern std::vector<Game*> game_list;

MainWindow::MainWindow(QWidget *parent) :
    QMainWindow(parent),
    ui(new Ui::MainWindow)
{
    ui->setupUi(this);
}

MainWindow::~MainWindow()
{
    delete ui;
}

void MainWindow::on_actionSettings_triggered()
{
    appsettings = new AppSettings();
    appsettings->show();
}

QListWidget *MainWindow::get_games_list_view()
{
    return ui->games_list;
}

void MainWindow::on_actionExit_triggered()
{
    exit(0);
}

void MainWindow::on_games_list_currentRowChanged(int currentRow)
{
    /* Set the selected game as current. */
    Game *current_game = game_list.at(currentRow);
    // TODO Put the values here in their appropreate places.
}
