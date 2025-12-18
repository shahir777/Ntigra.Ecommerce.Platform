using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using Ntigra.Ecommerce.Platform.Application.ProductServices;
using Ntigra.Ecommerce.Platform.Domain.Product;
using Ntigra.Ecommerce.Platform.Domain.Shared.Enums;
using Ntigra.Ecommerce.Platform.Domain.Shared.Helper;
using Xunit;

public sealed class ProductServiceTests
{
    private readonly Mock<IProductRepository> _repoMock;
    private readonly Mock<ILogger<ProductServiceAppService>> _loggerMock;
    private readonly ProductServiceAppService _service;

    public ProductServiceTests()
    {
        _repoMock = new Mock<IProductRepository>();
        _loggerMock = new Mock<ILogger<ProductServiceAppService>>();

        _service = new ProductServiceAppService(
            _repoMock.Object,
            _loggerMock.Object
        );
    }

    [Fact]
    public async Task GetAllProductsAsync_Should_Return_Success_When_Products_Exist()
    {
        var products = new List<Product>
        {
            new() { Id = 1, Name = "Product", Price = 200, IsActive = true }
        };

        _repoMock.Setup(x => x.GetAllProductsAsync()).ReturnsAsync(products);

        var result = await _service.GetAllProductsAsync();

        result.Status.Should().BeTrue();
        result.Data.Should().HaveCount(1);
        result.Data!.First().Name.Should().Be("Product");
    }

    [Fact]
    public async Task GetAllProductsAsync_Should_Return_ProductNotFound_When_Empty()
    {
        _repoMock.Setup(x => x.GetAllProductsAsync()).ReturnsAsync(new List<Product>());

        var result = await _service.GetAllProductsAsync();

        result.Status.Should().BeTrue();
        var (code, _) = ReturnCodeHelper.GetResponseDetails(ReturnCode.ProductNotFound);
        result.ResponseCode.Should().Be(code);
    }

    [Fact]
    public async Task GetAllProductsAsync_Should_Return_Failure_On_Exception()
    {
        _repoMock.Setup(x => x.GetAllProductsAsync()).ThrowsAsync(new Exception("DB Error"));

        var result = await _service.GetAllProductsAsync();

        result.Status.Should().BeFalse();
        var (code, _) = ReturnCodeHelper.GetResponseDetails(ReturnCode.UnhandledException);
        result.ResponseCode.Should().Be(code);
    }
}