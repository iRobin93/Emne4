﻿using System;
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

        private void MenuItem_ClickAddToQueue(object sender, RoutedEventArgs e)
        {
            CommonSongMethods.MenuItem_ClickAddToQueue(sender, e);

        }

        private void MenuItem_ClickDeleteQueueAndAdd(object sender, RoutedEventArgs e)
        {
            CommonSongMethods.MenuItem_ClickDeleteQueueAndAdd(sender, e);
        }

        private void MenuItem_ClickAddToPlaylist(object sender, RoutedEventArgs e)
        {
            CommonSongMethods.MenuItem_ClickAddToPlaylist(sender, e);
        }

        private void MenuItem_ClickAddNextInQueue(object sender, RoutedEventArgs e)
        {
            CommonSongMethods.MenuItem_ClickAddNextInQueue(sender, e);
        }

        private void MenuItem_ClickDeleteSong(object sender, RoutedEventArgs e)
        {
            // Cast the sender as MenuItem
            var menuItem = sender as MenuItem;
            // Get the DataContext from the MenuItem (the current item in the Grid)
            var selectedSong = menuItem?.CommandParameter as MediaPlayerApp.Model.Song;
            _selectedPlaylist.DeleteSongFromPlaylist(myListBox.SelectedIndex);
        }

    }
}
