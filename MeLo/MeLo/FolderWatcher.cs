using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MeLo
{
    class FolderWatcher
    {
        private static List<FileSystemWatcher> watchers = new List<FileSystemWatcher>();

        private static void WatcherChanged(object sender, FileSystemEventArgs e)
        {
            MessageBox.Show("File: " + e.Name + " " + e.ChangeType);
        }

        static void WatcherRenamed(object source, RenamedEventArgs e)
        {
            string toShow = "File: " + e.OldFullPath + " was renamed to: " + e.FullPath;
            MessageBox.Show(toShow);
        }

        public static void CreateWatchers(string directory)
        {
            FileSystemWatcher newWatcher = new FileSystemWatcher(directory);
            newWatcher.NotifyFilter =
                NotifyFilters.DirectoryName |
                NotifyFilters.LastWrite | 
                NotifyFilters.LastAccess | 
                NotifyFilters.FileName;
            newWatcher.Created += new FileSystemEventHandler(WatcherChanged);
            newWatcher.Changed += new FileSystemEventHandler(WatcherChanged);
            newWatcher.Renamed += new RenamedEventHandler(WatcherRenamed);
            newWatcher.Deleted += new FileSystemEventHandler(WatcherChanged);
            newWatcher.EnableRaisingEvents = true;
            watchers.Add(newWatcher);
        }
    }
}
