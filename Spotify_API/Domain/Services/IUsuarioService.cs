using Spotify_API.DTOs;
using Spotify_API.Infraestructure.Contexts;

namespace Spotify_API.Domain.Services
{
    public interface IUsuarioService
    {
        List<UsuarioDTO> GetUsuarios();
        Usuario RegistrarUsuario(Usuario nuevoUsuario);
        UsuarioDTO LoguearUsuario(string email, string contraseña);
        bool ValidarClaves(string clave, string claveAComparar);
    }
}
