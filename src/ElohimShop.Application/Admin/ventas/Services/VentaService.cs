using ElohimShop.Application.Admin.Ventas.DTOs;
using ElohimShop.Application.Admin.Ventas.Filters;
using ElohimShop.Application.Admin.Ventas.Interfaces;

namespace ElohimShop.Application.Admin.Ventas.Services;

public class VentaService : IVentaService
{
    public async Task<List<VentaDto>> ObtenerVentasAsync(VentaFiltroDto filtros)
    {
        // Simulación DB
        var ventas = new List<VentaDto>
        {
            new()
            {
                Id = "V-001234",
                Cliente = "Juan Pérez",
                Productos = 3,
                Total = 120,
                MetodoPago = "efectivo",
                Fecha = "2026-04-29"
            },

            new()
            {
                Id = "V-001235",
                Cliente = "María García",
                Productos = 5,
                Total = 250,
                MetodoPago = "tarjeta",
                Fecha = "2026-04-29"
            }
        };

        // Buscar por ID o cliente
        if (!string.IsNullOrWhiteSpace(filtros.Busqueda))
        {
            ventas = ventas.Where(v =>
                v.Id.Contains(filtros.Busqueda,
                    StringComparison.OrdinalIgnoreCase)
                ||
                v.Cliente.Contains(filtros.Busqueda,
                    StringComparison.OrdinalIgnoreCase)
            ).ToList();
        }

        // Filtrar método pago
        if (!string.IsNullOrWhiteSpace(filtros.MetodoPago)
            && filtros.MetodoPago != "todos")
        {
            ventas = ventas.Where(v =>
                v.MetodoPago == filtros.MetodoPago
            ).ToList();
        }

        return await Task.FromResult(ventas);
    }
}