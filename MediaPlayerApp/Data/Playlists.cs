using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaPlayerApp.Model;

namespace MediaPlayerApp.Data
{
    static public class Playlists
    {
        public static ObservableCollection<Playlist> playlists = new ObservableCollection<Playlist>();
        static Playlists()
        {
            var myPlayList2 = new Playlist( "MyList2");
            var myPlayList = new Playlist( "MyPlayList");
            var mySong = new Song("MySong", "Me", "test");
            myPlayList.AddSong(mySong);
            mySong = new Song("YourSong", "You", "test2");
            myPlayList.AddSong(mySong);
            myPlayList2.AddSong(mySong);
            playlists.Add(myPlayList);
            playlists.Add(myPlayList2);
        }
        public static void AddPlaylist(Playlist playlist)
        {
            playlists.Add(playlist);
        }
    }

}
