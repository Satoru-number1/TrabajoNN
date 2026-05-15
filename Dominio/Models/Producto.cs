using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace clean.Dominio.Models
{
    public class Producto
    {
        [Key]
		public int Id_Producto {get;set;}
		public string codigoProducto {get;set;}
		public string Nombre {get;set;}
		public double Precio {get;set;}
		public List<Producto_Categoria> categorias {get;set;} 
    }
}