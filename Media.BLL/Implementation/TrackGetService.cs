using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Media.BLL.Contracts;
using Media.DataAccess.Contracts;
using Media.Domain;
using Media.Domain.Contracts;

namespace Media.BLL.Implementation
{
    public class TrackGetService : ITrackGetService
    {
        private ITrackDataAccess TrackDataAccess { get; }
        
        public TrackGetService(ITrackDataAccess trackDataAccess)
        {
            this.TrackDataAccess = trackDataAccess;
        }
        public Task<IEnumerable<Track>> GetAsync()
        {
            return this.TrackDataAccess.GetAsync();
        }

        public Task<Track> GetAsync(ITrackIdentity track)
        {
            return this.TrackDataAccess.GetAsync(track);
        }

        public async Task ValidateAsync(ITrackContainer trackContainer)
        {
            if (trackContainer == null)
            {
                throw new ArgumentNullException(nameof(trackContainer));
            }
            
            var album = await this.GetBy(trackContainer);

            if (trackContainer.TrackId.HasValue && album == null)
            {
                throw new InvalidOperationException($"Album not found by id {trackContainer.TrackId}");
            }
        }
        private Task<Track> GetBy(ITrackContainer departmentContainer)
        {
            return this.TrackDataAccess.GetByAsync(departmentContainer);
        }
    }
}