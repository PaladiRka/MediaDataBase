using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Media.DataAccess.Context;
using Media.DataAccess.Contracts;
using Media.Domain;
using Media.Domain.Contracts;
using Media.Domain.Models;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Media.DataAccess.Entities;
using Author = Media.Domain.Author;

namespace Media.DataAccess.Implementations
{
    public class AuthorDataAccess : IAuthorDataAccess
    {
        private AlbumContext Context { get; }
        private IMapper Mapper { get; }

        public AuthorDataAccess(AlbumContext context, IMapper mapper)
        {
            this.Context = context;
            Mapper = mapper;
        }

        public async Task<Author> InsertAsync(AuthorUpdateModel author)
        {
            var result = await this.Context.AddAsync(this.Mapper.Map<DataAccess.Entities.Author>(author));
            await this.Context.SaveChangesAsync();
            return this.Mapper.Map<Author>(result.Entity);
        }

        public async Task<IEnumerable<Author>> GetAsync()
        {
            return this.Mapper.Map<IEnumerable<Author>>(
                await this.Context.Author.ToListAsync());

        }

        public async Task<Author> GetAsync(IAuthorIdentity author)
        {
            var result = await this.Get(author);
            return this.Mapper.Map<Author>(result);
        }

        public async Task<Author> UpdateAsync(AuthorUpdateModel author)
        {
            var existing = await this.Get(author);

            var result = this.Mapper.Map(author, existing);

            this.Context.Update(result);

            await this.Context.SaveChangesAsync();

            return this.Mapper.Map<Author>(result);
        }

        public async Task<Author> GetByAsync(IAuthorContainer author)
        {
            return author.AuthorId.HasValue 
                ? this.Mapper.Map<Author>(await this.Context.Author.FirstOrDefaultAsync(x => x.Id == author.AuthorId)) 
                : null;
        }

        private async Task<Media.DataAccess.Entities.Author> Get(IAuthorIdentity author)
        {
            if(author == null)
                throw new ArgumentNullException(nameof(author));
            return await this.Context.Author.FirstOrDefaultAsync(x => x.Id == author.Id);
        }
    }
}