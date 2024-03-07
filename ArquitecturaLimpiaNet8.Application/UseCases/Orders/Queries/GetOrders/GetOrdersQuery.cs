using ArquitecturaLimpiaNet8.Application.Dtos;
using MediatR;

namespace ArquitecturaLimpiaNet8.Application.UseCases.Orders.Queries.GetOrders;

public record GetOrdersQuery() : IRequest<List<OrderDto>>;
