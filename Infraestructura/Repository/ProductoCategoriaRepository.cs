using clean.Aplicaccion.Dtos;
using clean.Data;
using clean.Dominio.Interfaces;
using clean.Dominio.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace clean.Repository
{
    public class ProductoCategoriaRepository : IProductoCategoriaRepository
    {
        private readonly AppDbContext _context;

        public ProductoCategoriaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProductosCategoriasDTO>> MostraProductoCategoria()
        {
            var pc1 = await (
                from pc in _context.Producto_Categorias
                join c in _context.Categorias on pc.categoria_id equals c.Id_Categoria
                join p in _context.Productos on pc.producto_id equals p.Id_Producto
                group c by c.Nombre into categoriasUnicas
                select new ProductosCategoriasDTO
                {
                    cate = new CategoriasDto { Nombre = categoriasUnicas.Key },
                    produ = (
                        from prod in _context.Productos
                        join procate in _context.Producto_Categorias
                            on prod.Id_Producto equals procate.producto_id
                        join cate in _context.Categorias
                            on procate.categoria_id equals cate.Id_Categoria
                        where cate.Nombre == categoriasUnicas.Key
                        select new ProductoDto
                        {
                            codigoProducto = prod.codigoProducto,
                            Nombre = prod.Nombre,
                            Precio = prod.Precio,
                        }
                    ).ToList(),
                }
            ).ToListAsync();
            return pc1;
        }

        public async Task<List<ProductoCategoriaDTO>> MostraProductoCategoriaId(
            string? codigoP,
            string? codigoC
        )
        {
            var pc1 = await (
                from pc in _context.Producto_Categorias
                join p in _context.Productos on pc.producto_id equals p.Id_Producto
                join c in _context.Categorias on pc.categoria_id equals c.Id_Categoria
                where
                    pc.categoria_id == c.Id_Categoria
                    && pc.producto_id == p.Id_Producto
                    && c.codigoCategoria == codigoC
                    && p.codigoProducto == codigoP
                select new ProductoCategoriaDTO
                {
                    cate = new CategoriaDto
                    {
                        codigoCategoria = c.codigoCategoria,
                        Nombre = c.Nombre,
                    },
                    produ = new ProductoDto
                    {
                        codigoProducto = p.codigoProducto,
                        Nombre = p.Nombre,
                        Precio = p.Precio,
                    },
                }
            ).ToListAsync();
            return pc1;
        }

        public async Task<object> PostProductoCategoria(string codigoP, string codigoC)
        {
            var p = await _context.Productos.FirstOrDefaultAsync(pr =>
                pr.codigoProducto == codigoP
            );
            var c = await _context.Categorias.FirstOrDefaultAsync(ca =>
                ca.codigoCategoria == codigoC
            );
            if (p is null || c is null)
                return null;
            Producto_Categoria prca = new Producto_Categoria
            {
                categoria_id = c.Id_Categoria,
                producto_id = p.Id_Producto,
                categoria = c,
                producto = p,
            };
            _context.Producto_Categorias.Add(prca);
            await _context.SaveChangesAsync();
            return new { Codigo_Categoria = p.codigoProducto, Codigo_Producto = c.codigoCategoria };
        }
    }
}
