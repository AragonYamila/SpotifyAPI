using Spotify_API.DTOs;
using Spotify_API.Infraestructure.Contexts;

namespace Spotify_API.Infraestructure.Repositories
{
    public interface IUsuarioRepository
    {
        List<UsuarioDTO> GetUsuarios();
        Usuario RegistrarUsuario(Usuario nuevoUsuario);
        UsuarioDTO LoguearUsuario(string email, string contraseña);

    }
}
