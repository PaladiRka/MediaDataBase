using System.Threading.Tasks;
using Media.BLL.Contracts;
using Media.DataAccess.Contracts;
using Media.Domain;
using Media.Domain.Models;

namespace Media.BLL.Implementation
{
    public class AlbumUpdateService : IAlbumUpdateService
    {
        private IAlbumDataAccess AlbumDataAccess { get; }

        public AlbumUpdateService(IAlbumDataAccess albumDataAccess)
        {
            albumDataAccess = AlbumDataAccess;
        }

        public Task<Album> UpdateAsync(AlbumUpdateModel album)
        {
            return AlbumDataAccess.UpdateAsync(album);
        }
    }
}