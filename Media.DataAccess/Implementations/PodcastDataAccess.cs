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
using Podcast = Media.Domain.Podcast;

namespace Media.DataAccess.Implementations
{
    public class PodcastDataAccess : IPodcastDataAccess
    {
        private AlbumContext Context { get; }
        private IMapper Mapper { get; }

        public PodcastDataAccess(AlbumContext context, IMapper mapper)
        {
            this.Context = context;
            Mapper = mapper;
        }

        public async Task<Podcast> InsertAsync(PodcastUpdateModel podcast)
        {
            var result = await this.Context.AddAsync(this.Mapper.Map<DataAccess.Entities.Podcast>(podcast));
            await this.Context.SaveChangesAsync();
            return this.Mapper.Map<Podcast>(result.Entity);
        }

        public async Task<IEnumerable<Podcast>> GetAsync()
        {
            return this.Mapper.Map<IEnumerable<Podcast>>(
                await this.Context.Podcast.Include(x => x.Album).ToListAsync());

        }

        public async Task<Podcast> GetAsync(IPodcastIdentity podcastId)
        {
            var result = await this.Get(podcastId);
            return this.Mapper.Map<Podcast>(result);
        }

        public async Task<Podcast> UpdateAsync(PodcastUpdateModel podcast)
        {
            var existing = await this.Get(podcast);

            var result = this.Mapper.Map(podcast, existing);

            this.Context.Update(result);

            await this.Context.SaveChangesAsync();

            return this.Mapper.Map<Podcast>(result);
        }

        public async Task<Podcast> GetByAsync(IPodcastContainer podcast)
        {
            return podcast.PodcastId.HasValue 
                ? this.Mapper.Map<Podcast>(await this.Context.Podcast.FirstOrDefaultAsync(x => x.Id == podcast.PodcastId)) 
                : null;
        }

        private async Task<Media.DataAccess.Entities.Podcast> Get(IPodcastIdentity podcastId)
        {
            if(podcastId == null)
                throw new ArgumentNullException(nameof(podcastId));
            return await this.Context.Podcast.Include(x => x.Album).FirstOrDefaultAsync(x => x.Id == podcastId.Id);
        }
    }
}