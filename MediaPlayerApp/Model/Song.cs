using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaPlayerApp.Model
{
    internal class Song
    {
        public int Id { get; set; }
        public string Artist { get; set; }
        public string Title { get; set; }

        public Song(int id, string title, string artist)
        {
            Id = id;
            Artist = artist;
            Title = title;
        }
    }
}
