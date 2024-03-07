using ArquitecturaLimpiaNet8.Application.Dtos;
using MediatR;

namespace ArquitecturaLimpiaNet8.Application.UseCases.Orders.Commands.CreateOrder;

public record CreateOrderCommand(string Description) : IRequest<CreateOrderDto>;
