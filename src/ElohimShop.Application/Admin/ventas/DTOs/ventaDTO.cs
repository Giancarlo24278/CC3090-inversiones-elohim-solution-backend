namespace ElohimShop.Application.Admin.Ventas.DTOs;

public class VentaDto
{
    public string Id { get; set; } = string.Empty;

    public string Cliente { get; set; } = string.Empty;

    public int Productos { get; set; }

    public decimal Subtotal { get; set; }

    public decimal Descuento { get; set; }

    public decimal Total { get; set; }

    public string Fecha { get; set; } = string.Empty;

    public string MetodoPago { get; set; } = string.Empty;

    public string Empleado { get; set; } = string.Empty;
}