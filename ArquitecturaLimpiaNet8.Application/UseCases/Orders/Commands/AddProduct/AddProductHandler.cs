using ArquitecturaLimpiaNet8.Application.Dtos;
using ArquitecturaLimpiaNet8.Application.Mappers;
using ArquitecturaLimpiaNet8.Application.Services;
using ArquitecturaLimpiaNet8.Domain;
using ArquitecturaLimpiaNet8.Infraestructure;
using ArquitecturaLimpiaNet8.Infraestructure.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArquitecturaLimpiaNet8.Application.UseCases.Orders.Commands.AddProduct;

public class AddProductHandler(IUnitOfWork unitOfWork, IProductService productService) : IRequestHandler<AddProductCommand, AddProductDto>
{
    public async Task<AddProductDto> Handle(AddProductCommand request, CancellationToken cancellationToken)
    {
        IOrderProductRepository orderProductRepository = unitOfWork.OrderProductRepository;
        IOrderRepository orderRepository = unitOfWork.OrderRepository;

        IQueryable<Order> orderQuery = unitOfWork.OrderRepository.Queryable();

        Order? order = await orderQuery.FirstOrDefaultAsync(x => x.Id == request.OrderId, cancellationToken) ?? throw new Exception("El identificador de la orden no es válida");
        ProductDto? product = await productService.GetAsync(request.ProductId, cancellationToken) ?? throw new Exception("No se ha encontrado el producto");

        OrderProduct _ = request.ToEntity();
        _.Price = product.Price;

        order.Total += _.Amount * _.Price;

        orderProductRepository.Save(_);
        orderRepository.Update(order);

        await unitOfWork.SaveAsync(cancellationToken);

        return new(_.Id);
    }
}
