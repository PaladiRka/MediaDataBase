using System;
using System.Threading.Tasks;
using AutoFixture;
using Media.BLL.Implementation;
using Media.DataAccess.Contracts;
using Media.Domain;
using Media.Domain.Contracts;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace Media.BLL.Tests
{
    public class AlbumGetServiceTests
    {
        [Test]
        public async Task ValidateAsync_AlbumExists_DoesNothing()
        {
            // Arrange
            var albumContainer = new Mock<IAlbumContainer>();

            var album = new Album();
            var albumDataAccess = new Mock<IAlbumDataAccess>();
            albumDataAccess.Setup(x => x.GetByAsync(albumContainer.Object)).ReturnsAsync(album);

            var albumGetService = new AlbumGetService(albumDataAccess.Object);
            
            // Act
            var action = new Func<Task>(() => albumGetService.ValidateAsync(albumContainer.Object));
            
            // Assert
            await action.Should().NotThrowAsync<Exception>();
        }
        
        [Test]
        public async Task ValidateAsync_AlbumNotExists_ThrowsError()
        {
            // Arrange
            var fixture = new Fixture();
            var id = fixture.Create<int>();
            
            var albumContainer = new Mock<IAlbumContainer>();
            albumContainer.Setup(x => x.AlbumId).Returns(id);

            var album = new Album();
            var albumDataAccess = new Mock<IAlbumDataAccess>();
            albumDataAccess.Setup(x => x.GetByAsync(albumContainer.Object)).ReturnsAsync((Album)null);

            var albumGetService = new AlbumGetService(albumDataAccess.Object);
            
            // Act
            var action = new Func<Task>(() => albumGetService.ValidateAsync(albumContainer.Object));
            
            // Assert
            await action.Should().ThrowAsync<InvalidOperationException>($"Album not found by id {id}");
        }
    }
}