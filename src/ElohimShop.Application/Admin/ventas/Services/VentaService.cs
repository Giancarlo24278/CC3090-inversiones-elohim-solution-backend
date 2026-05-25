using ElohimShop.Application.Admin.Ventas.DTOs;
using ElohimShop.Application.Admin.Ventas.Filters;
using ElohimShop.Application.Admin.Ventas.Interfaces;

namespace ElohimShop.Application.Admin.Ventas.Services;

public class VentaService : IVentaService
{
    private readonly List<VentaDto> _ventas =
    [
        new()
        {
            Id = "V-001234",
            Cliente = "Juan Pérez",
            Productos = 3,
            Subtotal = 120,
            Descuento = 0,
            Total = 120,
            Fecha = "2026-04-29",
            MetodoPago = "efectivo",
            Empleado = "Carlos Ruiz"
        },

        new()
        {
            Id = "V-001235",
            Cliente = "María García",
            Productos = 5,
            Subtotal = 250,
            Descuento = 25,
            Total = 225,
            Fecha = "2026-04-29",
            MetodoPago = "tarjeta",
            Empleado = "Ana López"
        }
    ];

    public async Task<List<VentaDto>> ObtenerVentasAsync(
        VentaFiltroDto filtros
    )
    {
        var ventas = _ventas.AsQueryable();

        if (!string.IsNullOrWhiteSpace(filtros.Busqueda))
        {
            ventas = ventas.Where(v =>
                v.Id.Contains(filtros.Busqueda,
                    StringComparison.OrdinalIgnoreCase)
                ||
                v.Cliente.Contains(filtros.Busqueda,
                    StringComparison.OrdinalIgnoreCase)
            );
        }

        if (!string.IsNullOrWhiteSpace(filtros.MetodoPago)
            && filtros.MetodoPago != "todos")
        {
            ventas = ventas.Where(v =>
                v.MetodoPago == filtros.MetodoPago
            );
        }

        return await Task.FromResult(ventas.ToList());
    }

    public async Task<VentaDto?> ObtenerVentaPorIdAsync(string id)
    {
        var venta = _ventas.FirstOrDefault(v => v.Id == id);

        return await Task.FromResult(venta);
    }

    public async Task<VentaDetalleDto?> ObtenerDetalleVentaAsync(string id)
    {
        var detalle = new VentaDetalleDto
        {
            VentaId = id,
            Cliente = "Juan Pérez",
            Fecha = "2026-04-29",
            MetodoPago = "efectivo",
            Empleado = "Carlos Ruiz",
            Subtotal = 120,
            Descuento = 0,
            Total = 120,

            Productos =
            [
                new()
                {
                    ProductoId = "P-001",
                    Nombre = "Coca Cola",
                    Cantidad = 2,
                    PrecioUnitario = 15,
                    Subtotal = 30
                }
            ]
        };

        return await Task.FromResult(detalle);
    }

    public async Task<VentaDashboardDto> ObtenerDashboardAsync()
    {
    var ventasHoy = _ventas;

    var totalVentas = ventasHoy.Count;

    var ingresosHoy = ventasHoy.Sum(v => v.Total);

    var ticketPromedio = totalVentas > 0
        ? ingresosHoy / totalVentas
        : 0;

    var productosVendidos = ventasHoy.Sum(v => v.Productos);

    var totalDescuentos = ventasHoy.Sum(v => v.Descuento);

    var metodoPagoMasUsado = ventasHoy
        .GroupBy(v => v.MetodoPago)
        .OrderByDescending(g => g.Count())
        .Select(g => g.Key)
        .FirstOrDefault() ?? "N/A";

    var dashboard = new VentaDashboardDto
    {
        VentasHoy = totalVentas,
        IngresosHoy = ingresosHoy,
        TicketPromedio = decimal.Round(ticketPromedio, 2),
        ProductosVendidos = productosVendidos,
        TotalDescuentos = totalDescuentos,
        MetodoPagoMasUsado = metodoPagoMasUsado
    };

    return await Task.FromResult(dashboard);
    }

    public async Task<VentaDto> CrearVentaAsync(VentaDto venta)
    {
    venta.Total = venta.Subtotal - venta.Descuento;

    _ventas.Add(venta);

    return await Task.FromResult(venta);
}
}