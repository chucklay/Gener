#pragma once
#ifndef GAME_H
#define GAME_H
#include <boost/archive/text_iarchive.hpp>
#include <boost/archive/text_oarchive.hpp>
#include <boost/serialization/access.hpp>
#include <boost/serialization/vector.hpp>
#include <string>
#include <vector>

#define DATA_PATH  "data.bin"

using namespace std;

class Game {
    private:
    friend class boost::serialization::access;
    template<class Archive>
    void serialize(Archive & ar, const unsigned int version){
        if(version > 2){
            ar & show;
            ar & override;
            ar & name;
            ar & save_path;
            ar & override_path;
            ar & profiles;
            ar & process_name;
            ar & icon_path;
            ar & active_profile;
            ar & backups_enabled;
            ar & save_slots;
        }
        if(version > 3){
            ar & interval;
        }
        if(version > 4){
            ar & active_slot;
        }
    }

    public:
        Game();
        bool backups_enabled;
        bool show;
        bool override;
        string name;
        string save_path;
        int interval;
        string override_path;
        std::vector<string> profiles;
        string process_name;
        string icon_path;
        int active_profile;
        int save_slots;
        std::vector<int> active_slot;
};

BOOST_CLASS_VERSION(Game, 5);

#endif // GAME_H
