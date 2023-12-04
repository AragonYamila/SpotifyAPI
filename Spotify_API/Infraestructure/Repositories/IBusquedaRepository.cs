using Spotify_API.DTOs;

namespace Spotify_API.Infraestructure.Repositories
{
    public interface IBusquedaRepository
    {
        List<CancionDTO> ObtenerCancionPorTitulo(string titulo);
        List<CancionDTO> ObtenerCancionPorArtista(string nombreDelArtista);
        List<CancionDTO> ObtenerCancionPorGenero(string nombreDelGenero);
        List<CancionDTO> ObtenerCancionPorAlbum(string nombreDelAlbum);
        List<ArtistaDTO> ObtenerArtistaPorNombre(string nombreDelArtista);
        List<AlbumDTO> ObtenerAlbumPorTitulo(string tituloDelAlbum);
        List<AlbumDTO> ObtenerAlbumPorArtista(string nombreDelArtista);
    }
}
