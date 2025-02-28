using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MediaPlayerApp.Model;
using Newtonsoft.Json;

namespace MediaPlayerApp.Data
{
    static public class Playlists
    {
        public static ObservableCollection<Playlist> playlists = new ObservableCollection<Playlist>();

 
        public static void AddPlaylist(Playlist playlist)
        {
            playlists.Add(playlist);
        }

        public async static Task InitializePlaylists()
        {
            await GetPlaylistsFromDatabase();
        }

        public static async Task GetPlaylistsFromDatabase()
        {
            // Make a GET request to the API endpoint
            HttpResponseMessage response = await CommonModel.client.GetAsync("https://localhost:7034/api/Playlists");

            if (response.IsSuccessStatusCode)
            {
                // Read the response content as a string
                string jsonResponse = await response.Content.ReadAsStringAsync();

                // Deserialize the JSON response into a list of Song objects using Newtonsoft.Json
                playlists = new ObservableCollection<Playlist>(JsonConvert.DeserializeObject<IEnumerable<Playlist>>(jsonResponse));

            }
            else
            {
                // Handle the error if the request is not successful
                throw new Exception("Error retrieving playlists from API");
            }
        }

        public static void DeleteSongFromAllPlaylists(Song song)
        {
            foreach (var playlist in playlists)
            {
                playlist.Songs.Remove(song);
            }
        }
    }

}
