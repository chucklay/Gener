#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#include <QMainWindow>
#include "appsettings.h"
#include "game.h"
#include <QListWidget>

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

    void on_add_game_button_clicked();

    void on_backup_override_enabled_clicked();

    void on_remove_game_button_clicked();

    void on_pushButton_clicked();

    void on_backup_override_browse_button_clicked();

    void on_icon_select_button_clicked();

    void on_cancel_button_clicked();

    void on_save_button_clicked();

private:
    Ui::MainWindow *ui;
    AppSettings *appsettings;
    void setGame(Game *game);
};

#endif // MAINWINDOW_H
