using System;
using System.Collections.Generic;
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
using MediaPlayerApp.Model;
using MediaPlayerApp.Pages;

namespace MediaPlayerApp
{
    /// <summary>
    /// Interaction logic for AdministratePlaylists2.xaml
    /// </summary>
    public partial class AdministratePlaylists : Page
    {
        private Frame _mainFrame;
        public AdministratePlaylists(Frame mainframe)
        {
            InitializeComponent();
            _mainFrame = mainframe;
        }

        private void Button_ClickEdit(object sender, RoutedEventArgs e)
        {
            var SelectedPlaylist = (MediaPlayerApp.Model.Playlist)((Button)sender).DataContext;
            _mainFrame.Navigate(new EditPlaylist(_mainFrame, SelectedPlaylist));
        }

        private void Button_ClickDelete(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_ClickPlayPlaylist(object sender, RoutedEventArgs e)
        {
            var SelectedPlaylist = (MediaPlayerApp.Model.Playlist)((Button)sender).DataContext;
            Player.ClearPlaylist();
            Player.AddPlaylistToEnd(SelectedPlaylist);
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new CreateEditPlaylistPage(_mainFrame));
        }

        private void Button_ClickSongs(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new SongsPage(_mainFrame));
        }
    }
}
