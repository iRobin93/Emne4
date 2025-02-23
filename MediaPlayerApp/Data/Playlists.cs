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
            var mySong = new Song("Yellow", "ColdPlay", "C:\\Users\\robin\\OneDrive\\Dokumenter\\Music\\spotidownloader.com - Yellow - Coldplay.mp3");
            myPlayList.AddSong(mySong);
           // Player.AddTo_songList(mySong);
            mySong = new Song("All that she wants", "Ace of Base", "C:\\Users\\robin\\OneDrive\\Dokumenter\\Music\\16 All That She Wants.m4a");
            myPlayList.AddSong(mySong);
            myPlayList2.AddSong(mySong);
            playlists.Add(myPlayList);
            playlists.Add(myPlayList2);
            //Player.AddTo_songList(mySong);
        }
        public static void AddPlaylist(Playlist playlist)
        {
            playlists.Add(playlist);
        }
    }

}
