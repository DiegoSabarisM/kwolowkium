using kolokwium.Models.DTOs;
using kwolokwium.Controllers;
using kwolokwium.Models;
using Microsoft.EntityFrameworkCore;

namespace kwolokwium.Services;

public class DbService : IDbService
{
    private readonly MainDbContext _context;
    private IDbService _dbServiceImplementation;

    public DbService(MainDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<SomeKindOfAlbum>> GetAlbum(int idAlbum)
    {
        return await _context.Albums.Where(a => a.IdAlbum == idAlbum)
            .Select(a => new SomeKindOfAlbum
            {
                idAlbum = a.IdAlbum,
                AlbumName = a.AlbumName,
                PublishDate = a.PublishDate,
                MusicLabel= new MusicLabel {
                    IdMusicLabel = a.MusicLabel.IdMusicLabel,
                    Name = a.MusicLabel.Name
                },
                Tracks= a.Tracks.Select(t => new SomeKindOfTrack()
                {
                    IdTrack = t.IdTrack,
                    TrackName = t.TrackName,
                    Duration = t.Duration,
                    IdMusicAlbum = t.IdMusicAlbum
                   
                })
            }).OrderBy(a => a.PublishDate).ToListAsync();
    }

    public bool DeleteMusician(int idMusician)
    {
        
        var Musician = _context.Musicians.Where(m => m.IdMusician == idMusician).FirstOrDefault();
        _context.Attach(Musician);
        _context.Remove(Musician);
        
        return true;
    }

   

}