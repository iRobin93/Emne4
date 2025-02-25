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
using MediaPlayerApp.Data;
using MediaPlayerApp.Model;
using MediaPlayerApp.Windows;

namespace MediaPlayerApp.Pages
{
    /// <summary>
    /// Interaction logic for SongsPage.xaml
    /// </summary>
    public partial class SongsPage : Page
    {
        private Frame _mainFrame;
        public SongsPage(Frame mainFrame)
        {
            InitializeComponent();
            _mainFrame = mainFrame;
        }
        //tests
        private void MenuItem_ClickAddToQueue(object sender, RoutedEventArgs e)
        {
            // Cast the sender as MenuItem
            var menuItem = sender as MenuItem;
            // Get the DataContext from the MenuItem (the current item in the Grid)
            var selectedSong = menuItem?.CommandParameter as MediaPlayerApp.Model.Song;
            Player.AddToNextInQueue(selectedSong);

        }

        private void MenuItem_ClickDeleteQueueAndAdd(object sender, RoutedEventArgs e)
        {
            // Cast the sender as MenuItem
            var menuItem = sender as MenuItem;
            // Get the DataContext from the MenuItem (the current item in the Grid)
            var selectedSong = menuItem?.CommandParameter as MediaPlayerApp.Model.Song;
            Player.ClearPlaylist();
            Player.AddToNextInQueue(selectedSong);
        }

        private void MenuItem_ClickAddToPlaylist(object sender, RoutedEventArgs e)
        {
            // Cast the sender as MenuItem
            var menuItem = sender as MenuItem;
            // Get the DataContext from the MenuItem (the current item in the Grid)
            var selectedSong = menuItem?.CommandParameter as MediaPlayerApp.Model.Song;
            ChoosePlaylistWindow modal = new ChoosePlaylistWindow();
            bool? result = modal.ShowDialog();
            if (result == true)
            {
                modal.ChosenPlaylist.AddSong(selectedSong);
            }
            

        }

        private void MenuItem_ClickDeleteSong(object sender, RoutedEventArgs e)
        {
            // Cast the sender as MenuItem
            var menuItem = sender as MenuItem;
            // Get the DataContext from the MenuItem (the current item in the Grid)
            var selectedSong = menuItem?.CommandParameter as MediaPlayerApp.Model.Song;
            Songs.DeleteSong(selectedSong);
        }


    }
}
