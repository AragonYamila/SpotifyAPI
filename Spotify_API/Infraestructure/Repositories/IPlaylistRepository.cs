using Spotify_API.DTOs;
using Spotify_API.Infraestructure.Contexts;

namespace Spotify_API.Infraestructure.Repositories
{
    public interface IPlaylistRepository
    {
        void AgregarUnaPlaylist(Playlist playlist);
        List<PlaylistDTO> ObtenerPlaylistPorUsuario(int usuarioId);
        List<PlaylistDTO> ObtenerPlaylistPorNombre(string nombre);
        List<PlaylistDTO> ObtenerTodasLasPlaylists();
        List<PlaylistDTO> ObtenerPlaylistPorNombreYUsuario(string nombre, int usuario);
    }
}
