namespace MediaPlayerBackend.Model
{
    public class PlaylistSong
    {
        public int Id { get; set; }
        public int PlaylistId { get; set; }
        public int SongId { get; set; }
        public int SortOrder { get; set; }
        // Navigation properties
        public Playlist Playlist { get; set; }
        public Song Song { get; set; }
    }
}
