using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MeLo
{
    class FolderController
    {
        private static FolderController instance;

        private FolderController(){}

        public static FolderController Setup()
        {
            if (instance == null)
            {
                instance = new FolderController();
            }
            return instance;
        }

        public Folder GetFolderDialog()
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();

            DialogResult result = folderBrowser.ShowDialog();
            String folderPath = "";
            if (result == DialogResult.OK)
            {
                folderPath = folderBrowser.SelectedPath;
            }

            string referenceName = Regex.Match(folderPath, @"[\w\s]+$").Value;

            Folder currentFolder = new Folder(referenceName, folderPath);

            return currentFolder;
        }
    }
}
