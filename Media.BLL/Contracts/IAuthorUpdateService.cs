using System.Threading.Tasks;
using Media.Domain;
using Media.Domain.Models;

namespace Media.BLL.Contracts
{
    public interface IAuthorUpdateService
    {
        Task<Author> UpdateAsync(AuthorUpdateModel author);
    }
}