using maERP.Application.Dtos.Order;
using maERP.Domain.Models;
using System.Net;
using System.Net.Http.Json;

namespace maERP.Server.Tests;

[Collection("Sequential")]
public class OrderCrudTest : IClassFixture<maERPWebApplicationFactory<Program>>
{
    private readonly maERPWebApplicationFactory<Program> _webApplicationFactory;

    public OrderCrudTest(maERPWebApplicationFactory<Program> webApplicationFactory)
    {
        _webApplicationFactory = webApplicationFactory;
    }

    [Theory]
    [InlineData("/api/v1/Orders")]
    public async Task Create(string url)
    {
        HttpClient httpClient = _webApplicationFactory.CreateClient();

        await _webApplicationFactory.InitializeDbForTests();
        var order = new OrderCreateDto
        {
            SalesChannelId = 1,
            CustomerId = 1,
            Status = 1
        };

        HttpResponseMessage result = await httpClient.PostAsJsonAsync(url, order);
        OrderDetailDto? resultContent = await result.Content.ReadFromJsonAsync<OrderDetailDto>();

        Assert.NotNull(resultContent);
        Assert.True(result.IsSuccessStatusCode);
        Assert.True(resultContent != null && resultContent.Id != default);
    }

    [Theory]
    [InlineData("/api/v1/Orders/")]
    public async Task GetAll(string url)
    {
        HttpClient httpClient = _webApplicationFactory.CreateClient();
        await _webApplicationFactory.InitializeDbForTests(
            new List<Order> {
                new() {
                    Id = 2,
                    RemoteOrderId = "222"
                }
        });

        ICollection<OrderListDto>? result = await httpClient.GetFromJsonAsync<ICollection<OrderListDto>>(url);

        Assert.NotNull(result);
        Assert.Equal(result?.Count, 1);
    }

    [Theory]
    [InlineData("/api/v1/Orders/3")]
    public async Task GetDetail(string url)
    {
        HttpClient httpClient = _webApplicationFactory.CreateClient();
        await _webApplicationFactory.InitializeDbForTests(
            new List<Order> {
                new() {
                    Id = 3,
                    RemoteOrderId = "333"
                }
        });

        OrderDetailDto? result = await httpClient.GetFromJsonAsync<OrderDetailDto>(url);

        Assert.NotNull(result);
        Assert.True(result.RemoteOrderId.Length > 0);
    }

    [Theory]
    [InlineData("/api/v1/Orders/4")]
    public async Task Update(string url)
    {
        HttpClient httpClient = _webApplicationFactory.CreateClient();

        await _webApplicationFactory.InitializeDbForTests(
            new List<Order> {
                new() {
                    Id = 4,
                    RemoteOrderId = "444"
                }
        });

        var order = new OrderUpdateDto
        {
            RemoteOrderId = "444-updated",
        };

        HttpResponseMessage result = await httpClient.PutAsJsonAsync(url, order);

        Assert.Equal(HttpStatusCode.NoContent, result.StatusCode);
    }

    [Theory]
    [InlineData("/api/v1/Orders/5")]
    public async Task Delete(string url)
    {
        HttpClient httpClient = _webApplicationFactory.CreateClient();
        await _webApplicationFactory.InitializeDbForTests(
            new List<Order> {
                new() {
                    Id = 5,
                    RemoteOrderId = "555"
                }
        });

        HttpResponseMessage result = await httpClient.DeleteAsync(url);

        Assert.Equal(HttpStatusCode.NoContent, result?.StatusCode);
    }

    [Theory]
    [InlineData("/api/v1/Orders/999999")]
    public async Task NotExist(string url)
    {
        HttpClient httpClient = _webApplicationFactory.CreateClient();
        await _webApplicationFactory.InitializeDbForTests();

        HttpResponseMessage result = await httpClient.GetAsync(url);

        Assert.Equal(result?.StatusCode, HttpStatusCode.NotFound);
    }
}