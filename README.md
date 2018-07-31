# FileBackupTask
Simple console app to backup files.  I use this to backup keypass files, local save data files, game saves, bookmarks, etc.

# Usage
This can be called via batch, PowerShell, Task Scheduler and any thing that can call an exe and pass args.

## Task Scheduler
* Create a scheduled task

![Task Scheduler](/doc/img/scheduledTask.png)
* Create action to start this program
* Add arguments to this action
  * arg[0] = Event log source name
  * arg[1] = File to backup
  * arg[2] = Directory to backup file to

*"KeyPassBackup" "C:\KeePassFiles\pw_db.kdbx" "D:\\_KeyPassFilesBackup"*

# Future
Would be nice to add other tasks such as Dropbox/OneDrive backup options.
