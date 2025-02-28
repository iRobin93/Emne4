using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using MediaPlayerApp.Data;
using MediaPlayerApp.Windows;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MediaPlayerApp.Model
{
    public class Song : INotifyPropertyChanged
    {


        private static int _nextSongId = 1;
        public event PropertyChangedEventHandler PropertyChanged;
        
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

        public Song(string title, string artist, string filepath, bool CreateInDb)
        {
            Id = _nextSongId++;
            Artist = artist;
            Title = title;
            FilePath = filepath;
            if(CreateInDb)
                CreateSongAsync(this);
            Songs.AddSong(this);

        }

        public async Task CreateSongAsync(Song song)
        {
            var json = JsonConvert.SerializeObject(song);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await CommonModel.client.PostAsync("https://localhost:7034/api/Songs", content);
            var responseContent = await response.Content.ReadAsStringAsync();
            JObject jsonObject = JObject.Parse(responseContent);
            song.Id = jsonObject["id"].Value<int>();
            response.EnsureSuccessStatusCode();

        }

        // This method is called to raise the PropertyChanged event
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
