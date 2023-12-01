using System;
using System.Collections.Generic;

namespace Spotify_API.Infraestructure.Contexts
{
    public partial class Cancion
    {
        public Cancion()
        {
            CancionPlaylists = new HashSet<CancionPlaylist>();
            Favoritos = new HashSet<Favorito>();
        }

        public int IdCancion { get; set; }
        public string Titulo { get; set; } = null!;
        public int IdAlbum { get; set; }
        public int IdArtista { get; set; }
        public int IdGenero { get; set; }
        public TimeSpan Duracion { get; set; }

        public virtual Album IdAlbumNavigation { get; set; } = null!;
        public virtual Artistum IdArtistaNavigation { get; set; } = null!;
        public virtual Genero IdGeneroNavigation { get; set; } = null!;
        public virtual ICollection<CancionPlaylist> CancionPlaylists { get; set; }
        public virtual ICollection<Favorito> Favoritos { get; set; }
    }
}
