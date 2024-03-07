using System.Text.Json.Serialization;

namespace ArquitecturaLimpiaNet8.Application.Dtos;

public class ProductDto
{
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    public decimal Price { get; set; }
}
