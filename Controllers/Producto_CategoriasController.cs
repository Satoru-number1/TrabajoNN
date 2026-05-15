using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using clean.Aplicaccion.Dtos;
using clean.Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace clean.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Producto_CategoriasController : ControllerBase
    {
        private readonly IProductoCategoriaRepository _context;

        public Producto_CategoriasController(IProductoCategoriaRepository context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> MostrarCategorias()
        {
            var prca = await _context.MostraProductoCategoria();
            return Ok(prca);
        }

        [HttpGet("{idCategoria}/{idProducto}")]
        public async Task<IActionResult> MostrarCategoriaId(string idCategoria, string idProducto)
        {
            var pc = await _context.MostraProductoCategoriaId(idProducto, idCategoria);
            if (pc == null)
                return NotFound();
            return Ok(pc);
        }

        [HttpPost]
        public async Task<IActionResult> PostCategoria(string codigoP, string codigoC)
        {
            var pc = await _context.PostProductoCategoria(codigoP, codigoC);
            if (pc is null)
                return BadRequest();

            return Ok(pc);
        }
    }
}
