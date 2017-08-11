using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MeLo
{
    /// <summary>
    /// Interaction logic for PlaylistDialog.xaml
    /// </summary>
    public partial class PlaylistDialog : Window
    {
        public PlaylistDialog()
        {
            InitializeComponent();
            Application curApp = Application.Current;
            Window mainWindow = curApp.MainWindow;
            Owner = mainWindow;
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
