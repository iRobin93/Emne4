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
using Microsoft.Win32;

namespace MediaPlayerApp
{
    /// <summary>
    /// Interaction logic for EditPlaylist2.xaml
    /// </summary>
    public partial class EditPlaylist : Page
    {
        private Frame _mainFrame;
        private Playlist _selectedPlaylist;
        public EditPlaylist(Frame mainframe, Playlist selectedPlaylist)
        {
            InitializeComponent();
            _mainFrame = mainframe;
            myListBox.ItemsSource = selectedPlaylist.Songs;
            playlistName.Text = selectedPlaylist.Name;
            _selectedPlaylist = selectedPlaylist;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var song = (MediaPlayerApp.Model.Song)((Button)sender).DataContext;

            Player.AddTo_songList(song);
        }

        private void ChooseFileButton_Click(object sender, RoutedEventArgs e)
        {
            // Create an instance of OpenFileDialog
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Audio Files (*.mp3;*.m4a)|*.mp3;*.m4a";


            // Show the dialog and check if the user selected a file
            if (openFileDialog.ShowDialog() == true)
            {
                // Get the selected file's path and display it in the TextBlock
                string filePath = openFileDialog.FileName;
                //filePathTextBlock.Text = "Selected File: " + filePath;
                _mainFrame.Navigate(new AddSong(_mainFrame, filePath, _selectedPlaylist));
            }
        }
    }
}
