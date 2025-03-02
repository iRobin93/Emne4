using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaPlayerApp.Model
{
    public class PlaylistWithSongIds
    {
        public Playlist Playlist { get; set; }
        public List<int> SongIds { get; set; }
    }
}
