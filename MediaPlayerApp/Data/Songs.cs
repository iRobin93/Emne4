using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MediaPlayerApp.Model;
using Newtonsoft.Json;

namespace MediaPlayerApp.Data
{
    static public class Songs
    {
        public static ObservableCollection<Song> AllSongs { get; private set; } = new ObservableCollection<Song>();

     
        public async static void InitializeSongs()
        {

            await GetSongsFromDb();
            string userProfile = Environment.GetEnvironmentVariable("USERPROFILE");
            // Check if the directory exists
            if (Directory.Exists(userProfile + "\\Documents\\Music"))
            {
                // Get all files in the folder
                string[] files = Directory.GetFiles(userProfile + "\\Documents\\Music");

                // Filter and add only audio files (you can extend this list as needed)
                foreach (var file in files)
                {
                    // Create a FileInfo object for each file
                    
                    string extension = Path.GetExtension(file).ToLower();
                    
                    
                    if (extension == ".mp3" || extension == ".m4a") // add more formats as needed
                    {
                        FileInfo fileInfo = new FileInfo(file);
                        var tagFile = TagLib.File.Create(fileInfo.FullName);
                        Song song = new Song(tagFile.Tag.Title, tagFile.Tag.FirstPerformer, fileInfo.FullName);
                    }
                }
            }
            else
            {
                Console.WriteLine("The specified folder does not exist.");
            }
        }

        public static async Task GetSongsFromDb()
        {
            // Make a GET request to the API endpoint
            HttpResponseMessage response = await CommonModel.client.GetAsync("https://localhost:7034/api/Songs");

            if (response.IsSuccessStatusCode)
            {
                // Read the response content as a string
                string jsonResponse = await response.Content.ReadAsStringAsync();

                // Deserialize the JSON response into a list of Song objects using Newtonsoft.Json
                AllSongs = (ObservableCollection<Song>)JsonConvert.DeserializeObject<IEnumerable<Song>>(jsonResponse);

            }
            else
            {
                // Handle the error if the request is not successful
                throw new Exception("Error retrieving songs from API");
            }
        }

        public static void AddSong(Song song)
        {
            AllSongs.Add(song);
        }

        public static void DeleteSong(Song song)
        {
            AllSongs.Remove(song);
            Playlists.DeleteSongFromAllPlaylists(song);
        }

    }
}
