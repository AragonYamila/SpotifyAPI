namespace Spotify_API.DTOs
{
    public class ArtistaDTO
    {
        public string Nombre { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public string? FotoArtista { get; set; }
        public List<AlbumDTO> Album { get; set; }
        public List<CancionDTO> Canciones { get; set;}

    }
}
