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
            if(version > 0){
                ar & default_backup_path;
                ar & enabled;
                ar & minimize_taskbar;
            }
        }

    public:
        Settings();
        string default_backup_path;
        bool enabled;
        bool minimize_taskbar;
};

BOOST_CLASS_VERSION(Settings, 1);

#endif // SETTINGS_H
