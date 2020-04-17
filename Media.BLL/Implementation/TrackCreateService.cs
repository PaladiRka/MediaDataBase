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
        private IAlbumGetService AlbumGetService { get; }

        public TrackCreateService(ITrackDataAccess trackDataAccess, IAlbumGetService albumGetService)
        {
            TrackDataAccess = trackDataAccess;
            AlbumGetService = albumGetService;
        }

        public async Task<Track> CreateAsync(TrackUpdateModel track)
        {
            await AlbumGetService.ValidateAsync(track);
            return await TrackDataAccess.InsertAsync(track);

        }
    }
}