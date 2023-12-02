using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Spotify_API.Domain.Services;
using Spotify_API.DTOs;
using Spotify_API.Infraestructure.Contexts;

namespace Spotify_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }
        [HttpGet("GetUsuarios")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<UsuarioDTO>))]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(bool))]
        public dynamic GetUsuarios()
        {
            try
            {
                List<UsuarioDTO> usuarios = _usuarioService.GetUsuarios();
                return usuarios.Count != 0 ? new { statusCode = StatusCodes.Status200OK, usuarios } : new { statusCode = StatusCodes.Status204NoContent, message = "No se encontraron resultados." };


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("RegistrarUsuario")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UsuarioDTO))]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(string))]

        public dynamic RegistrarUsuario([FromBody] UsuarioDTO usuario)
        {
            try
            {

                bool validacionClave = _usuarioService.ValidarClaves(usuario.Contraseña, usuario.ContraseñaAComparar);

                if (validacionClave==true)
                {
                    nuevoUsuario(usuario);

                    return Ok($"Se registro correctamente: {usuario.Nombre} {usuario.Apellido}");

                }
                else
                {
                    return new
                    {
                        status = StatusCodes.Status204NoContent,
                        message = "Las claves no coinciden"
                    };
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet("IniciarSesion")]
        [ProducesResponseType(StatusCodes.Status200OK,Type = typeof(UsuarioDTO))]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type =typeof(string))]
        public dynamic IniciarSesion(string email,string clave)
        {
            try
            {
                UsuarioDTO logueado= _usuarioService.LoguearUsuario(email, clave);
                if (logueado != null)
                {
                    return new
                    {
                        status = StatusCodes.Status200OK,
                        message = ($"{logueado.Nombre} {logueado.Apellido} ha iniciado sesion")
                    };
                }
                else
                {
                    return new
                    {
                        status = StatusCodes.Status204NoContent,
                        message = ("Usuario y/o contraseña incorrectos")
                    };
                }
                   
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        private Usuario nuevoUsuario(UsuarioDTO usuario)
        {
            Usuario usuarioARegistrar = new Usuario();

            usuarioARegistrar.Nombre = usuario.Nombre;
            usuarioARegistrar.Apellido = usuario.Apellido;
            usuarioARegistrar.Email = usuario.Email;
            usuarioARegistrar.Contraseña = usuario.Contraseña;
            usuarioARegistrar.FotoPerfil = usuario.FotoPerfil;

            return _usuarioService.RegistrarUsuario(usuarioARegistrar);
        }
    }
}
