namespace ElohimShop.Application.Admin.Ventas.DTOs;

public class VentaDashboardDto
{
    public int VentasHoy { get; set; }

    public decimal IngresosHoy { get; set; }

    public decimal TicketPromedio { get; set; }

    public int ProductosVendidos { get; set; }

    public decimal TotalDescuentos { get; set; }

    public string MetodoPagoMasUsado { get; set; } = string.Empty;
}