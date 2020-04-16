using System.Threading.Tasks;
using Media.BLL.Contracts;
using Media.DataAccess.Contracts;
using Media.Domain;
using Media.Domain.Models;

namespace Media.BLL.Implementation
{
    public class TrackUpdateService : ITrackUpdateService
    {
        private ITrackDataAccess TrackDataAccess { get; }
       // private IAlbumGetService AlbumGetService { get; }

        public TrackUpdateService(ITrackDataAccess albumDataAccess)//, IAlbumGetService albumGetService
        {
            TrackDataAccess = albumDataAccess;
           // AlbumGetService = albumGetService;
        }

        public async Task<Track> UpdateAsync(TrackUpdateModel track)
        {
          //  await AlbumGetService.ValidateAsync(track);
          return await TrackDataAccess.UpdateAsync(track);

        }
    }
}