using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace clean.Aplicaccion.Dtos
{
    public class CategoriaDto
    {
        public string codigoCategoria { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
    }

    public class CategoriasDto
    {
        public string Nombre { get; set; } = string.Empty;
    }
}
