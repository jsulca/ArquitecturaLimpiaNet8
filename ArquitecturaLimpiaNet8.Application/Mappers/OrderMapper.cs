using ArquitecturaLimpiaNet8.Application.Dtos;
using ArquitecturaLimpiaNet8.Application.UseCases.Orders.Commands.CreateOrder;
using ArquitecturaLimpiaNet8.Domain;

namespace ArquitecturaLimpiaNet8.Application.Mappers;

public static class OrderMapper
{
    public static IQueryable<OrderDto> ToQueryableDto(this IQueryable<Order> orderQuery) =>
        orderQuery.Select(x => new OrderDto(x.Id, x.Code, x.Description, x.Total));

    public static OrderDto ToEntity(this Order order) =>
        new(order.Id, order.Code, order.Description, order.Total);

    public static Order ToEntity(this CreateOrderCommand command) =>
        new() { Description = command.Description };
}
