using Media.Domain.Contracts;

namespace Media.Domain.Models
{
    public class PodcastIdentityModel : IPodcastIdentity
    {
        public int Id { get; }

        public PodcastIdentityModel(int id)
        {
            this.Id = id;
        }
    }
}