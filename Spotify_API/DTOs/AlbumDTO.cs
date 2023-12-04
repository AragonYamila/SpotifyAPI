namespace Spotify_API.DTOs
{
    public class AlbumDTO
    {
        public string Titulo { get; set; } = null!;
        public DateTime Fecha { get; set; }
        public string? PortadaAlbum { get; set; }
        public TimeSpan Duracion { get; set; }
        public List<CancionDTO> Canciones { get; set;}

        public string NombreArtista { get; set; }
    }
}
