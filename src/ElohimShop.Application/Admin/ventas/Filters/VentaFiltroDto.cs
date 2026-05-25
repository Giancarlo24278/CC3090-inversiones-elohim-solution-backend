namespace ElohimShop.Application.Admin.Ventas.Filters;

public class VentaFiltroDto
{
    public string? Busqueda { get; set; }

    public string? Fecha { get; set; }

    public string? MetodoPago { get; set; }

    public decimal? PrecioMin { get; set; }

    public decimal? PrecioMax { get; set; }
}