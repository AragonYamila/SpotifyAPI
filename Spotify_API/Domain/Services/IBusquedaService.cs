using Spotify_API.DTOs;

namespace Spotify_API.Domain.Services
{
    public interface IBusquedaService
    {
        List<CancionDTO> ObtenerCancionPorTitulo(string nombre);
        List<CancionDTO> ObtenerCancionPorArtista(string nombreDelArtista);
        List<CancionDTO> ObtenerCancionPorAlbum(string nombreDelAlbum);
        List<CancionDTO> ObtenerCancionPorGenero(string nombreDelGenero);
    }
}
