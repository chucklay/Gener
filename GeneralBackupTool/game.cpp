#include "game.h"

Game::Game(){
    // Public constructor
    this->show = true;
    this->override = false;
    this->name = "Game Name";
    this->save_path = "Save Directory";
    this->interval = 5.0;
    this->override_path = "";
    this->profiles = {"Default"};
    this->process_name = "Select Game Process";
    this->icon_path = "";
    this->active_profile = 0;
}
