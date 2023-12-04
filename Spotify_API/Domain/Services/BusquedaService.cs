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

        public List<CancionDTO> ObtenerCancionPorAlbum(string nombreDelAlbum)
        {
            return _busquedaRepository.ObtenerCancionPorAlbum(nombreDelAlbum);
        }

        public List<CancionDTO> ObtenerCancionPorArtista(string nombreDelArtista)
        {
            return _busquedaRepository.ObtenerCancionPorArtista(nombreDelArtista);
        }

        public List<CancionDTO> ObtenerCancionPorGenero(string nombreDelGenero)
        {
            return _busquedaRepository.ObtenerCancionPorGenero(nombreDelGenero);

        }

        public List<CancionDTO> ObtenerCancionPorTitulo(string nombre)
        {
            return _busquedaRepository.ObtenerCancionPorTitulo(nombre);
        }
    }
}
