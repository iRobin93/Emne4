using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaPlayerApp.Model
{
    public class Playlist
    {
        private static int _nextPlaylistId = 1;
        private int Id { get; set; }
        public string Name { get; private set; }
        public ObservableCollection<Song> Songs { get; private set; } = new ObservableCollection<Song>();

        public Playlist(string name)
        {
            Id = _nextPlaylistId++;
            Name = name;
        }

        public void AddSong(Song song) 
        {
            Songs.Add(song);
        }

    }


}
