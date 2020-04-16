using System.Threading.Tasks;
using Media.BLL.Contracts;
using Media.DataAccess.Contracts;
using Media.DataAccess.Implementations;
using Media.Domain;
using Media.Domain.Models;

namespace Media.BLL.Implementation
{
    public class TrackCreateService : ITrackCreateService
    {
        private ITrackDataAccess TrackDataAccess { get; }

        public TrackCreateService(ITrackDataAccess albumDataAccess)
        {
            TrackDataAccess = albumDataAccess;
        }

        public Task<Track> CreateAsync(TrackUpdateModel track)
        {
            return TrackDataAccess.InsertAsync(track);

        }
    }
}