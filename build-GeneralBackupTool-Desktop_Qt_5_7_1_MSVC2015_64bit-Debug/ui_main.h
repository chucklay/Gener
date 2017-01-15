/********************************************************************************
** Form generated from reading UI file 'main.ui'
**
** Created by: Qt User Interface Compiler version 5.7.1
**
** WARNING! All changes made in this file will be lost when recompiling UI file!
********************************************************************************/

#ifndef UI_MAIN_H
#define UI_MAIN_H

#include <QtCore/QVariant>
#include <QtWidgets/QAction>
#include <QtWidgets/QApplication>
#include <QtWidgets/QButtonGroup>
#include <QtWidgets/QHBoxLayout>
#include <QtWidgets/QHeaderView>
#include <QtWidgets/QLabel>
#include <QtWidgets/QLineEdit>
#include <QtWidgets/QMainWindow>
#include <QtWidgets/QMenu>
#include <QtWidgets/QMenuBar>
#include <QtWidgets/QScrollArea>
#include <QtWidgets/QVBoxLayout>
#include <QtWidgets/QWidget>

QT_BEGIN_NAMESPACE

class Ui_Main
{
public:
    QAction *actionExit;
    QWidget *centralWidget;
    QHBoxLayout *horizontalLayout_2;
    QScrollArea *gameList;
    QWidget *scrollAreaWidgetContents;
    QVBoxLayout *gameFormLayout;
    QLabel *gameNameLabel;
    QLineEdit *lineEdit;
    QLabel *gameProcessLabel;
    QMenuBar *menuBar;
    QMenu *menuFile;

    void setupUi(QMainWindow *Main)
    {
        if (Main->objectName().isEmpty())
            Main->setObjectName(QStringLiteral("Main"));
        Main->resize(710, 448);
        actionExit = new QAction(Main);
        actionExit->setObjectName(QStringLiteral("actionExit"));
        centralWidget = new QWidget(Main);
        centralWidget->setObjectName(QStringLiteral("centralWidget"));
        horizontalLayout_2 = new QHBoxLayout(centralWidget);
        horizontalLayout_2->setSpacing(6);
        horizontalLayout_2->setContentsMargins(11, 11, 11, 11);
        horizontalLayout_2->setObjectName(QStringLiteral("horizontalLayout_2"));
        gameList = new QScrollArea(centralWidget);
        gameList->setObjectName(QStringLiteral("gameList"));
        QSizePolicy sizePolicy(QSizePolicy::Fixed, QSizePolicy::Expanding);
        sizePolicy.setHorizontalStretch(0);
        sizePolicy.setVerticalStretch(0);
        sizePolicy.setHeightForWidth(gameList->sizePolicy().hasHeightForWidth());
        gameList->setSizePolicy(sizePolicy);
        gameList->setMinimumSize(QSize(250, 0));
        gameList->setWidgetResizable(true);
        scrollAreaWidgetContents = new QWidget();
        scrollAreaWidgetContents->setObjectName(QStringLiteral("scrollAreaWidgetContents"));
        scrollAreaWidgetContents->setGeometry(QRect(0, 0, 248, 408));
        gameList->setWidget(scrollAreaWidgetContents);

        horizontalLayout_2->addWidget(gameList);

        gameFormLayout = new QVBoxLayout();
        gameFormLayout->setSpacing(6);
        gameFormLayout->setObjectName(QStringLiteral("gameFormLayout"));
        gameFormLayout->setSizeConstraint(QLayout::SetDefaultConstraint);
        gameNameLabel = new QLabel(centralWidget);
        gameNameLabel->setObjectName(QStringLiteral("gameNameLabel"));
        QSizePolicy sizePolicy1(QSizePolicy::Preferred, QSizePolicy::Fixed);
        sizePolicy1.setHorizontalStretch(0);
        sizePolicy1.setVerticalStretch(0);
        sizePolicy1.setHeightForWidth(gameNameLabel->sizePolicy().hasHeightForWidth());
        gameNameLabel->setSizePolicy(sizePolicy1);

        gameFormLayout->addWidget(gameNameLabel);

        lineEdit = new QLineEdit(centralWidget);
        lineEdit->setObjectName(QStringLiteral("lineEdit"));

        gameFormLayout->addWidget(lineEdit);

        gameProcessLabel = new QLabel(centralWidget);
        gameProcessLabel->setObjectName(QStringLiteral("gameProcessLabel"));
        sizePolicy1.setHeightForWidth(gameProcessLabel->sizePolicy().hasHeightForWidth());
        gameProcessLabel->setSizePolicy(sizePolicy1);

        gameFormLayout->addWidget(gameProcessLabel);


        horizontalLayout_2->addLayout(gameFormLayout);

        Main->setCentralWidget(centralWidget);
        menuBar = new QMenuBar(Main);
        menuBar->setObjectName(QStringLiteral("menuBar"));
        menuBar->setGeometry(QRect(0, 0, 710, 20));
        menuFile = new QMenu(menuBar);
        menuFile->setObjectName(QStringLiteral("menuFile"));
        Main->setMenuBar(menuBar);

        menuBar->addAction(menuFile->menuAction());
        menuFile->addAction(actionExit);

        retranslateUi(Main);

        QMetaObject::connectSlotsByName(Main);
    } // setupUi

    void retranslateUi(QMainWindow *Main)
    {
        Main->setWindowTitle(QApplication::translate("Main", "Main", Q_NULLPTR));
        actionExit->setText(QApplication::translate("Main", "Exit", Q_NULLPTR));
        gameNameLabel->setText(QApplication::translate("Main", "Game Name", Q_NULLPTR));
        gameProcessLabel->setText(QApplication::translate("Main", "Game Process Name", Q_NULLPTR));
        menuFile->setTitle(QApplication::translate("Main", "File", Q_NULLPTR));
    } // retranslateUi

};

namespace Ui {
    class Main: public Ui_Main {};
} // namespace Ui

QT_END_NAMESPACE

#endif // UI_MAIN_H
