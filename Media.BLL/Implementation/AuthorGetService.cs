using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Media.BLL.Contracts;
using Media.DataAccess.Contracts;
using Media.DataAccess.Entities;
using Media.Domain.Contracts;
using Author = Media.Domain.Author;

namespace Media.BLL.Implementation
{
    public class AuthorGetService : IAuthorGetService
    {
        private IAuthorDataAccess AuthorDataAccess { get; }
        
        public AuthorGetService(IAuthorDataAccess authorDataAccess)
        {
            this.AuthorDataAccess = authorDataAccess;
        }
        public Task<IEnumerable<Author>> GetAsync()
        {
            return this.AuthorDataAccess.GetAsync();
        }
        
        public Task<Author> GetAsync(IAuthorIdentity author)
        {
            return this.AuthorDataAccess.GetAsync(author);
        }

        public async Task ValidateAsync(IAuthorContainer authorContainer)
        {
            if (authorContainer == null)
            {
                throw new ArgumentNullException(nameof(authorContainer));
            }
            
            var author = await this.GetBy(authorContainer);

            if (authorContainer.AuthorId.HasValue && author == null)
            {
                throw new InvalidOperationException($"Author not found by id {authorContainer.AuthorId}");
            }
        }
        private Task<Author> GetBy(IAuthorContainer authorContainer)
        {
            return this.AuthorDataAccess.GetByAsync(authorContainer);
        }
    }
}