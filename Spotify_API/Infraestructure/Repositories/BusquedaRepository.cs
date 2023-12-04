using Spotify_API.DTOs;
using Spotify_API.Infraestructure.Contexts;

namespace Spotify_API.Infraestructure.Repositories
{
    public class BusquedaRepository : IBusquedaRepository
    {
        private readonly DB_SpotifyContext _context;

        public BusquedaRepository(DB_SpotifyContext context)
        {
            _context = context;
        }

        public List<CancionDTO> ObtenerCancionPorAlbum(string nombreDelAlbum)
        {
            return _context.Cancions.Where(c => c.IdAlbumNavigation.Titulo.ToLower().Contains(nombreDelAlbum.ToLower()))
              .Select(c => new CancionDTO
              {
                  Titulo = c.Titulo,
                  IdAlbum = c.IdAlbum,
                  IdArtista = c.IdArtista,
                  IdGenero = c.IdGenero,
                  Duracion = c.Duracion,
                  artista = c.IdArtistaNavigation.Nombre,
                  genero = c.IdGeneroNavigation.Nombre,
                  album = c.IdAlbumNavigation.Titulo
              }).ToList();
        }

        public List<CancionDTO> ObtenerCancionPorArtista(string nombreDelArtista)
        {
            return _context.Cancions.Where(c => c.IdArtistaNavigation.Nombre.ToLower().Contains(nombreDelArtista.ToLower()))
                .Select(c => new CancionDTO
                {
                    Titulo = c.Titulo,
                    IdAlbum = c.IdAlbum,
                    IdArtista = c.IdArtista,
                    IdGenero = c.IdGenero,
                    Duracion = c.Duracion,
                    artista = c.IdArtistaNavigation.Nombre,
                    genero = c.IdGeneroNavigation.Nombre,
                    album = c.IdAlbumNavigation.Titulo
                }).ToList();
        }

        public List<CancionDTO> ObtenerCancionPorGenero(string nombreDelGenero)
        {
            return _context.Cancions.Where(c => c.IdGeneroNavigation.Nombre.ToLower().Contains(nombreDelGenero.ToLower()))
        .Select(c => new CancionDTO
        {
            Titulo = c.Titulo,
            IdAlbum = c.IdAlbum,
            IdArtista = c.IdArtista,
            IdGenero = c.IdGenero,
            Duracion = c.Duracion,
            artista = c.IdArtistaNavigation.Nombre,
            genero = c.IdGeneroNavigation.Nombre,
            album = c.IdAlbumNavigation.Titulo

        }).ToList();
        }

        public List<CancionDTO> ObtenerCancionPorTitulo(string titulo)
        {
            return _context.Cancions.Where(c => c.Titulo.ToLower().Contains(titulo.ToLower()))
                     .Select(c => new CancionDTO
             {
             Titulo = c.Titulo,
             IdAlbum = c.IdAlbum,
             IdArtista = c.IdArtista,
             IdGenero = c.IdGenero,
             Duracion = c.Duracion,
             artista = c.IdArtistaNavigation.Nombre,
             genero = c.IdGeneroNavigation.Nombre,
             album = c.IdAlbumNavigation.Titulo
             }).ToList();
        }
    }
}
