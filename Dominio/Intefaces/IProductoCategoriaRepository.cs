using clean.Aplicaccion.Dtos;

namespace clean.Dominio.Interfaces
{
    public interface IProductoCategoriaRepository
    {
        Task<List<ProductosCategoriasDTO>> MostraProductoCategoria();
        Task<List<ProductoCategoriaDTO>> MostraProductoCategoriaId(
            string? codigoP,
            string? codigoC
        );
        Task<object> PostProductoCategoria(string codigoP, string codigoC);
    }
}
