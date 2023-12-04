using Spotify_API.Infraestructure.Contexts;

namespace Spotify_API.DTOs
{
    public class CancionDTO
    {
        public string Titulo { get; set; } = null!;
        public int IdAlbum { get; set; }
        public int IdArtista { get; set; }
        public int IdGenero { get; set; }
        public TimeSpan Duracion { get; set; }
        public string artista { get; set; }
        public string genero { get; set; }
        public string album { get; set;}

    }
}
