using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaPlayerApp.Model;

namespace MediaPlayerApp.Data
{
    static public class Songs
    {
        public static ObservableCollection<Song> AllSongs { get; private set; } = new ObservableCollection<Song>();

        static Songs()
        {
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
