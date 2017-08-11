using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeLo.Models;

namespace MeLo
{
    class PlaylistController
    {
        private static PlaylistController instance;

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

        public void SavePlaylistToDatabase(string name)
        {
            using (var db = new MeLoDBModels())
            {
                PlaylistSet newPlaylist = new PlaylistSet();
                newPlaylist.Name = name;
                db.PlaylistSet.Add(newPlaylist);
                db.SaveChanges();
            }
            

        }
    }
}
