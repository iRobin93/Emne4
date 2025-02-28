using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace MediaPlayerApp.Model
{
    public class Playlist
    {
        private static int _nextPlaylistId = 1;
        private int Id { get; set; }
        public string Name { get; private set; }
        public ObservableCollection<Song> Songs { get; private set; } = new ObservableCollection<Song>();

        public Playlist(string name, bool createInDb)
        {
            // Id gets replaced with id from database
            Id = _nextPlaylistId++;
            Name = name;
            if(createInDb)
            {
                CreatePlaylistAsync();
            }
        }


        public async Task CreatePlaylistAsync()
        {
            var json = JsonConvert.SerializeObject(this);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await CommonModel.client.PostAsync("https://localhost:7034/api/Playlists", content);
            var responseContent = await response.Content.ReadAsStringAsync();
            JObject jsonObject = JObject.Parse(responseContent);
            this.Id = jsonObject["id"].Value<int>();
            response.EnsureSuccessStatusCode();

        }
        public void AddSong(Song song) 
        {
            Songs.Add(song);
        }

    }


}
