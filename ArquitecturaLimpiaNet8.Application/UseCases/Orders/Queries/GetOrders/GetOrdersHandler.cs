using ArquitecturaLimpiaNet8.Application.Dtos;
using ArquitecturaLimpiaNet8.Application.Mappers;
using ArquitecturaLimpiaNet8.Infraestructure;
using ArquitecturaLimpiaNet8.Infraestructure.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArquitecturaLimpiaNet8.Application.UseCases.Orders.Queries.GetOrders;

public class GetOrdersHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetOrdersQuery, List<OrderDto>>
{
    public Task<List<OrderDto>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
    {
        IOrderRepository orderRepository = unitOfWork.OrderRepository;
        IQueryable<OrderDto> orderQuery = orderRepository.Queryable().ToQueryableDto();
        return orderQuery.ToListAsync(cancellationToken);
    }
}
