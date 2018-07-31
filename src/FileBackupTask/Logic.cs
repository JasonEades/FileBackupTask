using System;
using System.IO;

namespace GenericFileBackupTask
{
    /// <summary>
    /// The file backup task.
    /// </summary>
    public class FileBackup
    {
        #region Creation  	---------------------------------------------------------------

        /// <summary>
        /// Handles backing up a file.
        /// </summary>
        /// <param name="sourceFile">Source file to backup.</param>
        /// <param name="backupLocation">Location to backup</param>
        public FileBackup(string sourceFile, string backupLocation)
        {
            if (string.IsNullOrWhiteSpace(sourceFile))
                throw new ArgumentException("Source File is a required value.", nameof(sourceFile));

            if (!File.Exists(sourceFile))
                throw new ArgumentException($"Source File does not exist: { sourceFile } or is not a file.", nameof(sourceFile));

            if (string.IsNullOrWhiteSpace(backupLocation))
                throw new ArgumentException("Backup location is a required value.", nameof(backupLocation));

            if (!Directory.Exists(backupLocation))
                throw new ArgumentException($"Backup location does not exist: { backupLocation } or is not a valid directory.", nameof(backupLocation));

            this.SourceFile = sourceFile;
            this.BackupFolder = backupLocation;
        }

        #endregion // Creation	---------------------------------------------------------------

        #region Properties ---------------------------------------------------------------
        
        /// <summary>
        /// The source file to make a backup of.
        /// </summary>
        private string SourceFile { get; set; }

        /// <summary>
        /// The folder where the backup should be saved.
        /// </summary>
        private string BackupFolder { get; set; }

        #endregion // Properties	---------------------------------------------------------------

        #region Public Methods	---------------------------------------------------------------

        /// <summary>
        /// Backs up a given source file to a backup folder with timestamp prefix and _Backup suffix.
        /// </summary>
        public void Backup()
        {
            string currentFileName = Path.GetFileNameWithoutExtension(SourceFile);
            string currentFileExtension = Path.GetExtension(SourceFile);
            string dateStamp = DateTime.Now.ToString("yyyyMMddHHmmss");
            string backupFileName = string.Format("{0}{1}_Backup{2}", dateStamp, currentFileName, currentFileExtension);
            string backupFileFull = Path.Combine(BackupFolder, backupFileName);
            File.Copy(SourceFile, backupFileFull, false);
        }

        #endregion // Public Methods	---------------------------------------------------------------

    }
}
