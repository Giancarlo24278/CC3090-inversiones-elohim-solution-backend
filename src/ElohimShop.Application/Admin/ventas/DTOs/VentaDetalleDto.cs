namespace ElohimShop.Application.Admin.Ventas.DTOs;

public class VentaDetalleDto
{
    public string VentaId { get; set; } = string.Empty;

    public string Cliente { get; set; } = string.Empty;

    public string Fecha { get; set; } = string.Empty;

    public string MetodoPago { get; set; } = string.Empty;

    public string Empleado { get; set; } = string.Empty;

    public decimal Subtotal { get; set; }

    public decimal Descuento { get; set; }

    public decimal Total { get; set; }

    public List<ProductoVentaDetalleDto> Productos { get; set; } = [];
}

public class ProductoVentaDetalleDto
{
    public string ProductoId { get; set; } = string.Empty;

    public string Nombre { get; set; } = string.Empty;

    public int Cantidad { get; set; }

    public decimal PrecioUnitario { get; set; }

    public decimal Subtotal { get; set; }
}