using clean.Aplicaccion.Dtos;
using clean.Data;
using clean.Dominio.Interfaces;
using clean.Dominio.Models;
using Microsoft.EntityFrameworkCore;

namespace clean.Repository
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AppDbContext _context;

        public CategoriaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<CategoriaDto> MostrarCategoriaId(string codigoCategoria)
        {
            var categoria = await (
                from c in _context.Categorias
                where c.codigoCategoria == codigoCategoria
                select new CategoriaDto { codigoCategoria = c.codigoCategoria, Nombre = c.Nombre }
            ).FirstOrDefaultAsync();
            if (categoria is null)
                return null;
            return categoria;
        }

        public async Task<List<CategoriaDto>> MostrarCategorias()
        {
            var categorias = await (
                from c in _context.Categorias
                select new CategoriaDto { codigoCategoria = c.codigoCategoria, Nombre = c.Nombre }
            ).ToListAsync();
            return categorias;
        }

        public async Task<CategoriaDto> PostCategoria(CategoriaDto categoria)
        {
            var categoria1 = await _context.Categorias.FirstOrDefaultAsync(c =>
                c.codigoCategoria == categoria.codigoCategoria
            );
            if (categoria1 != null)
                return null;
            Categoria cat = new Categoria
            {
                codigoCategoria = categoria.codigoCategoria,
                Nombre = categoria.Nombre,
            };
            _context.Categorias.Add(cat);
            await _context.SaveChangesAsync();
            return categoria;
        }
    }
}
