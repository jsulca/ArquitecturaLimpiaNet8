using ArquitecturaLimpiaNet8.Application.Dtos;
using MediatR;

namespace ArquitecturaLimpiaNet8.Application.UseCases.Orders.Queries.GetOrderById;

public record GetOrderByIdQuery(int Id) : IRequest<OrderDto?>;
