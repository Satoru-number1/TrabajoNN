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
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaRepository _context;

        public CategoriaController(ICategoriaRepository context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> MostrarCategorias()
        {
            var categorias = await _context.MostrarCategorias();

            return Ok(categorias);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> MostrarCategoriaId(string id)
        {
            var categoria = await _context.MostrarCategoriaId(id);
            if (categoria == null)
                return NotFound();
            return Ok(categoria);
        }

        [HttpPost]
        public async Task<IActionResult> PostCategoria([FromBody] CategoriaDto categoriadto)
        {
            var categoria = await _context.PostCategoria(categoriadto);
            if (categoria is null)
                return BadRequest();
            return Ok(categoria);
        }
    }
}
