using kolokwium.Models.DTOs;

namespace kwolokwium.Services;

public interface IDbService
{
    Task<IEnumerable<SomeKindOfAlbum>> GetAlbum(int idAlbum);
    bool DeleteMusician(int idMusician);
}