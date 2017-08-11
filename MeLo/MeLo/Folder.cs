using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MeLo
{
    public class Folder
    {
        public string Name { get; set; }
        public string Path { get; set; }
        private DirectoryInfo currentDirectoryInfo;

        public Folder(string name, string path)
        {
            Name = name;
            Path = path;
            currentDirectoryInfo = new DirectoryInfo(Path);
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

        private FileInfo[] GetFiles()
        {
            FileInfo[] files;
            try
            {
                files = currentDirectoryInfo.GetFiles();
                return files;
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Access denied. You might not see every file you need.", "Error");
                files = new FileInfo[0];
                return files;
            }
        }

        public void ListContent()
        {

        }
    }
    

}
