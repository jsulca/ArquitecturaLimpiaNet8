using ArquitecturaLimpiaNet8.Application.Dtos;
using MediatR;

namespace ArquitecturaLimpiaNet8.Application.UseCases.Orders.Commands.RemoveProduct;

public record RemoveProductCommand(int Id, int OrderId) : IRequest<RemoveProductDto>;
