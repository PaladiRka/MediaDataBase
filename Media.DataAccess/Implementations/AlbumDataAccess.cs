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
using Album = Media.Domain.Album;


namespace Media.DataAccess.Implementations
{
    public class AlbumDataAccess : IAlbumDataAccess
    {
        private AlbumContext Context { get; }
        private IMapper Mapper { get; }

        public AlbumDataAccess(AlbumContext context, IMapper mapper)
        {
            this.Context = context;
            Mapper = mapper;
        }

        public async Task<Album> InsertAsync(AlbumUpdateModel album)
        {
            var result = await this.Context.AddAsync(this.Mapper.Map<DataAccess.Entities.Album>(album));

            await this.Context.SaveChangesAsync();

            return this.Mapper.Map<Album>(result.Entity);
        }

        public async Task<IEnumerable<Album>> GetAsync()
        {
            return this.Mapper.Map<IEnumerable<Album>>(
                await this.Context.Album.ToListAsync());

        }

        public async Task<Album> GetAsync(IAlbumIdentity album)
        {
            var result = await this.Get(album);

            return this.Mapper.Map<Album>(result);
        }

        public async Task<Album> UpdateAsync(AlbumUpdateModel album)
        {
            var existing = await this.Get(album);

            var result = this.Mapper.Map(album, existing);

            this.Context.Update(result);

            await this.Context.SaveChangesAsync();

            return this.Mapper.Map<Album>(result);
        }

        public async Task<Album> GetByAsync(IAlbumContainer album)
        {
            return album.AlbumId.HasValue 
                ? this.Mapper.Map<Album>(await this.Context.Album.FirstOrDefaultAsync(x => x.Id == album.AlbumId)) 
                : null;
        }

        private async Task<Media.DataAccess.Entities.Album> Get(IAlbumIdentity album)
        {
          
            if(album == null)
                throw new ArgumentNullException(nameof(album));
            return await this.Context.Album.FirstOrDefaultAsync(x => x.Id == album.Id);
        }
    }
}