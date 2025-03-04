using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MediaPlayerApp.Model;

namespace MediaPlayerApp
{
    /// <summary>
    /// Interaction logic for PlayerPage.xaml
    /// </summary>
    public partial class PlayerPage : Page
    {
        public PlayerPage()
        {
            InitializeComponent();

            Player.SetPlayerPage(this);
            myListBox.PreviewMouseDoubleClick += MyListBox_PreviewMouseDoubleClick;
        }


        private void MyListBox_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

                // Handle the click event here (e.g., play the song, show details, etc.)
                Player.PlaySong((int)myListBox.SelectedIndex);

        }

        
        public void UpdateImageSource(BitmapImage image)
        {
            songImage.Source = image;
        }

        public void NotMutedImage_Loaded(object sender, RoutedEventArgs e)
        {
         
        }


        // Call this method when you want to refresh the ListBox items
        public void RefreshListbox()
        {
            // Refresh the ListBox
            myListBox.Items.Refresh();

           
        }



    }
}
