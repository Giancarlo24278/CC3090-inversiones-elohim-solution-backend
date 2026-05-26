using ElohimShop.Application.Admin.Ventas.DTOs;
using ElohimShop.Application.Admin.Ventas.Filters;
using ElohimShop.Application.Admin.Ventas.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ElohimShop.API.Controllers;

[ApiController]
[Route("api/ventas")]
public class VentasController : ControllerBase
{
    private readonly IVentaService _ventaService;

    public VentasController(IVentaService ventaService)
    {
        _ventaService = ventaService;
    }

    // GET /api/ventas
    [HttpGet]
    public async Task<IActionResult> ObtenerVentas(
        [FromQuery] VentaFiltroDto filtros
    )
    {
        var ventas = await _ventaService.ObtenerVentasAsync(filtros);

        return Ok(ventas);
    }

    // GET /api/ventas/:id
    [HttpGet("{id}")]
    public async Task<IActionResult> ObtenerVentaPorId(string id)
    {
        var venta = await _ventaService.ObtenerVentaPorIdAsync(id);

        if (venta == null)
        {
            return NotFound();
        }

        return Ok(venta);
    }

    // POST /api/ventas
    [HttpPost]
    public async Task<IActionResult> CrearVenta(
        [FromBody] VentaDto venta
    )
    {
        var nuevaVenta = await _ventaService.CrearVentaAsync(venta);

        return Ok(nuevaVenta);
    }

    // GET /api/ventas/export
    [HttpGet("export")]
    public async Task<IActionResult> ExportarVentas()
    {
    var archivo = await _ventaService
        .ExportarVentasCsvAsync();

    return File(
        archivo,
        "text/csv",
        $"ventas-{DateTime.Now:yyyyMMddHHmmss}.csv"
    );
    }

    // GET /api/ventas/:id/detalle
    [HttpGet("{id}/detalle")]
    public async Task<IActionResult> ObtenerDetalle(string id)
    {
        var detalle = await _ventaService
            .ObtenerDetalleVentaAsync(id);

        return Ok(detalle);
    }

    // GET /api/ventas/dashboard
    [HttpGet("dashboard")]
    public async Task<IActionResult> Dashboard()
    {
        var dashboard = await _ventaService
            .ObtenerDashboardAsync();

        return Ok(dashboard);
    }
}