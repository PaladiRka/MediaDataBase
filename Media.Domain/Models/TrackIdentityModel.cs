using Media.Domain.Contracts;

namespace Media.Domain.Models
{
    public class TrackIdentityModel : ITrackIdentity
    {
        public int Id { get; }

        public TrackIdentityModel(int id)
        {
            this.Id = id;
        }
    }
}