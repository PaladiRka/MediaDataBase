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
    public class PodcastGetServiceTests
    {
        [Test]
        public async Task ValidateAsync_PodcastExists_DoesNothing()
        {
            // Arrange
            var podcastContainer = new Mock<IPodcastContainer>();

            var podcast = new Podcast();
            var podcastDataAccess = new Mock<IPodcastDataAccess>();
            podcastDataAccess.Setup(x => x.GetByAsync(podcastContainer.Object)).ReturnsAsync(podcast);

            var podcastGetService = new PodcastGetService(podcastDataAccess.Object);
            
            // Act
            var action = new Func<Task>(() => podcastGetService.ValidateAsync(podcastContainer.Object));
            
            // Assert
            await action.Should().NotThrowAsync<Exception>();
        }
        
        [Test]
        public async Task ValidateAsync_PodcastNotExists_ThrowsError()
        {
            // Arrange
            var fixture = new Fixture();
            var id = fixture.Create<int>();
            
            var podcastContainer = new Mock<IPodcastContainer>();
            podcastContainer.Setup(x => x.PodcastId).Returns(id);

            var podcast = new Podcast();
            var podcastDataAccess = new Mock<IPodcastDataAccess>();
            podcastDataAccess.Setup(x => x.GetByAsync(podcastContainer.Object)).ReturnsAsync((Podcast)null);

            var podcastGetService = new PodcastGetService(podcastDataAccess.Object);
            
            // Act
            var action = new Func<Task>(() => podcastGetService.ValidateAsync(podcastContainer.Object));
            
            // Assert
            await action.Should().ThrowAsync<InvalidOperationException>($"Podcast not found by id {id}");
        }
    }
}