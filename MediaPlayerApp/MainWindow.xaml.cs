using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

/*
 * Opprette nødvendige klasser - 
 * 
 * 
 * 
 */


namespace MediaPlayerApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //MainFrame.Navigate(new Uri("PlayerPage.xaml", UriKind.Relative));
            MainFrame.Navigate(new PlayerPage());
        }

        private void AdminButton_Click(object sender, RoutedEventArgs e)
        {
            if(MainFrame.Content is PlayerPage)
            {
                AdminButton.Content = "Tilbake";
                MainFrame.Navigate(new AdministratePlaylists(MainFrame));
                //MainFrame.Navigate(new Uri("AdministratePlaylists2.xaml", UriKind.Relative));
            }
            else if (MainFrame.Content is AdministratePlaylists) 
            {
                AdminButton.Content = "Administrer";
                MainFrame.GoBack();
                
            }
            else
            {
                MainFrame.GoBack();
            }
            

            
            
            
        }
    }
}

/*
 * 
 * 
 * 
 * private void AdminButton_Click(object sender, RoutedEventArgs e)
        {
            if (MainFrame.Content is SubPage2)
            {
                MainFrame.GoBack();
                AdminButton.Content = "Administrer";
            }
            else
            {
                MainFrame.Navigate(new Uri("SubPage2.xaml", UriKind.Relative));
                AdminButton.Content = "Tilbake";
            }
        }
 * 
 * 
 * 
 * 
 * 
 * 
 */