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

namespace MediaPlayerApp
{
    /// <summary>
    /// Interaction logic for AdministratePlaylists2.xaml
    /// </summary>
    public partial class AdministratePlaylists2 : Page
    {
        private Frame _mainFrame;
        public AdministratePlaylists2(Frame mainframe)
        {
            InitializeComponent();
            _mainFrame = mainframe;
        }

        private void Button_ClickEdit(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new EditPlaylist2(_mainFrame));
        }

        private void Button_ClickDelete(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            _mainFrame.Content = null;
        }
    }
}
