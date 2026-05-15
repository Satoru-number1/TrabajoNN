using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using clean.Data;
using Microsoft.AspNetCore.Mvc;

namespace clean.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : ControllerBase
    {
        private readonly AppDbContext context;
        public ProductosController(AppDbContext context)
        {
            this.context=context;
        }
        [HttpGet]
        public async Task<IActionResult> MostrarProductos()
        {
            
            return Ok();
        }
    }
}