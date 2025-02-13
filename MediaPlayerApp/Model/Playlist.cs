using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaPlayerApp.Model
{
    internal class Playlist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Song> Songs { get; set; }

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
