using System.Threading.Tasks;
using Media.BLL.Contracts;
using Media.DataAccess.Contracts;
using Media.DataAccess.Implementations;
using Media.Domain;
using Media.Domain.Models;

namespace Media.BLL.Implementation
{
    public class AuthorCreateService : IAuthorCreateService
    {
        private IAuthorDataAccess AuthorDataAccess { get; }

        public AuthorCreateService(IAuthorDataAccess authorDataAccess)
        {
            AuthorDataAccess = authorDataAccess;
        }

        public Task<Author> CreateAsync(AuthorUpdateModel author)
        {
            return  AuthorDataAccess.InsertAsync(author);

        }
    }
}