using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Media.DataAccess.Context;
using Media.DataAccess.Contracts;
using Media.DataAccess.Entities;
using Media.Domain.Contracts;
using Media.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Track = Media.Domain.Track;

namespace Media.DataAccess.Implementations
{
    public class TrackDataAccess : ITrackDataAccess
    {
        private AlbumContext Context { get; }
        private IMapper Mapper { get; }

        public TrackDataAccess(AlbumContext context, IMapper mapper)
        {
            this.Context = context;
            Mapper = mapper;
        }

        public async Task<Track> InsertAsync(TrackUpdateModel track)
        {
            var result = await this.Context.AddAsync(this.Mapper.Map<DataAccess.Entities.Track>(track));
            await this.Context.SaveChangesAsync();
            return this.Mapper.Map<Track>(result.Entity);
        }

        public async Task<IEnumerable<Track>> GetAsync()
        {
            return this.Mapper.Map<IEnumerable<Track>>(
                await this.Context.Track.Include(x => x.Album).ToListAsync());

        }

        public async Task<Track> GetAsync(ITrackIdentity trackId)
        {
            var result = await this.Get(trackId);
            return this.Mapper.Map<Track>(result);
        }

        public async Task<Track> UpdateAsync(TrackUpdateModel track)
        {
            var existing = await this.Get(track);

            var result = this.Mapper.Map(track, existing);

            this.Context.Update(result);

            await this.Context.SaveChangesAsync();

            return this.Mapper.Map<Track>(result);
        }

        public async Task<Track> GetByAsync(ITrackContainer track)
        {
            return track.TrackId.HasValue 
                ? this.Mapper.Map<Track>(await this.Context.Track.FirstOrDefaultAsync(x => x.Id == track.TrackId)) 
                : null;
        }

        private async Task<Media.DataAccess.Entities.Track> Get(ITrackIdentity trackId)
        {
            if(trackId == null)
                throw new ArgumentNullException(nameof(trackId));
            return await this.Context.Track.Include(x => x.Album).FirstOrDefaultAsync(x => x.Id == trackId.Id);
        }
    }
}