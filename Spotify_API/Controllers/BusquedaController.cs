using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Spotify_API.Domain.Services;
using Spotify_API.DTOs;

namespace Spotify_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusquedaController : ControllerBase
    {
        private readonly IBusquedaService _busquedaService;
        public BusquedaController(IBusquedaService busquedaService) 
        {
            _busquedaService = busquedaService;
        }
        [HttpGet("BuscarCancionPorTitulo/{titulo}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CancionDTO))]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(string))]

        public dynamic BuscarCancionPorTitulo(string titulo)
        {
            try
            {
                List<CancionDTO> canciones = _busquedaService.ObtenerCancionPorTitulo(titulo);

                if (canciones.Count() > 0)
                {
                    return Ok(canciones);
                }
                else
                {
                    return new
                    {
                        status = StatusCodes.Status204NoContent,
                        message = ("No se encontraron canciones con ese titulo")
                    };
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet("BuscarCancionPorArtista/{nombreDelArtista}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CancionDTO))]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(string))]

        public dynamic BuscarCancionPorArtista(string nombreDelArtista)
        {
            try
            {
                List<CancionDTO> canciones = _busquedaService.ObtenerCancionPorArtista(nombreDelArtista);

                if (canciones.Count() > 0)
                {
                    return Ok(canciones);
                }
                else
                {
                    return new
                    {
                        status = StatusCodes.Status204NoContent,
                        message = ("No se encontraron canciones de ese artista")
                    };
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        [HttpGet("BuscarCancionPorGenero/{nombreDelGenero}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CancionDTO))]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(string))]

        public dynamic BuscarCancionPorGenero(string nombreDelGenero)
        {
            try
            {
                List<CancionDTO> canciones = _busquedaService.ObtenerCancionPorGenero(nombreDelGenero);

                if (canciones.Count() > 0)
                {
                    return Ok(canciones);
                }
                else
                {
                    return new
                    {
                        status = StatusCodes.Status204NoContent,
                        message = ("No se encontraron canciones de ese genero")
                    };
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        [HttpGet("BuscarCancionPorAlbum/{nombreDelAlbum}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CancionDTO))]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(string))]

        public dynamic BuscarCancionPorAlbum(string nombreDelAlbum)
        {
            try
            {
                List<CancionDTO> canciones = _busquedaService.ObtenerCancionPorAlbum(nombreDelAlbum);

                if (canciones.Count() > 0)
                {
                    return Ok(canciones);
                }
                else
                {
                    return new
                    {
                        status = StatusCodes.Status204NoContent,
                        message = ("No se encontraron canciones de ese album")
                    };
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
