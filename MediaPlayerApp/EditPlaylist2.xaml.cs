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

namespace MediaPlayerApp
{
    /// <summary>
    /// Interaction logic for EditPlaylist2.xaml
    /// </summary>
    public partial class EditPlaylist2 : Page
    {
        private Frame _mainFrame;
        public EditPlaylist2(Frame mainframe)
        {
            InitializeComponent();
            _mainFrame = mainframe;
            myListBox.ItemsSource = Playlists.playlists[0].Songs;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var song = (MediaPlayerApp.Model.Song)((Button)sender).DataContext;
            
            Player.PlaySong(song);
        }
    }
}
