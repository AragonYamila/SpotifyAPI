using System;
using System.Collections.Generic;

namespace Spotify_API.Infraestructure.Contexts
{
    public partial class FollowPlaylist
    {
        public int IdFollowPlaylist { get; set; }
        public int IdUsuario { get; set; }
        public int IdPlaylist { get; set; }

        public virtual Playlist IdPlaylistNavigation { get; set; } = null!;
        public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
    }
}
