using System;
using System.Collections.Generic;

namespace Spotify_API.Infraestructure.Contexts
{
    public partial class Genero
    {
        public Genero()
        {
            Cancions = new HashSet<Cancion>();
        }

        public int IdGenero { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<Cancion> Cancions { get; set; }
    }
}
