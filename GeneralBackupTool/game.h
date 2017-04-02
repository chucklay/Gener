#pragma once
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
        ar & process_name;
        ar & icon_path;
        ar & active_profile;
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
        string process_name;
        string icon_path;
        int active_profile;
};

#endif // GAME_H
