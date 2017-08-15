using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MeLo
{
    public class Folder
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public DirectoryInfo currentDirectoryInfo;
        public List<FileSystemInfo> audioItems;
        public List<FileSystemInfo> videoItems;
        public List<FileSystemInfo> pictureItems;

        public Folder(string name, string path)
        {
            Name = name;
            Path = path;
            currentDirectoryInfo = new DirectoryInfo(Path);
            audioItems = new List<FileSystemInfo>();
            videoItems = new List<FileSystemInfo>();
            pictureItems = new List<FileSystemInfo>();
        }

        private DirectoryInfo[] GetSubdirectories()
        {
            DirectoryInfo[] subDirectories;
            try
            {
                subDirectories = currentDirectoryInfo.GetDirectories();
                return subDirectories;
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Access denied. You might not see every folder you need.", "Error");
                subDirectories = new DirectoryInfo[0];
                return subDirectories;
            }
        }

        private FileInfo[] GetFiles( DirectoryInfo directory)
        {
            FileInfo[] files;
            try
            {
                files = directory.GetFiles();
                return files;
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Access denied. You might not see every file you need.", "Error");
                files = new FileInfo[0];
                return files;
            }
        }

        public void SeparateByType(DirectoryInfo directory)
        {
            foreach (FileInfo fileinfo in directory.GetFiles())
            {
                if (fileinfo.FullName.Contains("mp3") && !audioItems.Contains(fileinfo))
                {
                    audioItems.Add(fileinfo);
                }
                else if (fileinfo.FullName.Contains("mp4") && !videoItems.Contains(fileinfo))
                {
                   videoItems.Add(fileinfo);
                }
                else if ((fileinfo.FullName.Contains("jpg") || fileinfo.FullName.Contains("jpeg")
                    || fileinfo.FullName.Contains("png")) && !pictureItems.Contains(fileinfo))
                {
                    pictureItems.Add(fileinfo);
                }
            }
            foreach (DirectoryInfo subdirectoryinfo in directory.GetDirectories())
            {
                SeparateByType(subdirectoryinfo);
            }
        }

        public void ListContent(ListView targetListView)
        {
            SeparateByType(currentDirectoryInfo);
            foreach(FileInfo audioFile in audioItems)
            {
                targetListView.Items.Add(audioFile);
            }
        }
    }
}
