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

namespace MediaPlayerApp
{
    /// <summary>
    /// Interaction logic for EditPlaylist.xaml
    /// </summary>
    public partial class AdministratePlaylists : Window
    {
        private Window _previousWindow;
        public AdministratePlaylists(Window window)
        {
            InitializeComponent();
            _previousWindow = window;
        }

        private void Button_ClickEdit(object sender, RoutedEventArgs e)
        {
          
            EditPlaylist subWindow = new EditPlaylist();
            subWindow.Show();  // Opens the sub-window
            
        }

        private void Button_ClickDelete(object sender, RoutedEventArgs e)
        {
            _previousWindow.Show();
            this.Close();
        }
    }
}
