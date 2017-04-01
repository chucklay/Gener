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
