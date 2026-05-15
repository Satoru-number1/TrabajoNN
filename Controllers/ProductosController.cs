using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using clean.Aplicaccion.Dtos;
using clean.Data;
using clean.Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace clean.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : ControllerBase
    {
        private readonly IProductoRepository _context;

        public ProductosController(IProductoRepository context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> MostrarProductos()
        {
            var productos = await _context.MostrarProductos();
            return Ok(productos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> MostrarProductoId(string id)
        {
            var producto = await _context.MostrarProductoId(id);
            if (producto is null)
                return NotFound();
            return Ok(producto);
        }

        [HttpPost]
        public async Task<IActionResult> PostProducto(ProductoDto productoDto)
        {
            var producto = await _context.PostProducto(productoDto);
            if (producto is null)
                return BadRequest();
            return Ok(producto);
        }
    }
}
