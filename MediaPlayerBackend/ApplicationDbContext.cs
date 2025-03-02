using MediaPlayerBackend.Model;
using Microsoft.EntityFrameworkCore;

namespace MediaPlayerBackend
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Song> Songs { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<PlaylistSong> PlaylistSongs { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the Id as an identity column
            modelBuilder.Entity<PlaylistSong>()
                .Property(ps => ps.Id)
                .ValueGeneratedOnAdd();

            // Define the composite primary key on PlaylistSong (junction table)
            modelBuilder.Entity<PlaylistSong>()
                .HasKey(ps => new { ps.PlaylistId, ps.SongId, ps.Id });

            // Define the many-to-many relationship between Playlist and Song using PlaylistSong
            modelBuilder.Entity<PlaylistSong>()
                .HasOne(ps => ps.Playlist)
                .WithMany()  // Playlist has many PlaylistSongs (implicitly)
                .HasForeignKey(ps => ps.PlaylistId);

            modelBuilder.Entity<PlaylistSong>()
                .HasOne(ps => ps.Song)
                .WithMany()  // Song can appear in many Playlists (implicitly)
                .HasForeignKey(ps => ps.SongId);

            modelBuilder.Entity<Playlist>()
            .Ignore(p => p.Songs);  // Remove the List<Song> property from the model


        }

    }
}
