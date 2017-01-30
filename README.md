# GeneralBackupTool
A generalized backup tool to backup video game save data


# Usage
This program alows you to select files or a folder to backup, as well as create profiles that can be switched between
on the fly. Programs are shown in the left-hand list, and their details can be edited on the right-hand paine.

# Under The Hood Details
Every few minutes (the exact time is user-defined), this program will check to see if any of the currently-running processes
match one of the processes that the user has marked as a game they want to back up. If a monitored game is running, the program
will copy all files or folders marked as save data to a backup folder. In the backup folder, data is seperated first by game,
and then by save profile. When save profiles are changed, non-active profile backups will be zipped in order to save space.

# More Details (And Functionality) Coming Soon!
