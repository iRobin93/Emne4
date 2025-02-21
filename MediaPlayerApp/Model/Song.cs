using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaPlayerApp.Model
{
    public class Song : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private static int _nextSongId = 1;
        private int Id { get; set; }
        public string Artist { get; private set; }
        private string Title { get; set; }
        public string FilePath { get; private set; }
        public string title
        {
            get => Title;
            set
            {
                if (Title != value)
                {
                    Title = value;
                    OnPropertyChanged(nameof(title)); // Notify UI about the change
                }
            }
        }

        public Song(string title, string artist, string filepath)
        {
            Id = _nextSongId++;
            Artist = artist;
            Title = title;
            FilePath = filepath;
        }



        // This method is called to raise the PropertyChanged event
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
