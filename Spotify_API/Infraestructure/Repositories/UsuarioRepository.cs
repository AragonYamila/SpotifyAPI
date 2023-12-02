using Microsoft.EntityFrameworkCore;
using Spotify_API.DTOs;
using Spotify_API.Infraestructure.Contexts;

namespace Spotify_API.Infraestructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DB_SpotifyContext _context;
        public UsuarioRepository(DB_SpotifyContext context) 
        {
            _context = context;
        }
        public List<UsuarioDTO> GetUsuarios()
        {
            return  _context.Usuarios.Select(u => new UsuarioDTO
            {
                Nombre = u.Nombre,
                Apellido = u.Apellido,
                Email = u.Email,
                Contraseña = u.Contraseña,
                FotoPerfil = u.FotoPerfil
            }).ToList();
        }

        public UsuarioDTO LoguearUsuario(string email, string contraseña)
        {
            return _context.Usuarios.Where(u => u.Email.Equals(email) && u.Contraseña.Equals(contraseña))
                                    .Select(u => new UsuarioDTO
                                    {
                                        Nombre = u.Nombre,
                                        Apellido = u.Apellido,
                                        Email = u.Email,
                                        FotoPerfil = u.FotoPerfil
                                    }).FirstOrDefault();

        }

        public Usuario RegistrarUsuario(Usuario nuevoUsuario)
        {
            Usuario usuarioARegistrar= _context.Usuarios.FirstOrDefault(u  => u.Email.Equals(nuevoUsuario.Email));
           
            if (usuarioARegistrar == null)
            {
                _context.Usuarios.Add(nuevoUsuario);
                _context.SaveChanges();
            }
            return usuarioARegistrar;

        }
    }
}
