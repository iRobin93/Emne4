using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaPlayerApp.Model
{
    internal class Song
    {
        private int Id { get; set; }
        public string Artist { get; private set; }
        public string Title { get; private set; }

        public Song(int id, string title, string artist)
        {
            Id = id;
            Artist = artist;
            Title = title;
        }
    }
}
