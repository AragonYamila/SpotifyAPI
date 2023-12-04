using Spotify_API.DTOs;

namespace Spotify_API.Domain.Services
{
    public interface IBusquedaService
    {
        List<CancionDTO> ObtenerCancionPorTodosLosCampos(string campo);
        List<AlbumDTO> ObtenerAlbumPorTodosLosCampos(string campo);
        List<ArtistaDTO> ObtenerArtistaPorNombre(string nombreDelArtista);

    }
}
