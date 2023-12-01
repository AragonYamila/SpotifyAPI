using System;
using System.Collections.Generic;

namespace Spotify_API.Infraestructure.Contexts
{
    public partial class CancionPlaylist
    {
        public int IdCancionPlaylist { get; set; }
        public int IdCancion { get; set; }
        public int IdPlaylist { get; set; }

        public virtual Cancion IdCancionNavigation { get; set; } = null!;
        public virtual Playlist IdPlaylistNavigation { get; set; } = null!;
    }
}
