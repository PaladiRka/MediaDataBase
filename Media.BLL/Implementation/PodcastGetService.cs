using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Media.BLL.Contracts;
using Media.DataAccess.Contracts;
using Media.Domain;
using Media.Domain.Contracts;

namespace Media.BLL.Implementation
{
    public class PodcastGetService : IPodcastGetService
    {
        private IPodcastDataAccess PodcastDataAccess { get; }
        
        public PodcastGetService(IPodcastDataAccess podcastDataAccess)
        {
            this.PodcastDataAccess = podcastDataAccess;
        }
        public Task<IEnumerable<Podcast>> GetAsync()
        {
            return this.PodcastDataAccess.GetAsync();
        }

        public Task<Podcast> GetAsync(IPodcastIdentity podcast)
        {
            return this.PodcastDataAccess.GetAsync(podcast);
        }

        public async Task ValidateAsync(IPodcastContainer podcastContainer)
        {
            if (podcastContainer == null)
            {
                throw new ArgumentNullException(nameof(podcastContainer));
            }
            
            var album = await this.GetBy(podcastContainer);

            if (podcastContainer.PodcastId.HasValue && album == null)
            {
                throw new InvalidOperationException($"Album not found by id {podcastContainer.PodcastId}");
            }
        }
        private Task<Podcast> GetBy(IPodcastContainer departmentContainer)
        {
            return this.PodcastDataAccess.GetByAsync(departmentContainer);
        }
    }
}