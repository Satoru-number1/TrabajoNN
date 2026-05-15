using clean.Aplicaccion.Dtos;
using clean.Data;
using clean.Dominio.Interfaces;
using clean.Dominio.Models;
using Microsoft.EntityFrameworkCore;

namespace clean.Repository
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly AppDbContext _context;

        public ProductoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ProductoDto> MostrarProductoId(string codigoProducto)
        {
            var producto = await (
                from p in _context.Productos
                where p.codigoProducto == codigoProducto
                select new ProductoDto
                {
                    codigoProducto = p.codigoProducto,
                    Nombre = p.Nombre,
                    Precio = p.Precio,
                }
            ).FirstOrDefaultAsync();
            if (producto is null)
                return null;
            return producto;
        }

        public async Task<List<ProductoDto>> MostrarProductos()
        {
            var productos = await (
                from p in _context.Productos
                select new ProductoDto
                {
                    codigoProducto = p.codigoProducto,
                    Nombre = p.Nombre,
                    Precio = p.Precio,
                }
            ).ToListAsync();
            return productos;
        }

        public async Task<ProductoDto> PostProducto(ProductoDto producto)
        {
            var pro = await _context.Productos.FirstOrDefaultAsync(p =>
                p.codigoProducto == producto.codigoProducto
            );
            if (pro != null)
                return null;
            Producto producto1 = new Producto
            {
                Nombre = producto.Nombre,
                codigoProducto = producto.codigoProducto,
                Precio = producto.Precio,
            };
            _context.Productos.Add(producto1);
            await _context.SaveChangesAsync();
            return producto;
        }
    }
}
