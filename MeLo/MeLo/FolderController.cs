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
