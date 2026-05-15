using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using clean.Dominio.Models;
using Microsoft.EntityFrameworkCore;

namespace clean.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Producto> Productos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Producto_Categoria> Producto_Categorias { get; set; }
    }
}
