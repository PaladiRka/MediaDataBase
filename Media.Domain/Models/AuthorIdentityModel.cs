using Media.Domain.Contracts;

namespace Media.Domain.Models
{
    public class AuthorIdentityModel : IAuthorIdentity
    {
        public int Id { get; }

        public AuthorIdentityModel(int id)
        {
            this.Id = id;
        }
    }
}