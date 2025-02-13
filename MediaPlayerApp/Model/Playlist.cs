using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaPlayerApp.Model
{
    internal class Playlist
    {
        private int Id { get; set; }
        public string Name { get; private set; }
        public List<Song> Songs { get; private set; } = new List<Song>();

        public Playlist(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public void AddSong(Song song) 
        {
            Songs.Add(song);
        }

    }


}
