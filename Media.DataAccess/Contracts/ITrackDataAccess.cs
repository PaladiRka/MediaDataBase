using System.Collections.Generic;
using System.Threading.Tasks;
using Media.DataAccess.Entities;
using Media.Domain;
using Media.Domain.Contracts;
using Media.Domain.Models;
using Track = Media.Domain.Track;

namespace Media.DataAccess.Contracts
{
    public interface ITrackDataAccess
    {
        Task<Track> InsertAsync(TrackUpdateModel movie);
        Task<IEnumerable<Track>> GetAsync();
        Task<Track> GetAsync(ITrackIdentity movieId);
        Task<Track> UpdateAsync(TrackUpdateModel movie);
        Task<Track> GetByAsync(ITrackContainer movie);
    }
}