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
    public class TrackGetServiceTests
    {
        [Test]
        public async Task ValidateAsync_MovieExists_DoesNothing()
        {
            // Arrange
            var departmentContainer = new Mock<ITrackContainer>();

            var track = new Track();
            var trackDataAccess = new Mock<ITrackDataAccess>();
            trackDataAccess.Setup(x => x.GetByAsync(departmentContainer.Object)).ReturnsAsync(track);

            var trackGetService = new TrackGetService(trackDataAccess.Object);
            
            // Act
            var action = new Func<Task>(() => trackGetService.ValidateAsync(departmentContainer.Object));
            
            // Assert
            await action.Should().NotThrowAsync<Exception>();
        }
        
        [Test]
        public async Task ValidateAsync_MovieNotExists_ThrowsError()
        {
            // Arrange
            var fixture = new Fixture();
            var id = fixture.Create<int>();
            
            var trackContainer = new Mock<ITrackContainer>();
            trackContainer.Setup(x => x.TrackId).Returns(id);

            var track = new Track();
            var trackDataAccess = new Mock<ITrackDataAccess>();
            trackDataAccess.Setup(x => x.GetByAsync(trackContainer.Object)).ReturnsAsync((Track)null);

            var trackGetService = new TrackGetService(trackDataAccess.Object);
            
            // Act
            var action = new Func<Task>(() => trackGetService.ValidateAsync(trackContainer.Object));
            
            // Assert
            await action.Should().ThrowAsync<InvalidOperationException>($"Track not found by id {id}");
        }
    }
}