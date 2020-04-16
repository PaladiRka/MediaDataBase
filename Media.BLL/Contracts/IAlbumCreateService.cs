using System.Threading.Tasks;
using Media.Domain;
using Media.Domain.Models;

namespace Media.BLL.Contracts
{
    public interface IAlbumCreateService
    {
        Task<Album> CreateAsync(AlbumUpdateModel album);
    }
}