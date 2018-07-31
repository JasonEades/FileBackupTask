using System;
using System.Diagnostics;

namespace GenericFileBackupTask
{
    class Program
    {
        static void Main(string[] args)
        {
            string src = string.Format("{0}Source", string.IsNullOrEmpty(args[0]) ? "Generic" : args[0]);
            string log = string.Format("{0}Log", src);

            // Create the source, if it does not already exist.
            if (!EventLog.SourceExists(src))
            {
                EventLog.CreateEventSource(src, log);                
            }

            // Create an EventLog instance and assign its source.
            EventLog myLog = new EventLog();
            myLog.Source = src;

            // Write an informational entry to the event log.    
            myLog.WriteEntry($"{src} backup program started.");
            
            if (args.Length != 3)
                myLog.WriteEntry("Invalid number of arguments to start program.  Requires 3, received: " + args.Length, EventLogEntryType.Error);
            
            try
            {
                var logicInstance = new FileBackup(args[1], args[2]);
                logicInstance.Backup();
            }            
            catch (Exception ex)
            {
                myLog.WriteEntry($"Error running program logic: {ex.Message}", EventLogEntryType.Error);
                throw;
            }
        }
    }
}
