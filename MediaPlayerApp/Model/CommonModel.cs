using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MediaPlayerApp.Model
{
    public static class CommonModel
    {
        public static readonly HttpClient client = new HttpClient();

        public static async Task AddSongToPlaylistInDb(Song song, Playlist _selectedPlaylist, int sortOrder)
        {
            var response = await CommonModel.client.PostAsync("https://localhost:7034/api/Playlists/" + _selectedPlaylist.Id.ToString() + "/add-song/" + song.Id.ToString() + "/" + sortOrder, null);
            var responseContent = await response.Content.ReadAsStringAsync();
        }
        public static async void DeleteSongFromDb(Song song)
        {
            var response = await CommonModel.client.DeleteAsync("https://localhost:7034/api/Songs/" + song.Id.ToString());
            var responseContent = await response.Content.ReadAsStringAsync();
        }


    }
}
