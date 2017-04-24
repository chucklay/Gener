#include <QFileDialog>
#include <boost/archive/text_oarchive.hpp>
#include <boost/filesystem.hpp>
#include <boost/thread.hpp>
#include <boost/thread/scoped_thread.hpp>
#include <fstream>
#include "appsettings.h"
#include "ui_appsettings.h"
#include "settings.h"
#include "backup.h"

using namespace std;

extern Settings *program_settings;
extern bool backup_process_running;
extern boost::thread backup_thread;

AppSettings::AppSettings(QWidget *parent) :
    QDialog(parent),
    ui(new Ui::AppSettings)
{
    ui->setupUi(this);
    ui->backup_path_text->setText(QString::fromStdString(program_settings->default_backup_path));
    ui->backups_enabled_checkbox->setChecked(program_settings->enabled);
    ui->minimize_taskbar_checkbox->setChecked(program_settings->minimize_taskbar);
}

AppSettings::~AppSettings()
{
    delete ui;
}

void AppSettings::on_backup_path_browse_button_clicked()
{
    QString dir = QFileDialog::getExistingDirectory(this, tr("Save Directory"), "/", QFileDialog::ShowDirsOnly | QFileDialog::DontResolveSymlinks);
    if(dir != ""){
        ui->backup_path_text->setText(dir);
    }
}

void AppSettings::on_buttonBox_accepted()
{
    program_settings->default_backup_path = ui->backup_path_text->text().toStdString();
    program_settings->enabled = ui->backups_enabled_checkbox->isChecked();
    program_settings->minimize_taskbar = ui->minimize_taskbar_checkbox->isChecked();

    std::ofstream ofs(SETTINGS_PATH);
    boost::archive::text_oarchive oa(ofs);
    oa & program_settings;

    if(ui->backups_enabled_checkbox->isChecked() && boost::filesystem::is_directory(ui->backup_path_text->text().toStdString()) && !backup_process_running){
        // Launch the process in another thread.
        backup_thread = boost::thread(backup_loop);
        backup_process_running = true;
    }

    if((!ui->backups_enabled_checkbox->isChecked() || !boost::filesystem::is_directory(ui->backup_path_text->text().toStdString())) && backup_process_running){
        // Stop the backup thread.
        backup_thread.interrupt();
        backup_process_running = false;
    }

    this->destroy();
}

void AppSettings::on_buttonBox_rejected()
{
    this->destroy();
}
