using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MediaPlayerApp.Data;
using MediaPlayerApp.Model;

namespace MediaPlayerApp.Pages
{
    /// <summary>
    /// Interaction logic for AddSong.xaml
    /// </summary>
    public partial class AddSong : Page
    {
        private Frame _mainFrame;
        public string FilePath;
        private Playlist _selectedPlaylist;
        
        public AddSong(Frame mainframe, string filepath, Playlist selectedPlaylist)
        {
            InitializeComponent();
            _mainFrame = mainframe;
            FilePath = filepath;
            fileNameTextBlock.Text = FilePath;
            var tagFile = TagLib.File.Create(FilePath);
            ArtistName.Text = tagFile.Tag.FirstPerformer;
            SongName.Text = tagFile.Tag.Title;
            _selectedPlaylist = selectedPlaylist;
        }

        private void SaveSong(object sender, RoutedEventArgs e)
        {
            bool addSong = true;
                foreach (Song song in (ObservableCollection<Song>) Songs.AllSongs)
                    if (FilePath == song.FilePath)
                    {
                        addSong = false;
                    if (_selectedPlaylist != null)
                    {
                        _selectedPlaylist.AddSong(song);
                    }
                        
                        goto foundSong;
                    }

            if (addSong)
            {
                if (_selectedPlaylist != null)
                    _selectedPlaylist.AddSong(new Song(SongName.Text, ArtistName.Text, FilePath, true));
                else new Song(SongName.Text, ArtistName.Text, FilePath, true);
            }
        foundSong:
            _mainFrame.GoBack();
        }
    }
}
