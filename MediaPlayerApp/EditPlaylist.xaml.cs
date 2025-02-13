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
using System.Windows.Shapes;
using MediaPlayerApp.Data;

namespace MediaPlayerApp
{
    /// <summary>
    /// Interaction logic for EditPlaylist.xaml
    /// </summary>
    public partial class EditPlaylist : Window
    {
        public EditPlaylist()
        {
            InitializeComponent();
            myListBox.ItemsSource = Playlists.playlists[0].Songs;
        }
    }
}
