using MediaPlayerBackend.Model;
using MediaPlayerBackend;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class PlaylistsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public PlaylistsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/Playlists
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Playlist>>> GetPlaylists()
    {
        return await _context.Playlists.Include(p => p.Songs).ToListAsync();
    }

    // POST: api/Playlists
    [HttpPost]
    public async Task<ActionResult<Playlist>> PostPlaylist(Playlist playlist)
    {
        _context.Playlists.Add(playlist);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetPlaylists), new { id = playlist.PlaylistId }, playlist);
    }

    // POST: api/Playlists/AddSongToPlaylist
    [HttpPost("AddSongToPlaylist")]
    public async Task<ActionResult> AddSongToPlaylist(int playlistId, int songId)
    {
        var playlistSong = new PlaylistSong
        {
            PlaylistId = playlistId,
            SongId = songId
        };
        _context.PlaylistSongs.Add(playlistSong);
        await _context.SaveChangesAsync();
        return Ok();
    }
}