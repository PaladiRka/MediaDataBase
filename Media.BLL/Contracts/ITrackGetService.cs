using System.Collections.Generic;
using System.Threading.Tasks;
using Media.Domain;
using Media.Domain.Contracts;

namespace Media.BLL.Contracts
{
    public interface ITrackGetService
    {
        Task<IEnumerable<Track>> GetAsync();
        Task<Track> GetAsync(ITrackIdentity track);
        Task ValidateAsync(ITrackContainer departmentContainer);
    }
}