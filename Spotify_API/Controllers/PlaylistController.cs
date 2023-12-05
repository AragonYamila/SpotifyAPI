using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Spotify_API.Domain.Services;
using Spotify_API.DTOs;
using Spotify_API.Infraestructure.Contexts;

namespace Spotify_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaylistController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IPlaylistService _playlistService;
        public PlaylistController(IUsuarioService usuarioService, IPlaylistService playlistService)
        {
            _usuarioService = usuarioService;
            _playlistService = playlistService;
        }
        private void nuevaPlaylist(PlaylistDTO playlist)
        {
            Playlist playlistAgregar = new Playlist();

            playlistAgregar.Titulo = playlist.Titulo;
            playlistAgregar.PortadaPlaylist = playlist.PortadaPlaylist;
            playlistAgregar.Descripcion = playlist.Descripcion;
            playlistAgregar.IdUsuario = playlist.Usuario;
            _playlistService.AgregarUnaPlaylist(playlistAgregar);
        }
        [HttpPost("CrearPlaylist")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PlaylistDTO))]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(string))]
        public dynamic CrearPlaylist([FromBody] PlaylistDTO playlistDTO)
        {
            {
                try
                {
                    nuevaPlaylist(playlistDTO);

                    return new
                    {
                        status = StatusCodes.Status200OK,
                        message = playlistDTO
                    };
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }
        [HttpGet("BuscarPlaylistPorNombre/{nombre}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PlaylistDTO))]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(string))]
        public dynamic ObtenerPlaylistPorNombre(string nombre)
        {
            try
            {
                List<PlaylistDTO> playlists = _playlistService.ObtenerPlaylistPorNombre(nombre);
                if (playlists.Count > 0)
                {
                    return Ok(new
                    {
                        status = StatusCodes.Status200OK,
                        message = playlists
                    });
                }
                else
                {
                    return new
                    {
                        status = StatusCodes.Status204NoContent,
                        message = ("No se encontraron playlists con ese nombre")
                    };
                }



            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("BuscarPlaylistPorUsuario/{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PlaylistDTO))]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(string))]
        public dynamic ObtenerPlaylistPorUsuario(int Id)
        {
            try
            {
                List<PlaylistDTO> playlists = _playlistService.ObtenerPlaylistPorUsuario(Id);
                if (playlists.Count > 0)
                {
                    return Ok(new
                    {
                        status = StatusCodes.Status200OK,
                        message = playlists
                    });
                }
                else
                {
                    return NotFound(new
                    {
                        status = StatusCodes.Status204NoContent,
                        message = ("No se encontraron playlists con ese usuario")
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("BuscarPlaylists")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PlaylistDTO))]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(string))]
        public dynamic ObtenerPlaylists()
        {
            try
            {
                List<PlaylistDTO> playlists = _playlistService.ObtenerTodasLasPlaylists();
                if (playlists.Count > 0)
                {
                    return Ok(new
                    {
                        status = StatusCodes.Status200OK,
                        message = playlists
                    });
                }


                return NotFound(new
                {
                    status = StatusCodes.Status204NoContent,
                    message = ("No se encontraron playlists ")
                });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("BuscarPlaylistsPorNombreYUsuario/{nombrePlaylist}/{usuarioId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PlaylistDTO))]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(string))]
        public dynamic ObtenerPlaylistsPorNombreYUsuario(string nombrePlaylist, int usuarioId)
        {
            try
            {
                List<PlaylistDTO> playlists = _playlistService.ObtenerPlaylistPorNombreYUsuario(nombrePlaylist, usuarioId);
                if (playlists.Count > 0)
                {
                    return Ok(new
                    {
                        status = StatusCodes.Status200OK,
                        message = playlists
                    });
                }


                return NotFound(new
                {
                    status = StatusCodes.Status204NoContent,
                    message = ("No se encontraron playlists ")
                });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
