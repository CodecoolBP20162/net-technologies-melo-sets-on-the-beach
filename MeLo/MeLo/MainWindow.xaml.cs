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
using System.Windows.Controls.Primitives;

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
        private bool _isDragging = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (var item in playlistController.GetPlaylists())
            {
                PlaylistView.Items.Add(item);
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
        }

        private void ContentView_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (!_isDragging && e.LeftButton == MouseButtonState.Pressed)
            {
                _isDragging = true;
                // fake listviewitem
                System.Windows.Controls.ListViewItem dummy = new System.Windows.Controls.ListViewItem();
                // Find the data behind the ListViewItem
                try
                {
                    dynamic mediaFile = ContentView.SelectedItem;
                    var path = mediaFile.FullName;
                    Console.WriteLine(path);
                    // Initialize the drag & drop operation
                    System.Windows.DataObject dragData = new System.Windows.DataObject("mediaFile", path);
                    DragDrop.DoDragDrop(dummy, dragData, System.Windows.DragDropEffects.Move);
                }
                catch { }
            }
            _isDragging = false;
        }

        private void PlaylistView_Drop(object sender, System.Windows.DragEventArgs e)
        {
            if (e.Data.GetDataPresent("mediaFile"))
            {
                string sourcePath = e.Data.GetData("mediaFile") as string;
                int index = playlistController.GetCurrentIndex(PlaylistView, e.GetPosition);
                PlaylistSet playlist = PlaylistView.Items[index] as PlaylistSet;
                using (var db = new MeLoDBModels())
                {
                    var mediaSet = db.MediaSet.ToArray();
                    MediaSet mediaToAdd = mediaSet.Where(m => m.Path == sourcePath).Single();
                    if (mediaToAdd != null)
                    {
                        mediaToAdd.PlaylistSet.Add(playlist);
                        Console.WriteLine("már létezett");
                    }
                    else
                    {
                        mediaToAdd.Path = e.Data.GetData("mediaFile") as string;
                        mediaToAdd.TypeId = 3;
                        //mediaToAdd.PlaylistSet.Add(playlist);
                        db.MediaSet.Add(mediaToAdd);
                        Console.WriteLine("nem volt még");
                    }
                    db.SaveChanges();
                }
            }
        }

        private void PlaylistView_DragEnter(object sender, System.Windows.DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(typeof(MediaSet)) || sender == e.Source)
            {
                e.Effects = System.Windows.DragDropEffects.None;
            }
        }

        private void PlaylistView_DragOver(object sender, System.Windows.DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(MediaSet)))
            {
                e.Effects = System.Windows.DragDropEffects.Move;
            }
            else
            {
                e.Effects = System.Windows.DragDropEffects.None;
            }
        }
    }
}
