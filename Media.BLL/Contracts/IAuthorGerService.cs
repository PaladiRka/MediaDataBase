using System.Collections.Generic;
using System.Threading.Tasks;
using Media.Domain;
using Media.Domain.Contracts;

namespace Media.BLL.Contracts
{
    public interface IAuthorGetService
    {
        Task<IEnumerable<Author>> GetAsync();
        Task<Author> GetAsync(IAuthorIdentity author);
        Task ValidateAsync(IAuthorContainer departmentContainer);
    }
}