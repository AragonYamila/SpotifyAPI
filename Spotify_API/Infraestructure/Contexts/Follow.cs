using System;
using System.Collections.Generic;

namespace Spotify_API.Infraestructure.Contexts
{
    public partial class Follow
    {
        public int IdFollow { get; set; }
        public int IdUsuario { get; set; }
        public int IdArtista { get; set; }

        public virtual Artistum IdArtistaNavigation { get; set; } = null!;
        public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
    }
}
