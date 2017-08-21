using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeLo.Models;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace MeLo
{
    class PlaylistController
    {
        private static PlaylistController instance;
        public delegate Point GetPositionDelegate(IInputElement element);

        private PlaylistController() { }

        public static PlaylistController Setup()
        {
            if (instance == null)
            {
                instance = new PlaylistController();
            }
            return instance;
        }

        public List<PlaylistSet> GetPlaylists()
        {
            List<PlaylistSet> playlists;
            using (var db = new MeLoDBModels())
            {
                playlists = db.PlaylistSet.ToList();
            }
            return playlists;
        }

        public void SavePlaylistToDatabase(PlaylistSet pl)
        {
            using (var db = new MeLoDBModels())
            {
                db.PlaylistSet.Add(pl);
                db.SaveChanges();
            }
        }

        public int GetCurrentIndex(ListView target, GetPositionDelegate getPosition)
        {
            int index = -1;
            for (int i = 0; i < target.Items.Count; i++)
            {
                ListViewItem item = GetListViewItem(target, i);
                if (item == null)
                    continue;
                if (IsMouseOverTarget(item, getPosition))
                {
                    index = i;
                    break;
                }
            }
            return index;
        }

        private ListViewItem GetListViewItem(ListView target, int index)
        {
            if (target.ItemContainerGenerator.Status != GeneratorStatus.ContainersGenerated)
                return null;
            return target.ItemContainerGenerator.ContainerFromIndex(index) as ListViewItem;
        }

        private bool IsMouseOverTarget(Visual target, GetPositionDelegate getPosition)
        {
            Rect bounds = VisualTreeHelper.GetDescendantBounds(target);
            Point mousePos = getPosition((IInputElement)target);
            return bounds.Contains(mousePos);
        }
    }
}
