using System;
using System.Collections.Generic;

namespace Spotify_API.Infraestructure.Contexts
{
    public partial class Playlist
    {
        public Playlist()
        {
            CancionPlaylists = new HashSet<CancionPlaylist>();
            FollowPlaylists = new HashSet<FollowPlaylist>();
        }

        public int IdPlaylist { get; set; }
        public string? PortadaPlaylist { get; set; }
        public string Titulo { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public TimeSpan Duracion { get; set; }
        public int IdUsuario { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
        public virtual ICollection<CancionPlaylist> CancionPlaylists { get; set; }
        public virtual ICollection<FollowPlaylist> FollowPlaylists { get; set; }
    }
}
