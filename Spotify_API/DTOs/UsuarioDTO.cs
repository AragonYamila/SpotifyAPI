namespace Spotify_API.DTOs
{
    public class UsuarioDTO
    {
        public int IdUsuario { get; set; }

        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Contraseña { get; set; } = null!;
        public string ContraseñaAComparar { get; set; } = null!;
        public string? FotoPerfil { get; set; }
    }
}
