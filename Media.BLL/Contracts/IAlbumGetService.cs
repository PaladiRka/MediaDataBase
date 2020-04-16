using System.Collections.Generic;
using System.Threading.Tasks;
using Media.Domain;
using Media.Domain.Contracts;

namespace Media.BLL.Contracts
{
    public interface IAlbumGetService
    {
        Task<IEnumerable<Album>> GetAsync();
        Task<Album> GetAsync(IAlbumIdentity album);
        Task ValidateAsync(IAlbumContainer departmentContainer);
    }
}