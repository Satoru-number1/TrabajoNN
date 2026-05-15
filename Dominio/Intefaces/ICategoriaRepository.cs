using clean.Aplicaccion.Dtos;

namespace clean.Dominio.Interfaces
{
    public interface ICategoriaRepository
    {
        Task<List<CategoriaDto>> MostrarCategorias();
        Task<CategoriaDto> MostrarCategoriaId(string codigoCategoria);
        Task<CategoriaDto> PostCategoria(CategoriaDto categoria);
    }
}
