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
            // Subscribe to the Loaded event of ListBoxItems
            myListBox.Loaded += MyListBox_Loaded;
            Player.SetPlayerPage(this);
        }


        public void UpdateImageSource(BitmapImage image)
        {
            songImage.Source = image;
        }


        private void MyListBox_Loaded(object sender, RoutedEventArgs e)
        {
            // Initially set the Tag values for each ListBoxItem
            UpdateItemTags();
        }

        // Call this method when you want to refresh the ListBox items
        public void RefreshListbox()
        {
            // Refresh the ListBox
            myListBox.Items.Refresh();

            // Hook into the StatusChanged event to know when the containers are ready
            myListBox.ItemContainerGenerator.StatusChanged += ItemContainerGenerator_StatusChanged;
        }




        // Method to update the Tag property for each ListBoxItem
        private void UpdateItemTags()
        {
            for (int i = 0; i < myListBox.Items.Count; i++)
            {
                ListBoxItem listBoxItem = myListBox.ItemContainerGenerator.ContainerFromIndex(i) as ListBoxItem;

                if (listBoxItem != null)
                {
                    // Set the index in the Tag property
                    listBoxItem.Tag = i;
                }
            }
        }
        // This method will be called once the containers are ready after the refresh
        private void ItemContainerGenerator_StatusChanged(object sender, EventArgs e)
        {
            // Check if all containers have been generated (containers are available)
            if (myListBox.ItemContainerGenerator.Status == System.Windows.Controls.Primitives.GeneratorStatus.ContainersGenerated)
            {
                // Update the Tag properties now that containers are available
                UpdateItemTags();

                // Unsubscribe from the event after updating the tags
                myListBox.ItemContainerGenerator.StatusChanged -= ItemContainerGenerator_StatusChanged;
            }
        }

    }
}
