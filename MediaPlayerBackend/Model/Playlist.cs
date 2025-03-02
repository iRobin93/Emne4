namespace MediaPlayerBackend.Model
{
    public class Playlist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Song> Songs { get; set; } = new List<Song>();
    }
}
