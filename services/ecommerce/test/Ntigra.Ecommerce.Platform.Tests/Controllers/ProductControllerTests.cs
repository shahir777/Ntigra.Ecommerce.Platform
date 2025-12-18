using Moq;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using Ntigra.Ecommerce.Platform.Web.Controllers;
using Ntigra.Ecommerce.Platform.Application.Contract.Product;
using FluentAssertions;
using Ntigra.Ecommerce.Platform.Domain.Shared.Results;
using Ntigra.Ecommerce.Platform.Domain.Shared.Enums;

public sealed class ProductControllerTests
{
    private readonly Mock<IProductService> _productServiceMock;
    private readonly ProductController _controller;

    public ProductControllerTests()
    {
        _productServiceMock = new Mock<IProductService>();
        _controller = new ProductController(_productServiceMock.Object);
    }

    [Fact]
    public async Task Index_Should_Return_View_With_Products_When_Success()
    {
        // Arrange
        var products = new List<ProductResponseDto>
        {
            new() { Id = 1, Name = "Test", Price = 100 }
        };

        _productServiceMock
            .Setup(x => x.GetAllProductsAsync())
            .ReturnsAsync(Response<List<ProductResponseDto>>.Success(data: products)); // <-- fixed here

        // Act
        var result = await _controller.Index();

        // Assert
        var viewResult = result as ViewResult;
        viewResult.Should().NotBeNull();
        viewResult!.Model.Should().BeEquivalentTo(products);
    }

    [Fact]
    public async Task Index_Should_Return_Error_View_When_Failed()
    {
        // Arrange
        var response = Response<List<ProductResponseDto>>.Fail(ReturnCode.UnhandledException);

        _productServiceMock
            .Setup(x => x.GetAllProductsAsync())
            .ReturnsAsync(response);

        // Act
        var result = await _controller.Index();

        // Assert
        var viewResult = result as ViewResult;
        viewResult.Should().NotBeNull();
        viewResult!.ViewName.Should().Be("Error");
    }
}
