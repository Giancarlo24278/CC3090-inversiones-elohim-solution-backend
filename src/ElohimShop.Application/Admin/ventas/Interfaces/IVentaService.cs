using ElohimShop.Application.Admin.Ventas.DTOs;
using ElohimShop.Application.Admin.Ventas.Filters;

namespace ElohimShop.Application.Admin.Ventas.Interfaces;

public interface IVentaService
{
    Task<List<VentaDto>> ObtenerVentasAsync(VentaFiltroDto filtros);
}