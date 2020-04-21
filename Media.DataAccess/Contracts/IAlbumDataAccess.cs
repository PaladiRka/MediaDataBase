using System.Collections.Generic;
using System.Threading.Tasks;
using Media.DataAccess.Entities;
using Media.Domain;
using Media.Domain.Contracts;
using Media.Domain.Models;
using Album = Media.Domain.Album;

namespace Media.DataAccess.Contracts
{
    public interface IAlbumDataAccess
    {
        Task<Album> InsertAsync(AlbumUpdateModel album);
        Task<IEnumerable<Album>> GetAsync();
        Task<Album> GetAsync(IAlbumIdentity albumId);
        Task<Album> UpdateAsync(AlbumUpdateModel album);
        Task<Album> GetByAsync(IAlbumContainer departmentId);
    }
}