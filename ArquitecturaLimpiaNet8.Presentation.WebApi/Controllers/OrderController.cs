using ArquitecturaLimpiaNet8.Application.Dtos;
using ArquitecturaLimpiaNet8.Application.UseCases.Orders.Commands.AddProduct;
using ArquitecturaLimpiaNet8.Application.UseCases.Orders.Commands.CreateOrder;
using ArquitecturaLimpiaNet8.Application.UseCases.Orders.Commands.RemoveProduct;
using ArquitecturaLimpiaNet8.Application.UseCases.Orders.Queries.GetOrderById;
using ArquitecturaLimpiaNet8.Application.UseCases.Orders.Queries.GetOrders;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ArquitecturaLimpiaNet8.Presentation.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController(ISender sender) : ControllerBase
{
    [HttpGet("GetOrders")]
    public async Task<IEnumerable<OrderDto>> Get(CancellationToken cancellationToken)
    {
        GetOrdersQuery query = new();
        return await sender.Send(query, cancellationToken);
    }

    [HttpGet("GetOrder")]
    public async Task<OrderDto?> Get(int id, CancellationToken cancellationToken)
    {
        GetOrderByIdQuery query = new(id);
        return await sender.Send(query, cancellationToken);
    }

    [HttpPost("CreateOrder")]
    public async Task<CreateOrderDto> Post(CreateOrderCommand request, CancellationToken cancellationToken)
        => await sender.Send(request, cancellationToken);

    [HttpPost("AddProduct")]
    public async Task<AddProductDto> Post(AddProductCommand request, CancellationToken cancellationToken)
        => await sender.Send(request, cancellationToken);

    [HttpDelete("RemoveProduct")]
    public async Task<RemoveProductDto> Delete(RemoveProductCommand request, CancellationToken cancellationToken)
        => await sender.Send(request, cancellationToken);
}
