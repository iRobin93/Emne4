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
            if (!(sender is Image img))
                return;
            var listBoxItem = FindAncestor<ListBoxItem>(img);
            ListBox listBox = FindAncestor<ListBox>(listBoxItem);

            // Access the data item in the ListBoxItem
            var dataItem = listBoxItem.Content;

            // Use the ItemContainerGenerator to find the correct index
            var index = listBox.ItemContainerGenerator.IndexFromContainer(listBoxItem);

            if (Player.SongIsPlaying(index))
            {
                // Set the image source using pack URI for embedded resource
                Uri imageUri = new Uri("pack://application:,,,/Images/unmute.png", UriKind.Absolute);
                img.Source = new BitmapImage(imageUri);
            }

        }

        // Helper method to find the ancestor of a given type
        private T FindAncestor<T>(DependencyObject current) where T : DependencyObject
        {
            while (current != null)
            {
                if (current is T)
                {
                    return (T)current;
                }
                current = VisualTreeHelper.GetParent(current);
            }
            return null;
        }


        // Call this method when you want to refresh the ListBox items
        public void RefreshListbox()
        {
            // Refresh the ListBox
            myListBox.Items.Refresh();

           
        }



    }
}
