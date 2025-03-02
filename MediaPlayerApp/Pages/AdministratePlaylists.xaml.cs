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
            myListBox.PreviewMouseDoubleClick += MyListBox_PreviewMouseDoubleClick;
        }



        private void MyListBox_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ListBoxItem listBoxItem = GetListBoxItemFromMouseEvent(e);
            if (listBoxItem != null)
            {
                // Handle the click event here (e.g., play the song, show details, etc.)
                // Cast the sender as MenuItem
                var selectedPlaylist = listBoxItem.DataContext as Playlist;
                _mainFrame.Navigate(new EditPlaylist(_mainFrame, selectedPlaylist));

            }
        }

        private ListBoxItem GetListBoxItemFromMouseEvent(MouseButtonEventArgs e)
        {
            DependencyObject depObj = e.OriginalSource as DependencyObject;
            while (depObj != null && !(depObj is ListBoxItem))
            {
                depObj = VisualTreeHelper.GetParent(depObj);
            }
            return depObj as ListBoxItem;
        }

        private void MenuItem_Edit(object sender, RoutedEventArgs e)
        {

            // Cast the sender as MenuItem
            var menuItem = sender as MenuItem;
            // Get the DataContext from the MenuItem (the current item in the Grid)
            var SelectedPlaylist = menuItem?.CommandParameter as MediaPlayerApp.Model.Playlist;
            _mainFrame.Navigate(new EditPlaylist(_mainFrame, SelectedPlaylist));
        }

        private void MenuItem_PlayPlaylist(object sender, RoutedEventArgs e)
        {

            // Cast the sender as MenuItem
            var menuItem = sender as MenuItem;
            // Get the DataContext from the MenuItem (the current item in the Grid)
            var SelectedPlaylist = menuItem?.CommandParameter as MediaPlayerApp.Model.Playlist;
            Player.ClearPlaylist();
            Player.AddPlaylistToEnd(SelectedPlaylist);
        }
        private void MenuItem_AddPlaylistToQueue(object sender, RoutedEventArgs e)
        {

            // Cast the sender as MenuItem
            var menuItem = sender as MenuItem;
            // Get the DataContext from the MenuItem (the current item in the Grid)
            var SelectedPlaylist = menuItem?.CommandParameter as MediaPlayerApp.Model.Playlist;
            Player.AddPlaylistToEnd(SelectedPlaylist);
        }
        

        private void MenuItem_Delete(object sender, RoutedEventArgs e)
        {
            var menuItem = sender as MenuItem;
            // Get the DataContext from the MenuItem (the current item in the Grid)
            var SelectedPlaylist = menuItem?.CommandParameter as MediaPlayerApp.Model.Playlist;
            
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
