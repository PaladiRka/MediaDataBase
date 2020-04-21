using System;
using System.Threading.Tasks;
using Media.BLL.Contracts;
using Media.BLL.Implementation;
using Media.DataAccess.Contracts;
using Media.Domain;
using Media.Domain.Models;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using Ploeh.AutoFixture;
namespace Media.BLL.Tests
{
    public class PodcastUpdateServiceTest
    {
        [Test]
        public async Task UpdateAsync_PodcastValidationSucceed_CreatesScreening()
        {
            // Arrange
            var podcast = new PodcastUpdateModel();
            var expected = new Podcast();
            
            var albumGetService = new Mock<IAlbumGetService>();
            albumGetService.Setup(x => x.ValidateAsync(podcast));
            
            var podcastDataAccess = new Mock<IPodcastDataAccess>();
            podcastDataAccess.Setup(x => x.UpdateAsync(podcast)).ReturnsAsync(expected);
            
            var podcastGetService = new PodcastUpdateService(podcastDataAccess.Object, albumGetService.Object);
            
            // Act
            var result = await podcastGetService.UpdateAsync(podcast);
            
            // Assert
            result.Should().Be(expected);
        }
        
        [Test]
        public async Task UpdateAsync_PodcastValidationFailed_ThrowsError()
        {
            // Arrange
            var fixture = new Fixture();
            var podcast = new PodcastUpdateModel();
            var expected = fixture.Create<string>();
            
            var albumGetService = new Mock<IAlbumGetService>();
            albumGetService
                .Setup(x => x.ValidateAsync(podcast))
                .Throws(new InvalidOperationException(expected));
            
            var podcastDataAccess = new Mock<IPodcastDataAccess>();
            var podcastGetService = new PodcastUpdateService(podcastDataAccess.Object, albumGetService.Object);
            
            // Act
            var action = new Func<Task>(() => podcastGetService.UpdateAsync(podcast));
            
            // Assert
            await action.Should().ThrowAsync<InvalidOperationException>().WithMessage(expected);
            podcastDataAccess.Verify(x => x.UpdateAsync(podcast), Times.Never);
        }
    }
}