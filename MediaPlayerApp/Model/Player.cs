using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaPlayerApp.Model
{
    static class Player
    {
        private static Song _currentlyPlaying;
        private static Song _lastPlayed;
        private static int _volume;



        public static void PlaySong(Song song)
        {
            _lastPlayed = _currentlyPlaying;
            _currentlyPlaying = song;
        }
    }
}
