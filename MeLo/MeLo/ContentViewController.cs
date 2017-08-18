using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MeLo
{
    class ContentViewController
    {
        private static ContentViewController instance;

        private ContentViewController()
        {
        }

        public static ContentViewController Setup()
        {
            if (instance == null)
            {
                instance = new ContentViewController();
            }
            return instance;
        }

        public void Play(FileInfo file)
        {
            Type? currentFileType = Folder.GetMediaType(file);
            Window player = new Window();
            switch (currentFileType)
            {
                case Type.Audio:
                    player = new MeLoMusicPlayer(file.FullName);
                    break;
                case Type.Video:
                    player = new MeLoVideoPlayer(file.FullName);
                    break;
                case Type.Picture:
                    player = new PictureViewer(file.FullName);
                    break;
            }
            player.Show();
        }

    }
}
