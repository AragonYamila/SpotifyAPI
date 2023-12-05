namespace Spotify_API.DTOs
{
    public class PlaylistDTO
    {
        public int IdPlaylist { get; set; }
        public string? PortadaPlaylist { get; set; }
        public string Titulo { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
      public string?UsuarioNombre { get; set; }
        public int Usuario { get; set; } 
     // public List<CancionDTO> Canciones { get; set; }

    }
}
