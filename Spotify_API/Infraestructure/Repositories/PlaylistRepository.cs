using Microsoft.EntityFrameworkCore;
using Spotify_API.DTOs;
using Spotify_API.Infraestructure.Contexts;
using System.Collections.Generic;

namespace Spotify_API.Infraestructure.Repositories
{
    public class PlaylistRepository : IPlaylistRepository { 


        private readonly DB_SpotifyContext _context;
        public PlaylistRepository(DB_SpotifyContext context) {
                _context = context;
        }
        public void AgregarUnaPlaylist(Playlist playlist)
        {
                _context.Playlists.Add(playlist);
                _context.SaveChanges();
        }
        public List<PlaylistDTO> ObtenerPlaylistPorUsuario(int usuarioId)
        {
            return _context.Playlists.Where(p=> p.IdUsuario == usuarioId)
                .Select(pd=> new PlaylistDTO
                {
                    PortadaPlaylist=pd.PortadaPlaylist,
                    Titulo=pd.Titulo,
                    Descripcion=pd.Descripcion,
                    UsuarioNombre=pd.IdUsuarioNavigation.Nombre
                   // Canciones=pd.CancionPlaylists
                }).ToList();
        }
        public List<PlaylistDTO> ObtenerPlaylistPorNombre(string nombre) {

            return _context.Playlists.Where(p => p.Titulo.ToLower().Contains(nombre.ToLower()))
                .Select(pd => new PlaylistDTO
                {
                    PortadaPlaylist = pd.PortadaPlaylist,
                    Titulo = pd.Titulo,
                    Descripcion = pd.Descripcion,
                    UsuarioNombre = pd.IdUsuarioNavigation.Nombre
                }).ToList();
        }
        public List<PlaylistDTO> ObtenerTodasLasPlaylists()
        {
            return _context.Playlists.Select(p => new PlaylistDTO
            {
                PortadaPlaylist = p.PortadaPlaylist,
                Titulo = p.Titulo,
                Descripcion = p.Descripcion,
                UsuarioNombre = p.IdUsuarioNavigation.Nombre
            }).ToList();
        }

        public List<PlaylistDTO> ObtenerPlaylistPorNombreYUsuario(string nombre, int IdUsuario)
        {
            return _context.Playlists.Where(p => p.Titulo.ToLower()== nombre.ToLower())
                                     .Join(_context.Usuarios, p => p.IdUsuario,u=>u.IdUsuario,(p, u) => new
                                     PlaylistDTO
                                     {
                                         PortadaPlaylist=p.PortadaPlaylist,
                                         Titulo=p.Titulo,
                                         Descripcion=p.Descripcion,
                                         UsuarioNombre=p.IdUsuarioNavigation.Nombre,
                                         Usuario=p.IdUsuario

                                     }).ToList();
                                      
        }
    }
}
