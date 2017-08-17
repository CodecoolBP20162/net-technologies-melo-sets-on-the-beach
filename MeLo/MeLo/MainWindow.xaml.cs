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
        private Point startPoint;

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
            FolderWatcher.CreateWatchers(current.Path);
            NavigatorView.Items.Add(current);
        }
        
        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void NavigatorView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Folder newItem = (Folder)e.AddedItems[0];
                ContentView.Items.Clear();
                newItem.ListContent(ContentView);
            }
            catch { }
        }

        private void ContentView_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Store the mouse position
            startPoint = e.GetPosition(null);
        }

        private void ContentView_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            // Get the current mouse position
            Point mousePos = e.GetPosition(null);
            Vector diff = startPoint - mousePos;

            if (e.LeftButton == MouseButtonState.Pressed && (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance ||
                Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance))
            {
                // Get the dragged ListViewItem
                System.Windows.Controls.ListView listView = sender as System.Windows.Controls.ListView;
                System.Windows.Controls.ListViewItem listViewItem =
                    FindAnchestor<System.Windows.Controls.ListViewItem>((DependencyObject)e.Source);

                // Find the data behind the ListViewItem
                try
                {
                    dynamic mediaFile = ContentView.SelectedItem;
                    var path = mediaFile.FullName;
                    Console.WriteLine(path);
                    // Initialize the drag & drop operation
                    System.Windows.DataObject dragData = new System.Windows.DataObject("myFormat", mediaFile);
                    DragDrop.DoDragDrop(listViewItem, dragData, System.Windows.DragDropEffects.Move);
                }
                catch { }
            }
        }

        // Helper to search up the VisualTree
        private static T FindAnchestor<T>(DependencyObject current)
            where T : DependencyObject
        {
            do
            {
                if (current is T)
                {
                    return (T)current;
                }
                current = VisualTreeHelper.GetParent(current);
            }
            while (current != null);
            return null;
        }

        private void PlaylistView_Drop(object sender, System.Windows.DragEventArgs e)
        {
            if (e.Data.GetDataPresent("myFormat"))
            {
                MediaSet mediaFile = e.Data.GetData("myFormat") as MediaSet;
                PlaylistView.Items.Add(mediaFile);
            }
        }

        private void PlaylistView_DragEnter(object sender, System.Windows.DragEventArgs e)
        {
            if (!e.Data.GetDataPresent("myFormat") || sender == e.Source)
            {
                e.Effects = System.Windows.DragDropEffects.None;
            }
        }
    }
}
