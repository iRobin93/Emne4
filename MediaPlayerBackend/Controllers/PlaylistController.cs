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

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Playlist>>> GetPlaylists()
    {
        return await _context.Playlists.Include(p => p.Songs).ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<Playlist>> CreatePlaylist(Playlist playlist)
    {
        _context.Playlists.Add(playlist);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetPlaylists), new { id = playlist.Id }, playlist);
    }

    [HttpPost("{playlistId}/add-song/{songId}")]
    public async Task<IActionResult> AddSongToPlaylist(int playlistId, int songId)
    {
        var playlist = await _context.Playlists.Include(p => p.Songs)
                                               .FirstOrDefaultAsync(p => p.Id == playlistId);
        var song = await _context.Songs.FindAsync(songId);

        if (playlist == null || song == null)
            return NotFound();

        playlist.Songs.Add(song);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}