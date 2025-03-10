using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaPlayerApp.Model;
using MediaPlayerApp.Windows;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;

namespace MediaPlayerApp.Pages
{
    class CommonSongMethods
    {
        //Common methods from song pages
        public static void MenuItem_ClickAddToQueue(object sender, RoutedEventArgs e)
        {
            // Cast the sender as MenuItem
            var menuItem = sender as MenuItem;
            // Get the DataContext from the MenuItem (the current item in the Grid)
            var selectedSong = menuItem?.CommandParameter as MediaPlayerApp.Model.Song;
            Player.AddToNextInQueue(selectedSong);

        }

        public static void MenuItem_ClickDeleteQueueAndAdd(object sender, RoutedEventArgs e)
        {
            // Cast the sender as MenuItem
            var menuItem = sender as MenuItem;
            // Get the DataContext from the MenuItem (the current item in the Grid)
            var selectedSong = menuItem?.CommandParameter as MediaPlayerApp.Model.Song;
            Player.ClearPlaylist();
            Player.AddToNextInQueue(selectedSong);
        }

        public static void MenuItem_ClickAddToPlaylist(object sender, RoutedEventArgs e)
        {
            // Cast the sender as MenuItem
            var menuItem = sender as MenuItem;
            // Get the DataContext from the MenuItem (the current item in the Grid)
            var selectedSong = menuItem?.CommandParameter as MediaPlayerApp.Model.Song;
            ChoosePlaylistWindow modal = new ChoosePlaylistWindow();
            bool? result = modal.ShowDialog();
            if (result == true)
            {

                CommonModel.AddSongToPlaylistInDb(selectedSong, modal.ChosenPlaylist, modal.ChosenPlaylist.Songs.Count);
                modal.ChosenPlaylist.AddSong(selectedSong);
            }
        }

        public static void MenuItem_ClickAddNextInQueue(object sender, RoutedEventArgs e)
        {
            // Cast the sender as MenuItem
            var menuItem = sender as MenuItem;
            // Get the DataContext from the MenuItem (the current item in the Grid)
            var selectedSong = menuItem?.CommandParameter as MediaPlayerApp.Model.Song;
            Player.AddToNextInQueue(selectedSong);
        }

        // Helper method to find the ancestor of a given type
        public static T FindAncestor<T>(DependencyObject current) where T : DependencyObject
        {
            while (current != null)
            {
                if (current is T)
                {
                    return (T)current;
                }
                current = VisualTreeHelper.GetParent(current);
            }
            return null;
        }


    }
}
