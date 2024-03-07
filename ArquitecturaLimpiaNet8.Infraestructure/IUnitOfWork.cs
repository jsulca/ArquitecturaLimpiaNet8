using ArquitecturaLimpiaNet8.Infraestructure.Interfaces;

namespace ArquitecturaLimpiaNet8.Infraestructure;

public interface IUnitOfWork : IDisposable
{
    public IOrderRepository OrderRepository { get; }
    public IOrderProductRepository OrderProductRepository { get; }

    Task<int> SaveAsync(CancellationToken cancellationToken = default);
    int Save();
}
