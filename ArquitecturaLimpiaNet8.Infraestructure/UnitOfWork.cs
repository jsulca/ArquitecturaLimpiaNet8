using ArquitecturaLimpiaNet8.Infraestructure.Interfaces;
using ArquitecturaLimpiaNet8.Infraestructure.Persistence;

namespace ArquitecturaLimpiaNet8.Infraestructure;

public class UnitOfWork(ApplicationDbContext context, IOrderRepository orderRepository, IOrderProductRepository orderProductRepository) : IUnitOfWork
{
    public IOrderRepository OrderRepository => orderRepository;

    public IOrderProductRepository OrderProductRepository => orderProductRepository;

    public void Dispose() => context.Dispose();

    public int Save() => context.SaveChanges();

    public Task<int> SaveAsync(CancellationToken cancellationToken = default) => context.SaveChangesAsync(cancellationToken);

}
