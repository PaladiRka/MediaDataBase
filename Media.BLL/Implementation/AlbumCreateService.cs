using System.Threading.Tasks;
using Media.BLL.Contracts;
using Media.DataAccess.Contracts;
using Media.DataAccess.Implementations;
using Media.Domain;
using Media.Domain.Models;

namespace Media.BLL.Implementation
{
    public class AlbumCreateService : IAlbumCreateService
    {
        private IAlbumDataAccess AlbumDataAccess { get; }

        public AlbumCreateService(IAlbumDataAccess albumDataAccess)
        {
            AlbumDataAccess = albumDataAccess;
        }

        public Task<Album> CreateAsync(AlbumUpdateModel album)
        {
            return  AlbumDataAccess.InsertAsync(album);

        }
    }
}