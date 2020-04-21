using System.Collections.Generic;
using System.Threading.Tasks;
using Media.Domain;
using Media.Domain.Contracts;

namespace Media.BLL.Contracts
{
    public interface IPodcastGetService
    {
        Task<IEnumerable<Podcast>> GetAsync();
        Task<Podcast> GetAsync(IPodcastIdentity podcast);
        Task ValidateAsync(IPodcastContainer departmentContainer);
    }
}