using MediaPlayerBackend.Model;
using Microsoft.EntityFrameworkCore;

namespace MediaPlayerBackend
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Song> Songs { get; set; }
        public DbSet<Playlist> Playlists { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Playlist>()
                .HasMany(p => p.Songs)
                .WithMany()
                .UsingEntity<Dictionary<string, object>>(
                    "PlaylistSongs",
                    j => j.HasOne<Song>().WithMany().HasForeignKey("SongId"),
                    j => j.HasOne<Playlist>().WithMany().HasForeignKey("PlaylistId")
                );
        }
    }
}
