using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaPlayerApp.Model;

namespace MediaPlayerApp.Data
{
    static internal class Playlists
    {
        public static List<Playlist> playlists = new List<Playlist>();

        static Playlists()
        {
            var myPlayList = new Playlist(1, "MyPlayList");
            var mySong = new Song(1, "MySong", "Me");
            myPlayList.AddSong(mySong);
            mySong = new Song(2, "YourSong", "You");
            myPlayList.AddSong(mySong);
            playlists.Add(myPlayList);
            
        }
    }

}
