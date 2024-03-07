using ArquitecturaLimpiaNet8.Application.Dtos;
using ArquitecturaLimpiaNet8.Domain;
using ArquitecturaLimpiaNet8.Infraestructure;
using ArquitecturaLimpiaNet8.Infraestructure.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArquitecturaLimpiaNet8.Application.UseCases.Orders.Commands.RemoveProduct;

public class RemoveProductHandler(IUnitOfWork unitOfWork) : IRequestHandler<RemoveProductCommand, RemoveProductDto>
{
    public async Task<RemoveProductDto> Handle(RemoveProductCommand request, CancellationToken cancellationToken)
    {
        IOrderRepository orderRepository = unitOfWork.OrderRepository;
        IOrderProductRepository orderProductRepository = unitOfWork.OrderProductRepository;

        IQueryable<OrderProduct> orderProductQuery = orderProductRepository.Queryable();
        IQueryable<Order> orderQuery = orderRepository.Queryable();

        Order? order = await orderQuery.FirstOrDefaultAsync(x => x.Id == request.OrderId, cancellationToken) ?? throw new Exception("El identificador de la orden no es válida");
        OrderProduct? _ = await orderProductQuery.FirstOrDefaultAsync(x => x.Id == request.Id && x.OrderId == request.OrderId, cancellationToken) ?? throw new Exception("No se ha encontrado el registro.");

        order.Total -= _.Amount * _.Price;

        orderProductRepository.Remove(_);
        orderRepository.Update(order);

        await unitOfWork.SaveAsync(cancellationToken);
        return new(request.Id);
    }
}
