using ArquitecturaLimpiaNet8.Application.Dtos;
using MediatR;

namespace ArquitecturaLimpiaNet8.Application.UseCases.Orders.Commands.AddProduct;

public record AddProductCommand(int OrderId, int ProductId, decimal Amount) : IRequest<AddProductDto>;
