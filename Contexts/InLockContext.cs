using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using inlock_games_DBFirst_manha.Domains;

namespace inlock_games_DBFirst_manha.Contexts;

public partial class InLockContext : DbContext
{
    public InLockContext()
    {
    }

    public InLockContext(DbContextOptions<InLockContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Estudio> Estudios { get; set; }

    public virtual DbSet<Jogo> Jogos { get; set; }

    public virtual DbSet<TiposUsuario> TiposUsuarios { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source = DESKTOP-2KJISQH\\SENAI; Initial Catalog = inlock_games_DBFirst_manha; User ID = sa; pwd = Senai@134; TrustServerCertificate = true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Estudio>(entity =>
        {
            entity.HasKey(e => e.IdEstudio).HasName("PK__Estudio__0C3B4355D55611C4");

            entity.ToTable("Estudio");

            entity.Property(e => e.IdEstudio).ValueGeneratedNever();
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Jogo>(entity =>
        {
            entity.HasKey(e => e.IdJogos).HasName("PK__Jogos__3351D6E415AC1593");

            entity.Property(e => e.IdJogos).ValueGeneratedNever();
            entity.Property(e => e.DataLançamento).HasColumnType("date");
            entity.Property(e => e.Descrição)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .HasMaxLength(120)
                .IsUnicode(false);
            entity.Property(e => e.Valor).HasColumnType("smallmoney");

            entity.HasOne(d => d.IdEstudioNavigation).WithMany(p => p.Jogos)
                .HasForeignKey(d => d.IdEstudio)
                .HasConstraintName("FK__Jogos__IdEstudio__4BAC3F29");
        });

        modelBuilder.Entity<TiposUsuario>(entity =>
        {
            entity.HasKey(e => e.IdTiposUsuario).HasName("PK__TiposUsu__F2C5C0ED431A2B5C");

            entity.ToTable("TiposUsuario");

            entity.Property(e => e.IdTiposUsuario).ValueGeneratedNever();
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Usuario1).HasName("PK__Usuario__E3237CF663686ACF");

            entity.ToTable("Usuario");

            entity.Property(e => e.Usuario1)
                .ValueGeneratedNever()
                .HasColumnName("Usuario");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Senha)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.IdTiposUsuarioNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdTiposUsuario)
                .HasConstraintName("FK__Usuario__IdTipos__5070F446");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
