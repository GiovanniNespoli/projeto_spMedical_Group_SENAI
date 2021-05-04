using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SpMedGrup.webApi.Domains;

#nullable disable

namespace SpMedGrup.webApi.Contexts
{
    public partial class MedicalGrupContext : DbContext
    {
        public MedicalGrupContext()
        {
        }

        public MedicalGrupContext(DbContextOptions<MedicalGrupContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Clinica> Clinicas { get; set; }
        public virtual DbSet<Consultum> Consulta { get; set; }
        public virtual DbSet<Especialidade> Especialidades { get; set; }
        public virtual DbSet<Medico> Medicos { get; set; }
        public virtual DbSet<Paciente> Pacientes { get; set; }
        public virtual DbSet<Situacao> Situacaos { get; set; }
        public virtual DbSet<TipoDeUsuario> TipoDeUsuarios { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data source= LAPTOP-L0JSQP3E; initial catalog= Medical_Grup_; user Id= sa; pwd= 20nov2004");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Clinica>(entity =>
            {
                entity.HasKey(e => e.IdClinica)
                    .HasName("PK__Clinica__52A9095156E556BA");

                entity.ToTable("Clinica");

                entity.Property(e => e.Cnpj)
                    .IsRequired()
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("CNPJ")
                    .IsFixedLength(true);

                entity.Property(e => e.Endereco)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.HorarioDeAbertura)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('6AM')");

                entity.Property(e => e.HorarioDeEncerrar)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('23PM')");

                entity.Property(e => e.NomeFantasia)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.RazaoSocial)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Consultum>(entity =>
            {
                entity.HasKey(e => e.IdConsulta)
                    .HasName("PK__Consulta__9B2AD1D82A1434D5");

                entity.Property(e => e.DataConsulta).HasColumnType("date");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Exames)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Não')")
                    .IsFixedLength(true);

                entity.HasOne(d => d.IdMedicoNavigation)
                    .WithMany(p => p.Consulta)
                    .HasForeignKey(d => d.IdMedico)
                    .HasConstraintName("FK__Consulta__IdMedi__4D94879B");

                entity.HasOne(d => d.IdPacienteNavigation)
                    .WithMany(p => p.Consulta)
                    .HasForeignKey(d => d.IdPaciente)
                    .HasConstraintName("FK__Consulta__IdPaci__4CA06362");

                entity.HasOne(d => d.IdSituacaoNavigation)
                    .WithMany(p => p.Consulta)
                    .HasForeignKey(d => d.IdSituacao)
                    .HasConstraintName("FK__Consulta__IdSitu__4E88ABD4");
            });

            modelBuilder.Entity<Especialidade>(entity =>
            {
                entity.HasKey(e => e.IdEspecialidade)
                    .HasName("PK__Especial__5676CEFFC3C0441B");

                entity.ToTable("Especialidade");

                entity.Property(e => e.Especialidades)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Medico>(entity =>
            {
                entity.HasKey(e => e.IdMedico)
                    .HasName("PK__Medico__C326E652C92B118C");

                entity.ToTable("Medico");

                entity.Property(e => e.DataDeNascimento).HasColumnType("date");

                entity.Property(e => e.Endereco)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.NomeMedico)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Rg)
                    .IsRequired()
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("RG")
                    .IsFixedLength(true);

                entity.Property(e => e.Telefone)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.IdClinicaNavigation)
                    .WithMany(p => p.Medicos)
                    .HasForeignKey(d => d.IdClinica)
                    .HasConstraintName("FK__Medico__IdClinic__49C3F6B7");

                entity.HasOne(d => d.IdEspecialidadeNavigation)
                    .WithMany(p => p.Medicos)
                    .HasForeignKey(d => d.IdEspecialidade)
                    .HasConstraintName("FK__Medico__IdEspeci__48CFD27E");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Medicos)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Medico__IdUsuari__47DBAE45");
            });

            modelBuilder.Entity<Paciente>(entity =>
            {
                entity.HasKey(e => e.IdPaciente)
                    .HasName("PK__Paciente__C93DB49B29B9ACA3");

                entity.ToTable("Paciente");

                entity.HasIndex(e => e.Rg, "UQ__Paciente__321537C8C45AFEC4")
                    .IsUnique();

                entity.HasIndex(e => e.Cpf, "UQ__Paciente__C1F897315755E632")
                    .IsUnique();

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("CPF")
                    .IsFixedLength(true);

                entity.Property(e => e.DataDeNasc).HasColumnType("date");

                entity.Property(e => e.Endereço)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("ENDEREÇO");

                entity.Property(e => e.NomePaciente)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Rg)
                    .IsRequired()
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("RG")
                    .IsFixedLength(true);

                entity.Property(e => e.Telefone)
                    .IsRequired()
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Pacientes)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Paciente__IdUsua__3D5E1FD2");
            });

            modelBuilder.Entity<Situacao>(entity =>
            {
                entity.HasKey(e => e.IdSituacao)
                    .HasName("PK__Situacao__810BCE3A503753AF");

                entity.ToTable("Situacao");

                entity.Property(e => e.TipoSituacao)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoDeUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoDeUsuario)
                    .HasName("PK__TipoDeUs__8C8B582ABFD7970C");

                entity.ToTable("TipoDeUsuario");

                entity.Property(e => e.TipoDeUsuario1)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("TipoDeUsuario");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuario__5B65BF97E36EDB81");

                entity.ToTable("Usuario");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTipoDeUsuarioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoDeUsuario)
                    .HasConstraintName("FK__Usuario__IdTipoD__38996AB5");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
