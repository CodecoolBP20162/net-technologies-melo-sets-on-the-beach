using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public string GetFolderDialog()
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();

            DialogResult result = folderBrowser.ShowDialog();
            String folderName = "";
            if (result == DialogResult.OK)
            {
                folderName = folderBrowser.SelectedPath;
            }

            return folderName;
        }
    }
}
