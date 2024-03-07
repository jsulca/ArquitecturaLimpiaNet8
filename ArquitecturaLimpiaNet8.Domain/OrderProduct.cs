using ArquitecturaLimpiaNet8.Domain.Common;

namespace ArquitecturaLimpiaNet8.Domain;

public class OrderProduct : Entity
{
    public int ProductId { get; set; }
    public int OrderId { get; set; }
    public decimal Amount { get; set; }
    public decimal Price { get; set; }

    public Order? Order { get; set; }
}
