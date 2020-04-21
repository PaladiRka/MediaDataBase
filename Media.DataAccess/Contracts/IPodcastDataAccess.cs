using System.Collections.Generic;
using System.Threading.Tasks;
using Media.DataAccess.Entities;
using Media.Domain;
using Media.Domain.Contracts;
using Media.Domain.Models;
using Podcast = Media.Domain.Podcast;

namespace Media.DataAccess.Contracts
{
    public interface IPodcastDataAccess
    {
        Task<Podcast> InsertAsync(PodcastUpdateModel movie);
        Task<IEnumerable<Podcast>> GetAsync();
        Task<Podcast> GetAsync(IPodcastIdentity movieId);
        Task<Podcast> UpdateAsync(PodcastUpdateModel movie);
        Task<Podcast> GetByAsync(IPodcastContainer movie);
    }
}