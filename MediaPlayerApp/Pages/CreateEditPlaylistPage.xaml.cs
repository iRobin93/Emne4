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

namespace MediaPlayerApp.Pages
{
    /// <summary>
    /// Interaction logic for CreateEditPlaylistPage.xaml
    /// </summary>
    public partial class CreateEditPlaylistPage : Page
    {
        private Frame _mainFrame;
        public CreateEditPlaylistPage(Frame mainframe)
        {
            InitializeComponent();
            _mainFrame = mainframe;
        }

        // Event handler for the button click
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Get the text entered in the input field
            string input = inputTextBox.Text;
            Playlist playlist = new Playlist(input, true, 0);
            Playlists.AddPlaylist(playlist);

        }
    }
}
