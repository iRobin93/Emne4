using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaPlayerApp.Model;

namespace MediaPlayerApp.Data
{
    static public class Songs
    {
        public static ObservableCollection<Song> AllSongs { get; private set; } = new ObservableCollection<Song>();


        public static void AddSong(Song song)
        {
            AllSongs.Add(song);
        }

        public static void DeleteSong(Song song)
        {
            AllSongs.Remove(song);
            Playlists.DeleteSongFromAllPlaylists(song);
        }

    }
}
