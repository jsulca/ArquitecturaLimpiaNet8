using ArquitecturaLimpiaNet8.Application.Dtos;
using ArquitecturaLimpiaNet8.Application.Mappers;
using ArquitecturaLimpiaNet8.Infraestructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArquitecturaLimpiaNet8.Application.UseCases.Orders.Queries.GetOrderById;

public class GetOrderByIdHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetOrderByIdQuery, OrderDto?>
{
    public Task<OrderDto?> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
    {
        IQueryable<OrderDto> orderQuery = unitOfWork.OrderRepository.Queryable().Where(x => x.Id == request.Id).ToQueryableDto();
        return orderQuery.FirstOrDefaultAsync(cancellationToken);
    }
}
