using System;
using System.Collections.Generic;

namespace Spotify_API.Infraestructure.Contexts
{
    public partial class FollowUsuario
    {
        public int IdFollowUsuario { get; set; }
        public int IdUsuario { get; set; }
        public int IdUsuarioSeguido { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
        public virtual Usuario IdUsuarioSeguidoNavigation { get; set; } = null!;
    }
}
