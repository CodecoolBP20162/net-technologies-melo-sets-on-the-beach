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
    /// Interaction logic for MeLoVideoPlayer.xaml
    /// </summary>
    public partial class MeLoVideoPlayer : Window
    {
        public MeLoVideoPlayer(string path)
        {
            InitializeComponent();
            mePlayer.Source = new Uri(path);
            mePlayer.Play();}

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            mePlayer.Play();
        }

        private void btnPause_Click(object sender, RoutedEventArgs e)
        {
            mePlayer.Pause();
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            mePlayer.Stop();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            mePlayer.Close();
        }
    }
}
