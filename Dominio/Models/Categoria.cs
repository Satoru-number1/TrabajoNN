using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace clean.Dominio.Models
{
    public class Categoria
    {
        [Key]
        public int Id_Categoria { get; set; }
        public string codigoCategoria { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public List<Producto_Categoria>? productos { get; set; }
    }
}
