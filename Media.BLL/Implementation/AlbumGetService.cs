using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Media.BLL.Contracts;
using Media.DataAccess.Contracts;
using Media.DataAccess.Entities;
using Media.Domain.Contracts;
using Album = Media.Domain.Album;

namespace Media.BLL.Implementation
{
    public class AlbumGetService : IAlbumGetService
    {
        private IAlbumDataAccess AlbumDataAccess { get; }
        
        public AlbumGetService(IAlbumDataAccess albumDataAccess)
        {
            this.AlbumDataAccess = albumDataAccess;
        }
        public Task<IEnumerable<Album>> GetAsync()
        {
            return this.AlbumDataAccess.GetAsync();
        }
        
        public Task<Album> GetAsync(IAlbumIdentity album)
        {
            return this.AlbumDataAccess.GetAsync(album);
        }

        public async Task ValidateAsync(IAlbumContainer albumContainer)
        {
            if (albumContainer == null)
            {
                throw new ArgumentNullException(nameof(albumContainer));
            }
            
            var album = await this.GetBy(albumContainer);

            if (albumContainer.AlbumId.HasValue && album == null)
            {
                throw new InvalidOperationException($"Album not found by id {albumContainer.AlbumId}");
            }
        }
        private Task<Album> GetBy(IAlbumContainer albumContainer)
        {
            return this.AlbumDataAccess.GetByAsync(albumContainer);
        }
    }
}