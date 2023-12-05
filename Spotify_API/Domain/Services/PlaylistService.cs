using Spotify_API.DTOs;
using Spotify_API.Infraestructure.Contexts;
using Spotify_API.Infraestructure.Repositories;

namespace Spotify_API.Domain.Services
{
    public class PlaylistService : IPlaylistService
    {
        private readonly IPlaylistRepository _playlistRepository;
        public PlaylistService(IPlaylistRepository playlistRepository)
        {
            _playlistRepository = playlistRepository;
        }

        public void AgregarUnaPlaylist(Playlist playlist)
        {
             _playlistRepository.AgregarUnaPlaylist(playlist);
        }

        public List<PlaylistDTO> ObtenerPlaylistPorNombre(string nombre)
        {
            return _playlistRepository.ObtenerPlaylistPorNombre(nombre);
        }

        public List<PlaylistDTO> ObtenerPlaylistPorUsuario(int usuarioId)
        {
            return _playlistRepository.ObtenerPlaylistPorUsuario(usuarioId);
        }

        public List<PlaylistDTO> ObtenerTodasLasPlaylists()
        {
            return _playlistRepository.ObtenerTodasLasPlaylists();
        }

        public void CrearPlaylistPorUsuario(Playlist playlistNueva)
        { 

            if (_playlistRepository.ObtenerPlaylistPorNombreYUsuario(playlistNueva.Titulo, playlistNueva.IdUsuario).Count <= 0)
            {
                _playlistRepository.AgregarUnaPlaylist(playlistNueva);
            }
            else
            {
                throw new Exception("Ya existe esta playlist");
                
            }
        }

        public List<PlaylistDTO> ObtenerPlaylistPorNombreYUsuario(string nombre, int usuario)
        {
            return _playlistRepository.ObtenerPlaylistPorNombreYUsuario(nombre, usuario);
        }
    }
}
