using Spotify_API.DTOs;
using Spotify_API.Infraestructure.Repositories;

namespace Spotify_API.Domain.Services
{
    public class BusquedaService : IBusquedaService
    {
        private readonly IBusquedaRepository _busquedaRepository;
        public BusquedaService(IBusquedaRepository busquedaRepository)
        {
            _busquedaRepository = busquedaRepository;
        }

        public List<ArtistaDTO> ObtenerArtistaPorNombre(string nombreDelArtista)
        {
            return _busquedaRepository.ObtenerArtistaPorNombre(nombreDelArtista);
        }

        public List<CancionDTO> ObtenerCancionPorTodosLosCampos(string campo)
        {
            List<CancionDTO> cancionPorTitulo = _busquedaRepository.ObtenerCancionPorTitulo(campo);
            List<CancionDTO> cancionPorArtista = _busquedaRepository.ObtenerCancionPorArtista(campo);
            List<CancionDTO> cancionPorGenero = _busquedaRepository.ObtenerCancionPorGenero(campo);
            List<CancionDTO> cancionPorAlbum = _busquedaRepository.ObtenerCancionPorAlbum(campo);

            List<CancionDTO> canciones = new List<CancionDTO>();
            canciones.AddRange(cancionPorTitulo);
            canciones.AddRange(cancionPorAlbum);
            canciones.AddRange(cancionPorArtista);
            canciones.AddRange(cancionPorGenero);

            return canciones;
        }
        public List<AlbumDTO> ObtenerAlbumPorTodosLosCampos(string campo)
        {
            List<AlbumDTO> albumPorTitulo = _busquedaRepository.ObtenerAlbumPorTitulo(campo);
            List<AlbumDTO> albumPorArtista = _busquedaRepository.ObtenerAlbumPorArtista(campo);

            List<AlbumDTO> albums = new List<AlbumDTO>();
            albums.AddRange(albumPorTitulo);
            albums.AddRange(albumPorArtista);

            return albums;
        }
    }
}
