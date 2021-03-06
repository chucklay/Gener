#-------------------------------------------------
#
# Project created by QtCreator 2017-03-26T13:29:38
#
#-------------------------------------------------

QT       += core gui

greaterThan(QT_MAJOR_VERSION, 4): QT += widgets

TARGET = GeneralBackupTool
TEMPLATE = app

# The following define makes your compiler emit warnings if you use
# any feature of Qt which as been marked as deprecated (the exact warnings
# depend on your compiler). Please consult the documentation of the
# deprecated API in order to know how to port your code away from it.
DEFINES += QT_DEPRECATED_WARNINGS

# You can also make your code fail to compile if you use deprecated APIs.
# In order to do so, uncomment the following line.
# You can also select to disable deprecated APIs only up to a certain version of Qt.
#DEFINES += QT_DISABLE_DEPRECATED_BEFORE=0x060000    # disables all the APIs deprecated before Qt 6.0.0


SOURCES += main.cpp\
        mainwindow.cpp \
    appsettings.cpp \
    game.cpp \
    settings.cpp \
    backup.cpp \
    about.cpp

HEADERS  += mainwindow.h \
    appsettings.h \
    game.h \
    settings.h \
    backup.h \
    about.h

FORMS    += mainwindow.ui \
    appsettings.ui \
    about.ui

win32:LIBS += -luser32
win32:LIBS += -lpsapi
win32:LIBS += -lkernel32


RESOURCES += \
    images.qrc

win32:CONFIG(release, debug|release): LIBS += -L'F:/Program Files/Boost/stage/lib/' -lboost_chrono-vc140-mt-1_63
else:win32:CONFIG(debug, debug|release): LIBS += -L'F:/Program Files/Boost/stage/lib/' -lboost_chrono-vc140-mt-gd-1_63

INCLUDEPATH += 'F:/Program Files/Boost'
DEPENDPATH += 'F:/Program Files/Boost'

win32:CONFIG(release, debug|release): LIBS += -L'F:/Program Files/Boost/stage/lib/' -lboost_filesystem-vc140-mt-1_63
else:win32:CONFIG(debug, debug|release): LIBS += -L'F:/Program Files/Boost/stage/lib/' -lboost_filesystem-vc140-mt-gd-1_63

INCLUDEPATH += 'F:/Program Files/Boost'
DEPENDPATH += 'F:/Program Files/Boost'

win32:CONFIG(release, debug|release): LIBS += -L'F:/Program Files/Boost/stage/lib/' -lboost_serialization-vc140-mt-1_63
else:win32:CONFIG(debug, debug|release): LIBS += -L'F:/Program Files/Boost/stage/lib/' -lboost_serialization-vc140-mt-gd-1_63

INCLUDEPATH += 'F:/Program Files/Boost'
DEPENDPATH += 'F:/Program Files/Boost'

win32:CONFIG(release, debug|release): LIBS += -L'F:/Program Files/Boost/stage/lib/' -lboost_system-vc140-mt-1_63
else:win32:CONFIG(debug, debug|release): LIBS += -L'F:/Program Files/Boost/stage/lib/' -lboost_system-vc140-mt-gd-1_63

INCLUDEPATH += 'F:/Program Files/Boost'
DEPENDPATH += 'F:/Program Files/Boost'

win32:CONFIG(release, debug|release): LIBS += -L'F:/Program Files/Boost/stage/lib/' -llibboost_thread-vc140-mt-1_63
else:win32:CONFIG(debug, debug|release): LIBS += -L'F:/Program Files/Boost/stage/lib/' -llibboost_thread-vc140-mt-gd-1_63

INCLUDEPATH += 'F:/Program Files/Boost'
DEPENDPATH += 'F:/Program Files/Boost'
