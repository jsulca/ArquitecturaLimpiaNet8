using ArquitecturaLimpiaNet8.Application.UseCases.Orders.Commands.AddProduct;
using ArquitecturaLimpiaNet8.Domain;

namespace ArquitecturaLimpiaNet8.Application.Mappers;

public static class OrderProductMapper
{
    public static OrderProduct ToEntity(this AddProductCommand entity)
        => new() { OrderId = entity.OrderId, ProductId = entity.ProductId, Amount = entity.Amount };
}
