using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SisacadFinal.Models;

public partial class FinalmuContext : DbContext
{
    public FinalmuContext()
    {
    }

    public FinalmuContext(DbContextOptions<FinalmuContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Administracion> Administracions { get; set; }

    public virtual DbSet<Carrera> Carreras { get; set; }

    public virtual DbSet<EstadosEstudiante> EstadosEstudiantes { get; set; }

    public virtual DbSet<Estudiante> Estudiantes { get; set; }

    public virtual DbSet<Finale> Finales { get; set; }

    public virtual DbSet<Materia> Materias { get; set; }

    public virtual DbSet<Matriculacione> Matriculaciones { get; set; }

    public virtual DbSet<MatriculacionesCarrerasEstudiante> MatriculacionesCarrerasEstudiantes { get; set; }

    public virtual DbSet<MatriculacionesCarrerasProfesore> MatriculacionesCarrerasProfesores { get; set; }

    public virtual DbSet<Nota> Notas { get; set; }

    public virtual DbSet<Profesore> Profesores { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=FINALMU;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Administracion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Administ__3214EC2746905415");

            entity.ToTable("Administracion");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Apellido)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Contrasena)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FechaCreacion).HasColumnType("date");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Rol)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Carrera>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Carreras__3214EC279D8CBC9F");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<EstadosEstudiante>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__EstadosE__3214EC279D9FE514");

            entity.ToTable("EstadosEstudiante");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Estudiante>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Estudian__3214EC273A6876F6");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Apellido)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Contrasena)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FechaCreacion).HasColumnType("date");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Finale>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.EstudianteId).HasColumnName("EstudianteID");
            entity.Property(e => e.Fecha).HasColumnType("date");
            entity.Property(e => e.MateriaId).HasColumnName("MateriaID");

            entity.HasOne(d => d.Estudiante).WithMany()
                .HasForeignKey(d => d.EstudianteId)
                .HasConstraintName("FK__Finales__Estudia__5BE2A6F2");

            entity.HasOne(d => d.Materia).WithMany()
                .HasForeignKey(d => d.MateriaId)
                .HasConstraintName("FK__Finales__Materia__5CD6CB2B");
        });

        modelBuilder.Entity<Materia>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Materias__3214EC2746046E21");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IdCarrera).HasColumnName("idCarrera");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ProfesorId).HasColumnName("ProfesorID");

            entity.HasOne(d => d.IdCarreraNavigation).WithMany(p => p.Materia)
                .HasForeignKey(d => d.IdCarrera)
                .HasConstraintName("FK__Materias__idCarr__787EE5A0");

            entity.HasOne(d => d.Profesor).WithMany(p => p.Materia)
                .HasForeignKey(d => d.ProfesorId)
                .HasConstraintName("FK__Materias__Profes__5165187F");
        });

        modelBuilder.Entity<Matriculacione>(entity =>
        {
            entity.HasKey(e => e.MatriculacioneId).HasName("PK__Matricul__C36C8A612397E32E");

            entity.Property(e => e.MatriculacioneId).HasColumnName("MatriculacioneID");
            entity.Property(e => e.EstudianteId).HasColumnName("EstudianteID");
            entity.Property(e => e.MateriaId).HasColumnName("MateriaID");

            entity.HasOne(d => d.Estudiante).WithMany(p => p.Matriculaciones)
                .HasForeignKey(d => d.EstudianteId)
                .HasConstraintName("FK__Matricula__Estud__534D60F1");

            entity.HasOne(d => d.Materia).WithMany(p => p.Matriculaciones)
                .HasForeignKey(d => d.MateriaId)
                .HasConstraintName("FK__Matricula__Mater__5441852A");
        });

        modelBuilder.Entity<MatriculacionesCarrerasEstudiante>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.CarreraId).HasColumnName("CarreraID");
            entity.Property(e => e.EstudianteId).HasColumnName("EstudianteID");

            entity.HasOne(d => d.Carrera).WithMany()
                .HasForeignKey(d => d.CarreraId)
                .HasConstraintName("FK__Matricula__Carre__571DF1D5");

            entity.HasOne(d => d.Estudiante).WithMany()
                .HasForeignKey(d => d.EstudianteId)
                .HasConstraintName("FK__Matricula__Estud__5629CD9C");
        });

        modelBuilder.Entity<MatriculacionesCarrerasProfesore>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.CarreraId).HasColumnName("CarreraID");
            entity.Property(e => e.ProfesorId).HasColumnName("ProfesorID");

            entity.HasOne(d => d.Carrera).WithMany()
                .HasForeignKey(d => d.CarreraId)
                .HasConstraintName("FK__Matricula__Carre__59FA5E80");

            entity.HasOne(d => d.Profesor).WithMany()
                .HasForeignKey(d => d.ProfesorId)
                .HasConstraintName("FK__Matricula__Profe__59063A47");
        });

        modelBuilder.Entity<Nota>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.EstadoId).HasColumnName("EstadoID");
            entity.Property(e => e.EstudianteId).HasColumnName("EstudianteID");
            entity.Property(e => e.FechaNota).HasColumnType("date");
            entity.Property(e => e.MateriaId).HasColumnName("MateriaID");
            entity.Property(e => e.Nota1).HasColumnName("Nota");

            entity.HasOne(d => d.Estado).WithMany()
                .HasForeignKey(d => d.EstadoId)
                .HasConstraintName("FK__Notas__EstadoID__628FA481");

            entity.HasOne(d => d.Estudiante).WithMany()
                .HasForeignKey(d => d.EstudianteId)
                .HasConstraintName("FK__Notas__Estudiant__60A75C0F");

            entity.HasOne(d => d.Materia).WithMany()
                .HasForeignKey(d => d.MateriaId)
                .HasConstraintName("FK__Notas__MateriaID__619B8048");
        });

        modelBuilder.Entity<Profesore>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Profesor__3214EC2790699FD4");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Apellido)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Contrasena)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FechaCreacion).HasColumnType("date");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
