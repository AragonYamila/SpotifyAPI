using System;
using System.Collections.Generic;

namespace Spotify_API.Infraestructure.Contexts
{
    public partial class Usuario
    {
        public Usuario()
        {
            Favoritos = new HashSet<Favorito>();
            FollowPlaylists = new HashSet<FollowPlaylist>();
            FollowUsuarioIdUsuarioNavigations = new HashSet<FollowUsuario>();
            FollowUsuarioIdUsuarioSeguidoNavigations = new HashSet<FollowUsuario>();
            Follows = new HashSet<Follow>();
            Playlists = new HashSet<Playlist>();
        }

        public int IdUsuario { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Contraseña { get; set; } = null!;
        public string? FotoPerfil { get; set; }

        public virtual ICollection<Favorito> Favoritos { get; set; }
        public virtual ICollection<FollowPlaylist> FollowPlaylists { get; set; }
        public virtual ICollection<FollowUsuario> FollowUsuarioIdUsuarioNavigations { get; set; }
        public virtual ICollection<FollowUsuario> FollowUsuarioIdUsuarioSeguidoNavigations { get; set; }
        public virtual ICollection<Follow> Follows { get; set; }
        public virtual ICollection<Playlist> Playlists { get; set; }
    }
}
