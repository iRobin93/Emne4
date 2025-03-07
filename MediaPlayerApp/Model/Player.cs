﻿using System;
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
    public static class Player
    {
        private static MediaPlayer mediaPlayer = new MediaPlayer();
        private static int _currentlyPlayingIndex = -1;
        public static ObservableCollection<Song> _songList = new ObservableCollection<Song>();
        private static int _volume;
        private static TimeSpan _duration;
        private static bool _isPlaying = false;
        private static MainWindow _mainwindow = (MainWindow)Application.Current.MainWindow;
        private static DispatcherTimer _timer;
        private static double _songDuration;
        private static double _previousVolume;
        private static PlayerPage _playerpage;

        static Player()
        {
            mediaPlayer.Volume = 0.5;
            // Bind the slider to control the volume of the MediaPlayer
            _mainwindow.volumeSlider.ValueChanged += (s, e) =>
            {
                mediaPlayer.Volume = _mainwindow.volumeSlider.Value;
            };
        }

        public static void MoveSong(int fromIndex, int toIndex)
        {
            if (_currentlyPlayingIndex == fromIndex)
                _currentlyPlayingIndex = toIndex;
            else if (fromIndex < _currentlyPlayingIndex && toIndex >= _currentlyPlayingIndex)
                _currentlyPlayingIndex--;
            else if (fromIndex > _currentlyPlayingIndex && toIndex <= _currentlyPlayingIndex)
                _currentlyPlayingIndex++;

            var song = _songList[fromIndex];
            _songList.RemoveAt(fromIndex);  // Remove the dragged item
            _songList.Insert(toIndex, song);  // Insert the dragged item at the new position
        }

        public static void SetPlayerPage(PlayerPage page)
        {
            _playerpage = page;
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

        public static void PlaySong(int songIndex)
        {
            var song = _songList[songIndex];
            var tagFile = TagLib.File.Create(song.FilePath);
            _mainwindow.UpdateProgressSlider(0);
            _currentlyPlayingIndex = songIndex;
            mediaPlayer.Open(new Uri(song.FilePath));
            mediaPlayer.Play();
            _duration = tagFile.Properties.Duration;
            _songDuration = _duration.TotalSeconds;
            _isPlaying = true;
            _mainwindow.ChangeToPause();
            _mainwindow.SetSongInfo(tagFile);
            _playerpage.RefreshListbox();
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
            _currentlyPlayingIndex = -1;
            _songList.Clear();
            mediaPlayer.Stop();
        }

        public static void AddPlaylistToEnd(Playlist playlist)
        {

            foreach (Song song in playlist.Songs)
            {   
                _songList.Add(song);
            }
            if (_songList.Count == playlist.Songs.Count && playlist.Songs.Count > 0)
                PlaySong(0);
        }

       

        public static void AddTo_songList(Song song)
        {
            _songList.Add(song);
            if (_songList.Count == 1)
                PlaySong(0);
        }

        public static void AddToNextInQueue(Song song)
        {

            
            _songList.Insert(_currentlyPlayingIndex + 1, song);
            if (_songList.Count == 1)
                PlaySong(0);
        }

        public static void PlayNextSong()
        {
        
            // Check if the song is not the last one in the list
            if (_currentlyPlayingIndex >= 0 && _currentlyPlayingIndex < _songList.Count - 1)
            {
                // Return the next song in the list
                PlaySong(_currentlyPlayingIndex + 1);
            }
            else
            {
                _currentlyPlayingIndex = -1;
                _mainwindow.ChangeToPlay();
            }

        }

        public static bool SongIsPlaying(int songIndex)
        {
            if (_currentlyPlayingIndex == songIndex)
                return true;
            else return false;

        }

        public static void RestartSong()
        {

            if (_currentlyPlayingIndex >= 0)
                PlaySong(_currentlyPlayingIndex);
            if(_currentlyPlayingIndex == -1 && _songList.Count > 0)
            {
                PlaySong(_songList.Count - 1);
            }
        }


        public static void PlayPreviousSong()
        {

            // Check if the song is not the last one in the list
            if (_currentlyPlayingIndex > 0)
            {
                PlaySong(_currentlyPlayingIndex - 1);
            }
            else if (_songList.Count > 0)
                PlaySong(_songList.Count - 1);
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

            if(_currentlyPlayingIndex != -1)
            {
                _isPlaying = true;
                 mediaPlayer.Play();
                _mainwindow.ChangeToPause();
            }
            
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
               // _mainwindow.UpdateProgressSlider(0);
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
