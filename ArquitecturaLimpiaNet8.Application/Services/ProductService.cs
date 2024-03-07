using ArquitecturaLimpiaNet8.Application.Dtos;
using Microsoft.Extensions.Caching.Distributed;
using System.Net.Http.Json;
using System.Text.Json;
using ArquitecturaLimpiaNet8.Application.Common;

namespace ArquitecturaLimpiaNet8.Application.Services;

public class ProductService(IHttpClientFactory httpClientFactory, IDistributedCache distributedCache) : IProductService
{
    private readonly HttpClient _httpClient = httpClientFactory.CreateClient("ProductHttp");
    private readonly JsonSerializerOptions _jsonSerializerOptions = new() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
    private const string PRODUCT_TAG = "PRODUCT";
    private readonly DistributedCacheEntryOptions _cacheEntryOptions = new DistributedCacheEntryOptions()
                        .SetAbsoluteExpiration(TimeSpan.FromDays(1));

    public  Task<IEnumerable<ProductDto>?> GetAllAsync(CancellationToken cancellationToken)
    {
        return _httpClient.GetFromJsonAsync<IEnumerable<ProductDto>>("api/v1/products", _jsonSerializerOptions, cancellationToken);
    }

    public async Task<ProductDto?> GetAsync(int id, CancellationToken cancellationToken)
    {
        string tag = $"{PRODUCT_TAG}-{id}";
        if (!distributedCache.TryGetValue(tag, out ProductDto? product))
        {
            product = await _httpClient.GetFromJsonAsync<ProductDto>($"api/v1/products/{id}", _jsonSerializerOptions, cancellationToken);
            if (product is not null) await distributedCache.SetAsync(tag, product, _cacheEntryOptions, cancellationToken);
        }

        return product;
    }
}
