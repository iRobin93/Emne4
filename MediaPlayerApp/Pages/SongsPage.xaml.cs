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

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_ClickAddToQueue(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_ClickDeleteQueueAndAdd(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_ClickAddToPlaylist(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_ClickDeleteSong(object sender, RoutedEventArgs e)
        {

        }


    }
}
