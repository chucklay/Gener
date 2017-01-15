#include "main.h"
#include "ui_main.h"
#include <QApplication>

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

int main(int argc, char**argv)
{
    QApplication app(argc, argv);
    QMainWindow *widget = new QMainWindow;
    Ui::Main ui;
    ui.setupUi(widget);

    widget->show();
    return app.exec();
}
