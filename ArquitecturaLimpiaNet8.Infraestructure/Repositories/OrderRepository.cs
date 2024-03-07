using ArquitecturaLimpiaNet8.Domain;
using ArquitecturaLimpiaNet8.Infraestructure.Common;
using ArquitecturaLimpiaNet8.Infraestructure.Interfaces;
using ArquitecturaLimpiaNet8.Infraestructure.Persistence;

namespace ArquitecturaLimpiaNet8.Infraestructure.Repositories;

public class OrderRepository(ApplicationDbContext context) : BaseRepository<Order>(context), IOrderRepository
{
}
