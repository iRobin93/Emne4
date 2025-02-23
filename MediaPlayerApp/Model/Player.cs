using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using MediaPlayerApp.Model;
using TagLib;

namespace MediaPlayerApp.Model
{
    static class Player
    {
        private static MediaPlayer mediaPlayer = new MediaPlayer();
        private static Song _currentlyPlaying;
        private static ObservableCollection<Song> _songList = new ObservableCollection<Song>();
        private static int _volume;
        private static TimeSpan _duration;
        private static bool _isPlaying = false;
        private static MainWindow _mainwindow = (MainWindow)Application.Current.MainWindow;
        private static DispatcherTimer _timer;
        private static double _songDuration;
        private static double _previousVolume;


        static Player()
        {
            mediaPlayer.Volume = 0.5;
            // Bind the slider to control the volume of the MediaPlayer
            _mainwindow.volumeSlider.ValueChanged += (s, e) =>
            {
                mediaPlayer.Volume = _mainwindow.volumeSlider.Value;
            };
        }

        public static void MuteOrUnMute()
        {
            if (mediaPlayer.Volume > 0)
            {
                // Mute the volume and update the button content
                _previousVolume = mediaPlayer.Volume; // Store the current volume before muting
                mediaPlayer.Volume = 0;
                _mainwindow.SetMuteIcon();
            }
            else
            {
                // Restore the volume and update the button content
                mediaPlayer.Volume = _previousVolume;
                _mainwindow.SetUnmuteIcon();

            }
            _mainwindow.volumeSlider.Value = mediaPlayer.Volume;
        }

        private static void PlaySong(Song song)
        {
            var tagFile = TagLib.File.Create(song.FilePath);
            _currentlyPlaying = song;
            mediaPlayer.Open(new Uri(song.FilePath));
            mediaPlayer.Play();
            _duration = tagFile.Properties.Duration;
            _songDuration = _duration.TotalSeconds;
            _isPlaying = true;
            _mainwindow.ChangeToPause();
            _mainwindow.SetSongInfo(tagFile);

            // Set the slider maximum value
            _mainwindow.progressSlider.Maximum = _songDuration;

            // Initialize the timer for updating the slider
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Tick += Timer_Tick;
            _timer.Start();
        }

        public static void ClearPlaylist()
        {
            _songList = new ObservableCollection<Song>();
        }

        public static void AddPlaylistToEnd(Playlist playlist)
        {
            if (_songList.Count == 0 && playlist.Songs.Count > 0)
                PlaySong(playlist.Songs[0]);
            foreach (Song song in playlist.Songs)
                _songList.Add(song);
        }

        public static void AddTo_songList(Song song)
        {

            if (_songList.Count == 0)
                PlaySong(song);
            _songList.Add(song);
            
        }

        public static void PlayNextSong()
        {
            // Find the index of the currently playing song
            int currentIndex = _songList.IndexOf(_currentlyPlaying);
            // Check if the song is not the last one in the list
            if (currentIndex >= 0 && currentIndex < _songList.Count - 1)
            {
                // Return the next song in the list
                PlaySong(_songList[currentIndex + 1]);
            }
            // do nothing if there is no next song.

        }

        public static void RestartSong()
        {
            // Find the index of the currently playing song
            int currentIndex = _songList.IndexOf(_currentlyPlaying);
            if (currentIndex >= 0)
                PlaySong(_songList[currentIndex]);
        }


        public static void PlayPreviousSong()
        {
            // Find the index of the currently playing song
            int currentIndex = _songList.IndexOf(_currentlyPlaying);
            // Check if the song is not the last one in the list
            if (currentIndex > 0)
            {
                PlaySong(_songList[currentIndex - 1]);
            }
            else if (currentIndex == 0)
                PlaySong(_songList[currentIndex]);
        }




        public static bool IsPlaying()
        {
            return _isPlaying;
        }

        public static void PauseSong()
        {
            _isPlaying = false;
            mediaPlayer.Pause();
            _mainwindow.ChangeToPlay();
        }

        public static void ResumeSong()
        {
            _isPlaying = true;
            mediaPlayer.Play();
            _mainwindow.ChangeToPause();
        }

        // Timer tick event to update the progress slider
        private static void Timer_Tick(object sender, EventArgs e)
        {
            if (mediaPlayer.Position.TotalSeconds <=  (_songDuration - 1))
            {
                // Update the progress slider value in MainWindow
                _mainwindow.UpdateProgressSlider(mediaPlayer.Position.TotalSeconds);
            }
            else
            {
                // Stop the timer when the song is over
                PlayNextSong();
                _mainwindow.UpdateProgressSlider(0);
                _timer.Stop();
            }
        }


        // Seek the song to a specific position
        public static void SeekSong(double position)
        {
            mediaPlayer.Position = TimeSpan.FromSeconds(position);
        }
    }
}
