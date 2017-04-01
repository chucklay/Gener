#ifndef GAME_H
#define GAME_H
#include <boost/archive/text_iarchive.hpp>
#include <boost/archive/text_oarchive.hpp>
#include <boost/serialization/access.hpp>
#include <boost/serialization/vector.hpp>
#include <string>
#include <vector>

using namespace std;

class Game {
    private:
    friend class boost::serialization::access;
    template<class Archive>
    void serialize(Archive & ar, const unsigned int version){
        ar & show;
        ar & override;
        ar & name;
        ar & save_path;
        ar & interval;
        ar & override_path;
        ar & profiles;
        ar & icon_path;
    }

    public:
        Game();
        bool show;
        bool override;
        string name;
        string save_path;
        double interval;
        string override_path;
        std::vector<string> profiles;
        string icon_path;
};

Game::Game(){
    // Public constructor
    this->show = true;
    this->override = false;
    this->name = "Game Name";
    this->save_path = "Save Directory";
    this->interval = 5.0;
    this->override_path = "";
    this->profiles = {"Default"};
    this->icon_path = "";
}

#endif // GAME_H
