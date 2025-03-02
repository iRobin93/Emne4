using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using MediaPlayerApp.Data;

namespace MediaPlayerApp.Model
{
    public class Playlist
    {
        private static int _nextPlaylistId = 1;
        public int Id { get; private set; }
        public string Name { get; private set; }
        public ObservableCollection<Song> Songs { get; private set; } = new ObservableCollection<Song>();

        public Playlist(string name, bool createInDb, int id)
        {
            // Id gets replaced with id from database
            Id = id;
            Name = name;
            if(createInDb)
            {
                CreatePlaylistAsync();
            }
        }


        private async Task CreatePlaylistAsync()
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

        public void DeleteSongFromPlaylist(int sortOrder)
        {
            Songs.RemoveAt(sortOrder);
            DeleteSongFromPlaylistInDb(sortOrder);
        }

        private async Task DeleteSongFromPlaylistInDb(int sortOrder)
        {
            var response = await CommonModel.client.DeleteAsync("https://localhost:7034/api/Playlists/" + Id.ToString() + "/delete-song/" + sortOrder.ToString());
        }
    }


}
