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
    public enum Type
    {
        Audio,
        Video,
        Picture
    }

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
            SeparateByType(currentDirectoryInfo);
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
                    Type? currentType = GetMediaType(fileinfo);
                    switch (currentType)
                    {
                        case Type.Audio:
                            audioItems.Add(fileinfo);
                            break;
                        case Type.Video:
                            videoItems.Add(fileinfo);
                            break;
                        case Type.Picture:
                            pictureItems.Add(fileinfo);
                            break;
                        case null:
                            break;
                    }
                }
                foreach (DirectoryInfo subdirectoryinfo in directory.GetDirectories())
                {
                    SeparateByType(subdirectoryinfo);
                }
            }


        public static Type? GetMediaType(FileInfo currentFile)
        {
            using (var db = new MeLoDBModels())
            {
                string extension = currentFile.Extension.Substring(1);
                int? type;
                try
                {
                    type = db.ExtensionSet.Single(e => e.Name == extension).TypeId;
                }
                catch (InvalidOperationException)
                {
                    return null;
                }
                switch (type)
                {
                    case 1:
                        return Type.Audio;
                    case 2:
                        return Type.Video;
                    case 3:
                        return Type.Picture;
                }
            }
            return null;
        }

        public void ListContent(ListView targetListView)
        {
            foreach(FileInfo audioFile in audioItems)
            {
                targetListView.Items.Add(audioFile);
            }
            foreach (FileInfo videoFile in videoItems)
            {
                targetListView.Items.Add(videoFile);
            }
            foreach (FileInfo pictureFile in pictureItems)
            {
                targetListView.Items.Add(pictureFile);
            }
        }
    }
}
