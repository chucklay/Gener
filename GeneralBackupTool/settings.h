#ifndef SETTINGS_H
#define SETTINGS_H
#include <string>
#include <boost/archive/text_iarchive.hpp>
#include <boost/archive/text_oarchive.hpp>
#include <boost/serialization/access.hpp>

using namespace std;

class Settings {
    private:
        friend class boost::serialization::access;
        template <class Archive>
        void serialize(Archive & ar, const unsigned int version){
            ar & default_backup_path;
            ar & enabled;
        }

    public:
        Settings();
        string default_backup_path;
        bool enabled;
};

Settings::Settings(void) {
    this->enabled = false;
    this->default_backup_path = "";
}

#endif // SETTINGS_H
