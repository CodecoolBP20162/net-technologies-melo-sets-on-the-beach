using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using MeLo.Models;

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
            using (var db = new MeLoDBModels())
            {
                foreach (FileInfo fileinfo in directory.GetFiles())
                {
                    string extension = fileinfo.Extension.Substring(1);
                    int? type;
                    try
                    {
                        type = db.ExtensionSet.Single(e => e.Name == extension).TypeId;
                    }
                    catch (InvalidOperationException)
                    {
                        type = null;
                    }
                    if (type == 1)
                    {
                        audioItems.Add(fileinfo);
                    }
                    else if (type == 2)
                    {
                        videoItems.Add(fileinfo);
                    }
                    else if (type == 3)
                    {
                        pictureItems.Add(fileinfo);
                    }
                }
                foreach (DirectoryInfo subdirectoryinfo in directory.GetDirectories())
                {
                    SeparateByType(subdirectoryinfo);
                }
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
