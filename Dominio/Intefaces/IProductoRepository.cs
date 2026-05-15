using clean.Aplicaccion.Dtos;

namespace clean.Dominio.Interfaces
{
    public interface IProductoRepository
    {
        Task<List<ProductoDto>> MostrarProductos();
        Task<ProductoDto> MostrarProductoId(string codigoProducto);
        Task<ProductoDto> PostProducto(ProductoDto producto);
    }
}
