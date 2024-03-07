using ArquitecturaLimpiaNet8.Domain.Common;

namespace ArquitecturaLimpiaNet8.Domain;

public class Order : AuditableEntity
{
    public string Code { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public int Year { get; set; }
    public int Month { get; set; }
    public bool IsDeleted { get; set; }

    public decimal Total { get; set; }

    public IEnumerable<OrderProduct>? Products { get; set; }
}
