using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows;

namespace MediaPlayerApp.Model
{
    public class SongToVisibilityConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            // Retrieve the Song object and index from the values array
            var song = values[0] as Song;
            var index = values[1] as int?;

            if (song != null && index.HasValue)
            {
                // Apply your visibility logic based on the index
                System.Diagnostics.Debug.WriteLine($"Index of the song: {index.Value}");

                // Here, you can compare with Player.SongIsPlaying(index.Value)
                return Player.SongIsPlaying(index.Value)
                    ? System.Windows.Visibility.Visible
                    : System.Windows.Visibility.Collapsed;
            }

            return System.Windows.Visibility.Collapsed;
        }

        public object[] ConvertBack(object values, Type[] targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
