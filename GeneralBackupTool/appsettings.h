#ifndef APPSETTINGS_H
#define APPSETTINGS_H

#include <QDialog>

#define SETTINGS_PATH "settings.bin"

namespace Ui {
class AppSettings;
}

class AppSettings : public QDialog
{
    Q_OBJECT

public:
    explicit AppSettings(QWidget *parent = 0);
    ~AppSettings();

private slots:
    void on_backup_path_browse_button_clicked();

    void on_buttonBox_accepted();

    void on_buttonBox_rejected();

private:
    Ui::AppSettings *ui;
};

#endif // APPSETTINGS_H
