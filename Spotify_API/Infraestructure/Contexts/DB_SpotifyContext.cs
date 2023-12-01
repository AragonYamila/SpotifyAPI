using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Spotify_API.Infraestructure.Contexts
{
    public partial class DB_SpotifyContext : DbContext
    {
        public DB_SpotifyContext()
        {
        }

        public DB_SpotifyContext(DbContextOptions<DB_SpotifyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Album> Albums { get; set; } = null!;
        public virtual DbSet<Artistum> Artista { get; set; } = null!;
        public virtual DbSet<Cancion> Cancions { get; set; } = null!;
        public virtual DbSet<CancionPlaylist> CancionPlaylists { get; set; } = null!;
        public virtual DbSet<Favorito> Favoritos { get; set; } = null!;
        public virtual DbSet<Follow> Follows { get; set; } = null!;
        public virtual DbSet<FollowPlaylist> FollowPlaylists { get; set; } = null!;
        public virtual DbSet<FollowUsuario> FollowUsuarios { get; set; } = null!;
        public virtual DbSet<Genero> Generos { get; set; } = null!;
        public virtual DbSet<Playlist> Playlists { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=DB_Spotify;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Album>(entity =>
            {
                entity.HasKey(e => e.IdAlbum)
                    .HasName("PK__Album__BF9C2A2264BBCCC1");

                entity.ToTable("Album");

                entity.Property(e => e.Duracion).HasColumnType("time(0)");

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.PortadaAlbum).HasMaxLength(300);

                entity.Property(e => e.Titulo).HasMaxLength(50);

                entity.HasOne(d => d.IdArtistaNavigation)
                    .WithMany(p => p.Albums)
                    .HasForeignKey(d => d.IdArtista)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Album__IdArtista__4F7CD00D");
            });

            modelBuilder.Entity<Artistum>(entity =>
            {
                entity.HasKey(e => e.IdArtista)
                    .HasName("PK__Artista__0A2C1925BB5BF2DE");

                entity.Property(e => e.Descripcion).HasMaxLength(200);

                entity.Property(e => e.FotoArtista).HasMaxLength(300);

                entity.Property(e => e.Nombre).HasMaxLength(50);
            });

            modelBuilder.Entity<Cancion>(entity =>
            {
                entity.HasKey(e => e.IdCancion)
                    .HasName("PK__Cancion__A1358A25EF62B259");

                entity.ToTable("Cancion");

                entity.Property(e => e.Duracion).HasColumnType("time(0)");

                entity.Property(e => e.Titulo).HasMaxLength(50);

                entity.HasOne(d => d.IdAlbumNavigation)
                    .WithMany(p => p.Cancions)
                    .HasForeignKey(d => d.IdAlbum)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Cancion__IdAlbum__52593CB8");

                entity.HasOne(d => d.IdArtistaNavigation)
                    .WithMany(p => p.Cancions)
                    .HasForeignKey(d => d.IdArtista)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Cancion__IdArtis__534D60F1");

                entity.HasOne(d => d.IdGeneroNavigation)
                    .WithMany(p => p.Cancions)
                    .HasForeignKey(d => d.IdGenero)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Cancion__IdGener__5441852A");
            });

            modelBuilder.Entity<CancionPlaylist>(entity =>
            {
                entity.HasKey(e => e.IdCancionPlaylist)
                    .HasName("PK__CancionP__59C918CDD23EF564");

                entity.ToTable("CancionPlaylist");

                entity.HasOne(d => d.IdCancionNavigation)
                    .WithMany(p => p.CancionPlaylists)
                    .HasForeignKey(d => d.IdCancion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CancionPl__IdCan__5DCAEF64");

                entity.HasOne(d => d.IdPlaylistNavigation)
                    .WithMany(p => p.CancionPlaylists)
                    .HasForeignKey(d => d.IdPlaylist)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CancionPl__IdPla__5EBF139D");
            });

            modelBuilder.Entity<Favorito>(entity =>
            {
                entity.HasKey(e => e.IdFavorito)
                    .HasName("PK__Favorito__39DCEE5011FAE369");

                entity.ToTable("Favorito");

                entity.HasOne(d => d.IdCancionNavigation)
                    .WithMany(p => p.Favoritos)
                    .HasForeignKey(d => d.IdCancion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Favorito__IdCanc__571DF1D5");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Favoritos)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Favorito__IdUsua__5812160E");
            });

            modelBuilder.Entity<Follow>(entity =>
            {
                entity.HasKey(e => e.IdFollow)
                    .HasName("PK__Follow__85E571E95CDC2E89");

                entity.ToTable("Follow");

                entity.HasOne(d => d.IdArtistaNavigation)
                    .WithMany(p => p.Follows)
                    .HasForeignKey(d => d.IdArtista)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Follow__IdArtist__628FA481");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Follows)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Follow__IdUsuari__619B8048");
            });

            modelBuilder.Entity<FollowPlaylist>(entity =>
            {
                entity.HasKey(e => e.IdFollowPlaylist)
                    .HasName("PK__FollowPl__93590476B4A2EDA8");

                entity.ToTable("FollowPlaylist");

                entity.HasOne(d => d.IdPlaylistNavigation)
                    .WithMany(p => p.FollowPlaylists)
                    .HasForeignKey(d => d.IdPlaylist)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__FollowPla__IdPla__66603565");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.FollowPlaylists)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__FollowPla__IdUsu__656C112C");
            });

            modelBuilder.Entity<FollowUsuario>(entity =>
            {
                entity.HasKey(e => e.IdFollowUsuario)
                    .HasName("PK__FollowUs__96A52D3F807EC65C");

                entity.ToTable("FollowUsuario");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.FollowUsuarioIdUsuarioNavigations)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__FollowUsu__IdUsu__693CA210");

                entity.HasOne(d => d.IdUsuarioSeguidoNavigation)
                    .WithMany(p => p.FollowUsuarioIdUsuarioSeguidoNavigations)
                    .HasForeignKey(d => d.IdUsuarioSeguido)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__FollowUsu__IdUsu__6A30C649");
            });

            modelBuilder.Entity<Genero>(entity =>
            {
                entity.HasKey(e => e.IdGenero)
                    .HasName("PK__Genero__0F834988B6A32EA2");

                entity.ToTable("Genero");

                entity.Property(e => e.Nombre).HasMaxLength(20);
            });

            modelBuilder.Entity<Playlist>(entity =>
            {
                entity.HasKey(e => e.IdPlaylist)
                    .HasName("PK__Playlist__72ACF23B5CB2C25F");

                entity.ToTable("Playlist");

                entity.Property(e => e.Descripcion).HasMaxLength(50);

                entity.Property(e => e.Duracion).HasColumnType("time(0)");

                entity.Property(e => e.PortadaPlaylist).HasMaxLength(300);

                entity.Property(e => e.Titulo).HasMaxLength(50);

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Playlists)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Playlist__IdUsua__5AEE82B9");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuario__5B65BF97878CEB9D");

                entity.ToTable("Usuario");

                entity.Property(e => e.Apellido).HasMaxLength(20);

                entity.Property(e => e.Contraseña).HasMaxLength(8);

                entity.Property(e => e.Email).HasMaxLength(40);

                entity.Property(e => e.FotoPerfil).HasMaxLength(300);

                entity.Property(e => e.Nombre).HasMaxLength(20);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
