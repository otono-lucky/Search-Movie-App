using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Movie_App.Context;
using Movie_App.Controllers;
using Movie_App.Models;
using Movie_App.Search.Command;
using Movie_App.Search.Query;

namespace MovieApp.Test
{
    public class LatestSearchControllerTests
    {
        [Fact]
        public async Task GetLatestSearches_ReturnsOkResult()
        {
            // Arrange
            var mediatorMock = new Mock<IMediator>();
            mediatorMock.Setup(m => m.Send(It.IsAny<GetLatestSearchesQuery>(), It.IsAny<CancellationToken>()))
                        .ReturnsAsync(new List<LatestSearch>());

            var controller = new LatestSearchController(mediatorMock.Object);

            // Act
            var result = await controller.GetLatestSearches();

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task GetLatestSearches_ReturnsListOfLatestSearches()
        {
            // Arrange
            var expectedSearches = new List<LatestSearch>
        {
            new LatestSearch { Id = 1, Query = "Movie 1" },
            new LatestSearch { Id = 2, Query = "Movie 2" }
        };

            var mediatorMock = new Mock<IMediator>();
            mediatorMock.Setup(m => m.Send(It.IsAny<GetLatestSearchesQuery>(), It.IsAny<CancellationToken>()))
                        .ReturnsAsync(expectedSearches);

            var controller = new LatestSearchController(mediatorMock.Object);

            // Act
            var result = await controller.GetLatestSearches() as OkObjectResult;
            var actualSearches = result?.Value as List<LatestSearch>;

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(actualSearches);
            Assert.Equal(expectedSearches.Count, actualSearches.Count);
            Assert.Equal(expectedSearches.First().Query, actualSearches.First().Query);
            Assert.Equal(expectedSearches.Last().Query, actualSearches.Last().Query);
        }

        [Fact]
        
        public async Task SaveLatestSearch_ReturnsOkResult()
        {
            // Arrange
            var mediatorMock = new Mock<IMediator>();
            mediatorMock.Setup(m => m.Send(It.IsAny<SaveLatestSearchCommand>(), It.IsAny<CancellationToken>()))
                        .ReturnsAsync(1); 

            var controller = new LatestSearchController(mediatorMock.Object);

            // Act
            var result = await controller.SaveLatestSearch(new SaveLatestSearchCommand { Query = "Movie 1" });

            // Assert
            Assert.IsType<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            Assert.Equal(1, okResult?.Value); 
        }
    }

}
