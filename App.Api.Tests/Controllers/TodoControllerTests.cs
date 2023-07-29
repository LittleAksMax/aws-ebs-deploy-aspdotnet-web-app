using App.Api.Controllers;
using App.Domain.Dtos;
using App.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace App.Api.Tests.Controllers;

public sealed class TodoControllerTests
{
    [Fact]
    public async Task GetAll_OnSuccess_ShouldReturnOkObjectResult()
    {
        // Arrange
        var serviceMock = new Mock<ITodoService>();
        serviceMock.Setup(x => x.GetAllTodos())
            .ReturnsAsync(_testReturnData);
        var controller = new TodoController(serviceMock.Object);
        
        // Act
        var response = await controller.GetAll();
        var expectedLength = _testReturnData.Count;

        // Assert
        var assertedResponse = Assert.IsType<OkObjectResult>(response);
        Assert.Equal(StatusCodes.Status200OK, assertedResponse.StatusCode);
        var assertedList = Assert.IsType<List<TodoDto>>(assertedResponse.Value);
        Assert.NotEmpty(assertedList);
        Assert.Equal(expectedLength, assertedList.Count);
    }

    [Fact]
    public async Task GetAll_OnFail_ShouldReturnOkObjectResult_WithEmptyArray()
    {
        // Arrange
        var serviceMock = new Mock<ITodoService>();
        serviceMock.Setup(x => x.GetAllTodos())
            .ReturnsAsync(new List<TodoDto>());
        var controller = new TodoController(serviceMock.Object);
        
        // Act
        var response = await controller.GetAll();

        // Assert
        var assertedResponse = Assert.IsType<OkObjectResult>(response);
        Assert.Equal(StatusCodes.Status200OK, assertedResponse.StatusCode);
        var assertedList = Assert.IsType<List<TodoDto>>(assertedResponse.Value);
        Assert.Empty(assertedList);
    }

    private readonly List<TodoDto> _testReturnData = new()
    {
        new TodoDto
        {
            TodoId = new Guid("9775B719-67F8-473D-91D2-7BA18E708DC2"),
            Title = "Title #1",
            Description = "Description #1"
        },
        new TodoDto
        {
            TodoId = new Guid("193504F0-5382-4650-B51F-E1253AABCAEA"),
            Title = "Title #2",
            Description = "Description #2"
        },
        new TodoDto
        {
            TodoId = new Guid("C860A8A9-95FA-437C-A3A5-4CB4B7D7958A"),
            Title = "Title #3",
            Description = "Description #3"
        },
        new TodoDto
        {
            TodoId = new Guid("64974681-E4B1-48F0-905B-B45A3E3B08E7"),
            Title = "Title #4",
            Description = "Description #4"
        }
    };
}