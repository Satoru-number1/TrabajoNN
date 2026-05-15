namespace clean.Aplicaccion.Dtos
{
    public class ProductoCategoriaDTO
    {
        public CategoriaDto? cate { get; set; }
        public ProductoDto? produ { get; set; }
    }

    public class ProductosCategoriasDTO
    {
        public CategoriasDto? cate { get; set; }
        public List<ProductoDto>? produ { get; set; }
    }
}
