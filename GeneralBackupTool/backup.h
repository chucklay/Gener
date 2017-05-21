#ifndef BACKUP_H
#define BACKUP_H
#include "game.h"

string remove_invalid(string path);
void restore_game(Game *game);
void backup_game(Game *game);
void backup_loop();
void test_thread();

#endif // BACKUP_H
