#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#include <QMainWindow>
#include "appsettings.h"
#include "about.h"
#include "settings.h"
#include "game.h"
#include "backup.h"
#include <QListWidget>
#include <windows.h>
#include <QCloseEvent>
#include <QSystemTrayIcon>
#include <QMenu>

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

    void on_add_profile_button_clicked();

    void on_remove_profile_button_clicked();

    void on_process_refresh_button_clicked();

    void closeEvent(QCloseEvent *event);

    void realExit();

    void restoreFromTray();

    void on_actionAbout_triggered();

private:
    Ui::MainWindow *ui;
    AppSettings *appsettings;
    about *abt;
    void setGame(Game *game);
    QSystemTrayIcon sys_tray_icon;
    QMenu sys_tray_menu;
};

#endif // MAINWINDOW_H
