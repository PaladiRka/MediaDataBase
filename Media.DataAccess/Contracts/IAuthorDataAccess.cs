using System.Collections.Generic;
using System.Threading.Tasks;
using Media.DataAccess.Entities;
using Media.Domain;
using Media.Domain.Contracts;
using Media.Domain.Models;
using Author = Media.Domain.Author;

namespace Media.DataAccess.Contracts
{
    public interface IAuthorDataAccess
    {
        Task<Author> InsertAsync(AuthorUpdateModel movie);
        Task<IEnumerable<Author>> GetAsync();
        Task<Author> GetAsync(IAuthorIdentity movieId);
        Task<Author> UpdateAsync(AuthorUpdateModel movie);
        Task<Author> GetByAsync(IAuthorContainer movie);
    }
}