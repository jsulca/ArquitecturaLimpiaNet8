using ArquitecturaLimpiaNet8.Application.Dtos;

namespace ArquitecturaLimpiaNet8.Application.Services;

public interface IProductService
{
    Task<IEnumerable<ProductDto>?> GetAllAsync(CancellationToken cancellationToken);
    Task<ProductDto?> GetAsync(int id, CancellationToken cancellationToken);
}
