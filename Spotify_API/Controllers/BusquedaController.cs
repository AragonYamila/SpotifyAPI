using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Spotify_API.Domain.Services;
using Spotify_API.DTOs;
using System.Linq.Expressions;

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
        [HttpGet("Buscar/{campo}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CancionDTO))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AlbumDTO))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ArtistaDTO))]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(string))]

        public dynamic Buscar(string campo)
        {
            try
            {
                List<CancionDTO> canciones = _busquedaService.ObtenerCancionPorTodosLosCampos(campo);
                List<AlbumDTO> albums = _busquedaService.ObtenerAlbumPorTodosLosCampos(campo);
                List<ArtistaDTO> artista=_busquedaService.ObtenerArtistaPorNombre(campo);
                
                if (artista.Count > 0 || canciones.Count() > 0 || albums.Count>0)
                {
                    return Ok(new
                    {
                        datosArtista= artista,
                        datosCanciones= canciones,
                        datosAlbums= albums
                    });
                }
                

                return NotFound(new
                {
                        status = StatusCodes.Status204NoContent,
                        message = ("No se encontraron resultados")
                });
                    
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
  

    }
}
