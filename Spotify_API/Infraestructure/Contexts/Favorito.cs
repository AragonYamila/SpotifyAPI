using System;
using System.Collections.Generic;

namespace Spotify_API.Infraestructure.Contexts
{
    public partial class Favorito
    {
        public int IdFavorito { get; set; }
        public int IdCancion { get; set; }
        public int IdUsuario { get; set; }

        public virtual Cancion IdCancionNavigation { get; set; } = null!;
        public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
    }
}
