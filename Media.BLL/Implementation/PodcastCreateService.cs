using System.Threading.Tasks;
using Media.BLL.Contracts;
using Media.DataAccess.Contracts;
using Media.DataAccess.Implementations;
using Media.Domain;
using Media.Domain.Models;

namespace Media.BLL.Implementation
{
    public class PodcastCreateService : IPodcastCreateService
    {
        private IPodcastDataAccess PodcastDataAccess { get; }
        private IAlbumGetService AlbumGetService { get; }

        public PodcastCreateService(IPodcastDataAccess podcastDataAccess, IAlbumGetService albumGetService)
        {
            PodcastDataAccess = podcastDataAccess;
            AlbumGetService = albumGetService;
        }

        public async Task<Podcast> CreateAsync(PodcastUpdateModel podcast)
        {
            await AlbumGetService.ValidateAsync(podcast);
            return await PodcastDataAccess.InsertAsync(podcast);

        }
    }
}