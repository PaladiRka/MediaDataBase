using Media.Domain.Contracts;

namespace Media.Domain.Models
{
    public class AlbumIdentityModel : IAlbumIdentity
    {
        public int Id { get; }

        public AlbumIdentityModel(int id)
        {
            this.Id = id;
        }
    }
}