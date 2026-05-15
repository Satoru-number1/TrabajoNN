using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace clean.Dominio.Models
{
    public class Producto_Categoria
    {
        [Key]
        public int Id_Producto_Categoria { get; set; }
        public int categoria_id { get; set;}
        public int producto_id { get; set;}
        [ForeignKey("Id_Categoria")]
        [JsonIgnore]
        public Categoria categoria { get; set; }
        [ForeignKey("Id_Producto")]
        [JsonIgnore]
        public Producto producto { get; set; }
    }
}