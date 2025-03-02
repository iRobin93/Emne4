using MediaPlayerBackend.Model;
using MediaPlayerBackend;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Collections.Generic;

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
        // Get playlists ordered by Playlist.Name, along with their associated SongIds ordered by PlaylistSong.Id
        var playlists = await _context.Playlists
            .OrderBy(p => p.Name)  // Order playlists by Playlist.Name
            .Select(p => new
            {
                Playlist = p,  // Keep the full Playlist object
                SongIds = _context.PlaylistSongs
                    .Where(ps => ps.PlaylistId == p.Id)
                    .OrderBy(ps => ps.SortOrder)  // Order songs within playlist by PlaylistSong.Id
                    .Select(ps => ps.SongId)  // Select only the SongIds
                    .ToList()  // Collect SongIds
            })
            .ToListAsync();


        return Ok(playlists);
    }

    [HttpPost]
    public async Task<ActionResult<Playlist>> CreatePlaylist(Playlist playlist)
    {
        _context.Playlists.Add(playlist);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetPlaylists), new { id = playlist.Id }, playlist);
    }

    [HttpPost("{playlistId}/add-song/{songId}/{sortOrder}")]
    public async Task<IActionResult> AddSongToPlaylist(int playlistId, int songId, int sortOrder)
    {
        var playlistSong = new PlaylistSong
        {
            PlaylistId = playlistId,
            SongId = songId,
            SortOrder = sortOrder
        };

        _context.PlaylistSongs.Add(playlistSong);

        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{playlistId}/delete-song/{sortOrder}")]
    public async Task<IActionResult> DeleteSongFromPlaylist(int playlistId, int sortOrder)
    {
        var playlistSong = await _context.PlaylistSongs
                                             .FirstOrDefaultAsync(ps => ps.PlaylistId == playlistId && ps.SortOrder == sortOrder);
        _context.PlaylistSongs.Remove(playlistSong);
        
        await _context.SaveChangesAsync();

        await _context.Database.ExecuteSqlRawAsync(
        "UPDATE PlaylistSongs SET SortOrder = SortOrder - 1 WHERE PlaylistId = {0} AND SortOrder > {1}",
        playlistId, sortOrder);

        return NoContent();
    }
}