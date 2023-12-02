using Spotify_API.DTOs;
using Spotify_API.Infraestructure.Contexts;
using Spotify_API.Infraestructure.Repositories;

namespace Spotify_API.Domain.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuariorepository;
        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuariorepository=usuarioRepository;
        }
        public List<UsuarioDTO> GetUsuarios()
        {
            try
            {
                return  _usuariorepository.GetUsuarios();
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public UsuarioDTO LoguearUsuario(string email, string contraseña)
        {
            return _usuariorepository.LoguearUsuario(email, contraseña);
        }

        public Usuario RegistrarUsuario(Usuario nuevoUsuario)
        {
            return _usuariorepository.RegistrarUsuario(nuevoUsuario);
        }
        public bool ValidarClaves(string clave, string claveAComparar)
        {
            return clave.Equals(claveAComparar) ? true : false;
        }
    }
}
