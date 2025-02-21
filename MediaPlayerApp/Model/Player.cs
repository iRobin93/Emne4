using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;
using MediaPlayerApp.Model;
using TagLib;

namespace MediaPlayerApp.Model
{
    static class Player
    {
        private static MediaPlayer mediaPlayer = new MediaPlayer();
        private static Song _currentlyPlaying;
        private static Song _lastPlayed;
        private static int _volume;
        private static TimeSpan _duration;
        private static bool _isPlaying = false;
        private static MainWindow _mainwindow = (MainWindow)Application.Current.MainWindow;
        private static DispatcherTimer _timer;
        private static double _songDuration;

        public static void PlaySong(Song song)
        {
            var tagFile = TagLib.File.Create(song.FilePath);
            _lastPlayed = _currentlyPlaying;
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
            if (mediaPlayer.Position.TotalSeconds < _songDuration)
            {
                // Update the progress slider value in MainWindow
                _mainwindow.UpdateProgressSlider(mediaPlayer.Position.TotalSeconds);
            }
            else
            {
                // Stop the timer when the song is over
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
