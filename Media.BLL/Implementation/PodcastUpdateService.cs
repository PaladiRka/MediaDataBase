using System.Threading.Tasks;
using Media.BLL.Contracts;
using Media.DataAccess.Contracts;
using Media.Domain;
using Media.Domain.Models;

namespace Media.BLL.Implementation
{
    public class PodcastUpdateService : IPodcastUpdateService
    {
        private IPodcastDataAccess PodcastDataAccess { get; }
        private IAlbumGetService AlbumGetService { get; }

        public PodcastUpdateService(IPodcastDataAccess podcastDataAccess, IAlbumGetService albumGetService)
        {
            PodcastDataAccess = podcastDataAccess;
            AlbumGetService = albumGetService;
        }

        public async Task<Podcast> UpdateAsync(PodcastUpdateModel podcast)
        {
            await AlbumGetService.ValidateAsync(podcast);
            return await PodcastDataAccess.UpdateAsync(podcast);

        }
    }
}