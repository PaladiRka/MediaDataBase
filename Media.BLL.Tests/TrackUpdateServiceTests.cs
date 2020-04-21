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
    public class TrackUpdateServiceTest
    {
        [Test]
        public async Task UpdateAsync_TrackValidationSucceed_CreatesScreening()
        {
            // Arrange
            var track = new TrackUpdateModel();
            var expected = new Track();
            
            var albumGetService = new Mock<IAlbumGetService>();
            albumGetService.Setup(x => x.ValidateAsync(track));
            
            var trackDataAccess = new Mock<ITrackDataAccess>();
            trackDataAccess.Setup(x => x.UpdateAsync(track)).ReturnsAsync(expected);
            
            var trackGetService = new TrackUpdateService(trackDataAccess.Object, albumGetService.Object);
            
            // Act
            var result = await trackGetService.UpdateAsync(track);
            
            // Assert
            result.Should().Be(expected);
        }
        
        [Test]
        public async Task UpdateAsync_TrackValidationFailed_ThrowsError()
        {
            // Arrange
            var fixture = new Fixture();
            var track = new TrackUpdateModel();
            var expected = fixture.Create<string>();
            
            var albumGetService = new Mock<IAlbumGetService>();
            albumGetService
                .Setup(x => x.ValidateAsync(track))
                .Throws(new InvalidOperationException(expected));
            
            var trackDataAccess = new Mock<ITrackDataAccess>();
            var trackGetService = new TrackUpdateService(trackDataAccess.Object, albumGetService.Object);
            
            // Act
            var action = new Func<Task>(() => trackGetService.UpdateAsync(track));
            
            // Assert
            await action.Should().ThrowAsync<InvalidOperationException>().WithMessage(expected);
            trackDataAccess.Verify(x => x.UpdateAsync(track), Times.Never);
        }
    }
}