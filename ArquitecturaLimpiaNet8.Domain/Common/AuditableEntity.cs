namespace ArquitecturaLimpiaNet8.Domain.Common;

public abstract class AuditableEntity : Entity
{
    public DateTimeOffset Created { get; set; }
    public DateTimeOffset? Modified { get; set; }
}
