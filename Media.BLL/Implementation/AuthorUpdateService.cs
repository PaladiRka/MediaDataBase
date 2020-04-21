using System.Threading.Tasks;
using Media.BLL.Contracts;
using Media.DataAccess.Contracts;
using Media.Domain;
using Media.Domain.Models;

namespace Media.BLL.Implementation
{
    public class AuthorUpdateService : IAuthorUpdateService
    {
        private IAuthorDataAccess AuthorDataAccess { get; }

        public AuthorUpdateService(IAuthorDataAccess authorDataAccess)
        {
            authorDataAccess = AuthorDataAccess;
        }

        public Task<Author> UpdateAsync(AuthorUpdateModel author)
        {
            return AuthorDataAccess.UpdateAsync(author);
        }
    }
}