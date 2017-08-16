using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MeLo.Models;
using MessageBox = System.Windows.MessageBox;

namespace MeLo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Container container = Container.Setup();
        private FolderController folderController = FolderController.Setup();
        private PlaylistController playlistController = PlaylistController.Setup();

        public MainWindow()
        {
            InitializeComponent();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            foreach(var item in playlistController.GetPlaylists())
            {
                PlaylistView.Items.Add(item.Name);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PlaylistDialog dialog = new PlaylistDialog();

            dialog.ShowDialog();

            if (dialog.DialogResult == true)
            {
                string playlistname = dialog.newPlaylistTextbox.Text;
                PlaylistView.Items.Add(playlistname);
                playlistController.SavePlaylistToDatabase(playlistname);
                dialog.Close();
            }
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Folder current = folderController.GetFolderDialog();
            container.Add(current);
            NavigatorView.Items.Add(current);
        }


        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
        
        private void NavigatorView_MouseClick(object sender, MouseButtonEventArgs e)
        {
            string name = NavigatorView.SelectedItems.ToString();
        }
    }
}
