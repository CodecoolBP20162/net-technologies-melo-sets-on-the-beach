using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
<<<<<<< Updated upstream
using System.Windows.Controls;
=======
>>>>>>> Stashed changes

namespace MeLo
{
    public class Folder
    {
        public string Name { get; set; }
        public string Path { get; set; }
        private DirectoryInfo currentDirectoryInfo;
<<<<<<< Updated upstream
        List<FileSystemInfo> audioItems;
        List<FileSystemInfo> videoItems;
        List<FileSystemInfo> pictureItems;
=======
>>>>>>> Stashed changes

        public Folder(string name, string path)
        {
            Name = name;
            Path = path;
            currentDirectoryInfo = new DirectoryInfo(Path);
<<<<<<< Updated upstream
            audioItems = new List<FileSystemInfo>();
            videoItems = new List<FileSystemInfo>();
            pictureItems = new List<FileSystemInfo>();
=======
>>>>>>> Stashed changes
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

<<<<<<< Updated upstream
        private FileInfo[] GetFiles( DirectoryInfo directory)
=======
        private FileInfo[] GetFiles()
>>>>>>> Stashed changes
        {
            FileInfo[] files;
            try
            {
<<<<<<< Updated upstream
                files = directory.GetFiles();
=======
                files = currentDirectoryInfo.GetFiles();
>>>>>>> Stashed changes
                return files;
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Access denied. You might not see every file you need.", "Error");
                files = new FileInfo[0];
                return files;
            }
        }

<<<<<<< Updated upstream
        private void SeparateByType(DirectoryInfo directory)
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

        public void ListContent()
        {
            
=======
        public void ListContent()
        {

>>>>>>> Stashed changes
        }
    }
    

}
