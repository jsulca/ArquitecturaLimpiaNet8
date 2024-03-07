using ArquitecturaLimpiaNet8.Application.Dtos;
using ArquitecturaLimpiaNet8.Application.Mappers;
using ArquitecturaLimpiaNet8.Domain;
using ArquitecturaLimpiaNet8.Infraestructure;
using ArquitecturaLimpiaNet8.Infraestructure.Interfaces;
using MediatR;

namespace ArquitecturaLimpiaNet8.Application.UseCases.Orders.Commands.CreateOrder;

public class CreateOrderHandler(IUnitOfWork unitOfWork) : IRequestHandler<CreateOrderCommand, CreateOrderDto>
{
    public async Task<CreateOrderDto> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        IOrderRepository orderRepository = unitOfWork.OrderRepository;
        IQueryable<Order> queryOrder = orderRepository.Queryable();

        DateTime today = DateTime.Today;

        Order _ = request.ToEntity();

        _.Year = today.Year;
        _.Month = today.Month;
        _.Code = $"OR-{_.Year}-{queryOrder.Where(x => x.Year == _.Year).Count() + 1:D8}";

        orderRepository.Save(_);
        await unitOfWork.SaveAsync(cancellationToken);

        return new(_.Id, _.Code);
    }
}
