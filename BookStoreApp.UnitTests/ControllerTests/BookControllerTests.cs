using BookStoreApp.Web.Controllers;
using BookStoreApp.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApp.UnitTests.ControllerTests;

public class BookControllerTests
{
    [Fact]
    public void BookController_Index_ReturnsViewResult_WithListOfBooks()
    {
        // Arrange
        var controller = new BookController();

        // Act
        var result = controller.Index();

        // Assert
        var viewResult = Assert.IsType<ViewResult>(result);
        var model = Assert.IsAssignableFrom<IEnumerable<Book>>(viewResult.ViewData.Model);
        Assert.NotNull(model);
        Assert.NotEmpty(model);
        Assert.Equal(2, model.Count()); // Assuming there are 2 books in the hardcoded list
    }

    [Fact]
    public void BookController_Create_RedirectsToIndex_OnSuccess()
    {
        // Arrange
        var controller = new BookController();
        var formCollection = new FormCollection(new Dictionary<string, Microsoft.Extensions.Primitives.StringValues>
        {
            { "Name", "New Book" },
            { "IsBorrowed", "false" }
        });

        // Act
        var result = controller.Create(formCollection);

        // Assert
        Assert.NotNull(result);
        var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
        Assert.Equal("Index", redirectToActionResult.ActionName);
    }
}
