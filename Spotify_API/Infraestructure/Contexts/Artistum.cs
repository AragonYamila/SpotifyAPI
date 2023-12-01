using System;
using System.Collections.Generic;

namespace Spotify_API.Infraestructure.Contexts
{
    public partial class Artistum
    {
        public Artistum()
        {
            Albums = new HashSet<Album>();
            Cancions = new HashSet<Cancion>();
            Follows = new HashSet<Follow>();
        }

        public int IdArtista { get; set; }
        public string Nombre { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public string? FotoArtista { get; set; }

        public virtual ICollection<Album> Albums { get; set; }
        public virtual ICollection<Cancion> Cancions { get; set; }
        public virtual ICollection<Follow> Follows { get; set; }
    }
}
