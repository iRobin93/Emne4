using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net.Http;
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
using Newtonsoft.Json;

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

        private async void SaveSong(object sender, RoutedEventArgs e)
        {
            bool addSong = true;
                foreach (Song song in (ObservableCollection<Song>) Songs.AllSongs)
                    if (FilePath == song.FilePath)
                    {
                        addSong = false;
                        if (_selectedPlaylist != null)
                        {
                            
                            await CommonModel.AddSongToPlaylistInDb(song, _selectedPlaylist, _selectedPlaylist.Songs.Count);
                            _selectedPlaylist.AddSong(song);
                    }
                        
                        goto foundSong;
                    }

            if (addSong)
            {
                if (_selectedPlaylist != null)
                {
                    var song = new Song(SongName.Text, ArtistName.Text, FilePath, true, 0);
                    
                    await CommonModel.AddSongToPlaylistInDb(song, _selectedPlaylist, _selectedPlaylist.Songs.Count);
                    _selectedPlaylist.AddSong(song);
                }
                    
                else new Song(SongName.Text, ArtistName.Text, FilePath, true, 0);
            }
        foundSong:
            _mainFrame.GoBack();
        }
    }
}
