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
            string userProfile = Environment.GetEnvironmentVariable("USERPROFILE");
            string filePath = userProfile + @"\Documents\Music\spotidownloader.com - Yellow - Coldplay.mp3";
            //var mySong = new Song("Yellow", "ColdPlay", filePath);
            //var mySong = new Song("Yellow", "ColdPlay", "C:\\Users\\robin\\Documents\\Music\\spotidownloader.com - Yellow - Coldplay.mp3");
            //myPlayList.AddSong(Songs.AllSongs[0]);
            //mySong = new Song("All that she wants", "Ace of Base", "C:\\Users\\robin\\Documents\\Music\\16 All That She Wants.m4a");
            filePath = userProfile + @"\Documents\Music\16 All That She Wants.m4a";
            //mySong = new Song("All that she wants", "Ace of Base", filePath);
            //myPlayList.AddSong(Songs.AllSongs[1]);
            //myPlayList.AddSong(Songs.AllSongs[2]);
            //myPlayList2.AddSong(Songs.AllSongs[1]);
            playlists.Add(myPlayList);
            playlists.Add(myPlayList2);
            //Player.AddTo_songList(mySong);
        }
        public static void AddPlaylist(Playlist playlist)
        {
            playlists.Add(playlist);
        }

        public static void DeleteSongFromAllPlaylists(Song song)
        {
            foreach (var playlist in playlists)
            {
                playlist.Songs.Remove(song);
            }
        }
    }

}
