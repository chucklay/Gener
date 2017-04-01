#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#include <QMainWindow>
#include "appsettings.h"
#include <QListWidget>

class Game;
extern std::vector<Game *> games_list;

namespace Ui {
class MainWindow;
}

class MainWindow : public QMainWindow
{
    Q_OBJECT

public:
    explicit MainWindow(QWidget *parent = 0);
    ~MainWindow();
    QListWidget *get_games_list_view();

private slots:
    void on_actionSettings_triggered();

    void on_actionExit_triggered();

    void on_games_list_currentRowChanged(int currentRow);

private:
    Ui::MainWindow *ui;
    AppSettings *appsettings;
};

#endif // MAINWINDOW_H
