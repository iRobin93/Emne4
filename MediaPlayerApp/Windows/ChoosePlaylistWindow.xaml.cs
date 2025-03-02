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
using System.Windows.Shapes;
using MediaPlayerApp.Model;

namespace MediaPlayerApp.Windows
{
    /// <summary>
    /// Interaction logic for ChoosePlaylistWindow.xaml
    /// </summary>
    public partial class ChoosePlaylistWindow : Window
    {
        public Playlist ChosenPlaylist;
        public ChoosePlaylistWindow()
        {
            InitializeComponent();
        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Cast the sender as Playlist
            
            ChosenPlaylist = (MediaPlayerApp.Model.Playlist)((TextBlock)sender).DataContext;
            this.DialogResult = true;
            this.Close();
        }
    }
}
