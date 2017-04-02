#include "mainwindow.h"
#include "ui_mainwindow.h"
#include <QStringListModel>
#include <stdio.h>
#include <windows.h>
#include <tchar.h>
#include <psapi.h>
#include <iostream>
#include <fstream>
#include <QFileDialog>
#include <boost/serialization/vector.hpp>

#ifndef UNICODE
    typedef std::string String;
#else
    typedef std::wstring String;
#endif

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
    if(currentRow < game_list.size()){
        /* Set the selected game as current. */
        Game *current_game = game_list.at(currentRow);
        // TODO Put the values here in their appropreate places.
        setGame(current_game);
    }
}

void MainWindow::on_add_game_button_clicked()
{
    // Add a new game to the game list. These are transient until the save button is clicked.
    game_list.push_back(new Game);

    // Refresh the UI Game list.
    QListWidgetItem *item = new QListWidgetItem;
    item->setIcon(QIcon(":/questionmark.png"));
    item->setText("Game Name");
    ui->games_list->addItem(item);
}

void MainWindow::setGame(Game *game) {
    QList<QString> pNameList;

    // Get list of running processes.
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
                if(pname != "<unknown>") {
                    pNameList.append(pname);
                }
                CloseHandle(hProcess);
            }
        }
    }

    ui->game_name->setText(QString::fromStdString(game->name));
    ui->process_name_box->setModel(new QStringListModel(pNameList));
    ui->process_name_box->setCurrentText(QString::fromStdString(game->process_name));
    ui->save_path_text->setText(QString::fromStdString(game->save_path));
    ui->save_interval_spinner->setValue(game->interval);
    ui->backup_override_enabled->setChecked(game->override);
    ui->backup_override_path->setText(QString::fromStdString(game->override_path));
    QStringList *strlist = new QStringList();
    for(unsigned int i = 0; i < game->profiles.size(); i++){
        strlist->append(QString::fromStdString(game->profiles.at(i)));
    }
    ui->profile_select_box->setModel(new QStringListModel(*strlist));
    ui->profile_select_box->setCurrentIndex(game->active_profile);
    if(game->icon_path != "") {
        ui->icon_select_button->setIcon(QIcon(QString::fromStdString(game->icon_path)));
        ui->icon_path_text->setText(QString::fromStdString(game->icon_path));
    } else {
        ui->icon_select_button->setIcon(QIcon(":/questionmark.png"));
        ui->icon_path_text->setText(QString(""));
    }
}

void MainWindow::on_backup_override_enabled_clicked()
{
    bool enableState = ui->backup_override_enabled->isChecked();
    ui->backup_override_browse_button->setEnabled(enableState);
    ui->backup_override_path->setEnabled(enableState);
}

void MainWindow::on_remove_game_button_clicked()
{
    if(game_list.size() > 1) {
        if(ui->games_list->currentRow() < game_list.size()){
            int selected_game = ui->games_list->currentRow();
            game_list.erase(game_list.begin() + selected_game);
            qDeleteAll(ui->games_list->selectedItems());

            std::ofstream ofs("data.bin");
            boost::archive::text_oarchive oa(ofs);
            oa & game_list;

            MainWindow::on_games_list_currentRowChanged(ui->games_list->currentRow());
        }
    }
}

void MainWindow::on_pushButton_clicked()
{
    QString dir = QFileDialog::getExistingDirectory(this, tr("Save Directory"), "/", QFileDialog::ShowDirsOnly | QFileDialog::DontResolveSymlinks);
    if(dir != ""){
        ui->save_path_text->setText(dir);
    }
}

void MainWindow::on_backup_override_browse_button_clicked()
{
    QString dir = QFileDialog::getExistingDirectory(this, tr("Save Directory"), "/", QFileDialog::ShowDirsOnly | QFileDialog::DontResolveSymlinks);
    if(dir != ""){
        ui->backup_override_path->setText(dir);
    }
}

void MainWindow::on_icon_select_button_clicked()
{
    QString imgDir = QFileDialog::getOpenFileName(this, tr("Icon"), "/", tr("Images (*.png *.xpm *.jpg)"));
    if(imgDir != ""){
        ui->icon_select_button->setIcon(QIcon(imgDir));
        ui->icon_path_text->setText(imgDir);
    }
}

void MainWindow::on_cancel_button_clicked()
{
    int currentRow = ui->games_list->currentRow();
    if(currentRow < game_list.size()){
        /* Set the selected game as current. */
        Game *current_game = game_list.at(currentRow);
        setGame(current_game);
    }
}

void MainWindow::on_save_button_clicked()
{
    int current_row = ui->games_list->currentRow();
    if(current_row < game_list.size()) {
        Game *current_game = game_list.at(current_row);
        current_game->show = true;
        current_game->override = ui->backup_override_enabled->isChecked();
        current_game->name = ui->game_name->text().toStdString();
        current_game->save_path = ui->save_path_text->text().toStdString();
        current_game->interval = ui->save_interval_spinner->value();
        current_game->override_path = ui->backup_override_path->text().toStdString();
        std::vector<string> profiles;
        for(auto i = 0; i < ui->profile_select_box->count(); i++) {
            profiles.push_back(ui->profile_select_box->itemText(i).toStdString());
        }
        current_game->profiles = profiles;
        current_game->active_profile = ui->profile_select_box->currentIndex();\
        current_game->process_name = ui->process_name_box->currentText().toStdString();
        current_game->icon_path = ui->icon_path_text->text().toStdString();

        ui->games_list->item(current_row)->setText(QString::fromStdString(current_game->name));
        ui->games_list->item(current_row)->setIcon(QIcon(QString::fromStdString(current_game->icon_path)));

        std::ofstream ofs("data.bin");
        boost::archive::text_oarchive oa(ofs);
        oa & game_list;
    }
}
