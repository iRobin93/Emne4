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
using MediaPlayerApp.Model;

namespace MediaPlayerApp.Pages
{
    /// <summary>
    /// Interaction logic for AddSong.xaml
    /// </summary>
    public partial class AddSong : Page
    {
        private Frame _mainFrame;
        public string FilePath;
        public AddSong(Frame mainframe, string filepath)
        {
            InitializeComponent();
            _mainFrame = mainframe;
            FilePath = filepath;
            fileNameTextBlock.Text = FilePath;
        }

        private void SaveSong(object sender, RoutedEventArgs e)
        {
            


            _mainFrame.GoBack();
        }
    }
}
