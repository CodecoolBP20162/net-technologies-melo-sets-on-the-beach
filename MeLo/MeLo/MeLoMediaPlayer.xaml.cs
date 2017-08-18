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
using System.Windows.Threading;
using Microsoft.Win32;

namespace MeLo
{
    /// <summary>
    /// Interaction logic for MeLoMediaPlayer.xaml
    /// </summary>
    public partial class MeLoMediaPlayer : Window
    {
        private MediaPlayer mediaPlayer = new MediaPlayer();

        public MeLoMediaPlayer(string path)
        {
            InitializeComponent();
            mediaPlayer.Open(new Uri(path));
        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Play();
        }

        private void btnPause_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Pause();
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Stop();
        }
    }
}
