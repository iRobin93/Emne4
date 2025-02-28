using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using MediaPlayerApp.Data;
using MediaPlayerApp.Model;
using TagLib.Tiff.Pef;

namespace MediaPlayerApp
{
    public partial class MainWindow : Window
    {
        private PlayerPage _playerpage;
        public MainWindow()
        {
            InitalizeSongsAndPlaylists();
            InitializeComponent();
            
            progressSlider.ValueChanged += ProgressSlider_ValueChanged;
            MainFrame.Navigate(_playerpage = new PlayerPage());
            
        }
        public async void InitalizeSongsAndPlaylists()
        {
            await Songs.InitializeSongs();
            await Playlists.InitializePlaylists();
        }

        //Test
        public void SetSongInfo(TagLib.File tagfile)
        {
            playingNowSongName.Text = tagfile.Tag.Title;
            playingNowArtist.Text = tagfile.Tag.FirstPerformer;
            totalTimeText.Text = tagfile.Properties.Duration.ToString(@"mm\:ss");
            _playerpage.UpdateImageSource(GetAlbumArt(tagfile));
            
        }

        // Method to get album art from the file
        private BitmapImage GetAlbumArt(TagLib.File tagFile)
        {
            
            if (tagFile.Tag.Pictures.Length > 0)
            {
                var picture = tagFile.Tag.Pictures[0]; // Get the first image (album art)
                byte[] byteArray = picture.Data.Data;

                // Convert byte[] to BitmapImage
                var image = new BitmapImage();
                using (var stream = new MemoryStream(byteArray))
                {
                    image.BeginInit();
                    image.StreamSource = stream;
                    image.CacheOption = BitmapCacheOption.OnLoad;
                    image.EndInit();
                }

                return image;
            }

            return null; // Return null if no album art is found
        }

        private void AdminButton_Click(object sender, RoutedEventArgs e)
        {
            if (MainFrame.Content is PlayerPage)
            {
                AdminButton.Content = "Tilbake";
                headerText.Text = "Administrasjon";
                MainFrame.Navigate(new AdministratePlaylists(MainFrame));
            }
            else if (MainFrame.Content is AdministratePlaylists)
            {
                headerText.Text = "Spiller";
                AdminButton.Content = "Administrer";
                MainFrame.GoBack();
            }
            else
            {
                MainFrame.GoBack();
            }
        }

        private void pausePlayButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (Player.IsPlaying())
            {
                Player.PauseSong();
            }

            else
            {
                Player.ResumeSong();
            }
                
        }

        public void ChangeToPlay()
        {
            pausePlayButton.Text = "⏵"; // Play symbol
            pausePlayButton.FontSize = 40;
            var currentMargin = pausePlayButton.Margin;
            pausePlayButton.Margin = new Thickness(currentMargin.Left, -12, currentMargin.Right, currentMargin.Bottom);
        }

        public void ChangeToPause()
        {
            pausePlayButton.Text = "⏸"; // Pause symbol
            pausePlayButton.FontSize = 31;
            // Get the current margin, modify the Top value, and then set it back.
            var currentMargin = pausePlayButton.Margin;
            pausePlayButton.Margin = new Thickness(currentMargin.Left, -5, currentMargin.Right, currentMargin.Bottom);
        }

        // Update the progress slider with the current song position
        public void UpdateProgressSlider(double currentPosition)
        {
            progressSlider.Value = currentPosition;
            currentTimeText.Text = TimeSpan.FromSeconds(currentPosition).ToString(@"mm\:ss");
        }

        // Event handler for the progress slider (when the user seeks to a new position)
        private void ProgressSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (Math.Abs(e.NewValue - e.OldValue) > 0.1) // Avoid calling frequently if no real change
            {
                Player.SeekSong(e.NewValue);
            }
        }

        private void previousSong_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var time = TimeSpan.FromSeconds(progressSlider.Value);
            if (time.TotalSeconds < 2)
                Player.PlayPreviousSong();
            else Player.RestartSong();

        }

        private void nextSong_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Player.PlayNextSong();
        }

        private void Mute_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Player.MuteOrUnMute();
        }

        public void SetMuteIcon()
        {
            MuteImage.Source = new BitmapImage(new Uri("pack://application:,,,/Images/mute.png", UriKind.Absolute));
        }

        public void SetUnmuteIcon()
        {
            MuteImage.Source = new BitmapImage(new Uri("pack://application:,,,/Images/unmute.png", UriKind.Absolute));
        }
    }
}
