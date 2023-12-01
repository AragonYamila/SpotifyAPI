using System;
using System.Collections.Generic;

namespace Spotify_API.Infraestructure.Contexts
{
    public partial class Album
    {
        public Album()
        {
            Cancions = new HashSet<Cancion>();
        }

        public int IdAlbum { get; set; }
        public string Titulo { get; set; } = null!;
        public int IdArtista { get; set; }
        public DateTime Fecha { get; set; }
        public string? PortadaAlbum { get; set; }
        public TimeSpan Duracion { get; set; }

        public virtual Artistum IdArtistaNavigation { get; set; } = null!;
        public virtual ICollection<Cancion> Cancions { get; set; }
    }
}
