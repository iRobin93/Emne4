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
using MediaPlayerApp.Data;
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

        // Handle PreviewMouseLeftButtonDown to start drag operation
        private void ListBox_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ListBox listBox = sender as ListBox;
            if (listBox == null) return;

            var listBoxItem = FindAncestor<ListBoxItem>((System.Windows.DependencyObject)e.OriginalSource);
            if (listBoxItem == null) return;


            // Get the index of the Song being dragged
            int index = listBox.ItemContainerGenerator.IndexFromContainer(listBoxItem);

            // Start the drag operation and pass the index along with the dragged Song
            DragDrop.DoDragDrop(listBoxItem, new DataObject("SongWithIndex", index), DragDropEffects.Move);
        }


        // Handle DragOver event to allow dropping
        private void ListBox_DragOver(object sender, DragEventArgs e)
        {

        }

        private void ListBox_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("SongWithIndex"))
            {
                // Retrieve the dragged data (Song and Index)
                int draggedIndex = e.Data.GetData("SongWithIndex") as dynamic;
 
                ListBox listBox = sender as ListBox;
                if (listBox == null) return;

                // Get the target ListBoxItem that was hit by the drop
                var position = e.GetPosition(listBox);
                var hitItem = listBox.InputHitTest(position) as DependencyObject;

                // Find the ListBoxItem that was dropped on
                while (hitItem != null && !(hitItem is ListBoxItem))
                {
                    hitItem = VisualTreeHelper.GetParent(hitItem);
                }

                if (hitItem is ListBoxItem targetItem)
                {
                    // Get the target song (item being dropped on)
                    Song targetSong = targetItem.DataContext as Song;
                    if (targetSong == null) return;

                    // Get the index of the Song being dropped at
                    int targetIndex = listBox.ItemContainerGenerator.IndexFromContainer(hitItem);

                    // If the dragged item is not the same as the target item and they are not in the same position
                    if (draggedIndex != targetIndex)
                    {
                        Player.MoveSong(draggedIndex, targetIndex);
                        // Refresh the ListBox
                        listBox.Items.Refresh();
                    }
                }
            }
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
