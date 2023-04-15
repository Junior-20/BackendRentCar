using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BackendRentCar2._0.Models
{
    public partial class RENTACARContext : DbContext
    {
        public RENTACARContext()
        {
        }

        public RENTACARContext(DbContextOptions<RENTACARContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<Documento> Documentos { get; set; } = null!;
        public virtual DbSet<Empleado> Empleados { get; set; } = null!;
        public virtual DbSet<Inspeccion> Inspeccions { get; set; } = null!;
        public virtual DbSet<Marcass> Marcasses { get; set; } = null!;
        public virtual DbSet<Modelo> Modelos { get; set; } = null!;
        public virtual DbSet<Rentum> Renta { get; set; } = null!;
        public virtual DbSet<TiposdeCombustible> TiposdeCombustibles { get; set; } = null!;
        public virtual DbSet<TiposdeVehiculo> TiposdeVehiculos { get; set; } = null!;
        public virtual DbSet<Vehiculo> Vehiculos { get; set; } = null!;

        //        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //        {
        //            if (!optionsBuilder.IsConfigured)
        //            {
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        //                optionsBuilder.UseSqlServer("Server=.;Initial Catalog=RENTACAR;Integrated Security=True;Encrypt=false");
        //            }
        //        }
        


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente);

                entity.Property(e => e.IdCliente).HasColumnName("Id_Cliente");

                entity.Property(e => e.Cedula)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LimiteCredito)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("Limite_Credito");

                entity.Property(e => e.NoTarjetaCr)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("No_TarjetaCR");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TipoPersona)
                    .HasMaxLength(17)
                    .IsUnicode(false)
                    .HasColumnName("Tipo_Persona");
            });

            modelBuilder.Entity<Documento>(entity =>
            {
                entity.HasKey(e => e.IdDocumento);

                entity.ToTable("Documento");

                entity.Property(e => e.IdDocumento).HasColumnName("Id_Documento");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.HasKey(e => e.IdEmpleado);

                entity.Property(e => e.IdEmpleado).HasColumnName("Id_Empleado");

                entity.Property(e => e.Cedula)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FechaIngreso)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Ingreso");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PorcientoComision)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("Porciento_Comision");

                entity.Property(e => e.TandaLabor)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Tanda_Labor");
            });

            modelBuilder.Entity<Inspeccion>(entity =>
            {
                entity.HasKey(e => e.IdTransaccion);

                entity.ToTable("Inspeccion");

                entity.HasIndex(e => e.EmpleadoInspeccion, "IX_Inspeccion_Empleado_Inspeccion");

                entity.HasIndex(e => e.IdCliente, "IX_Inspeccion_Id_Cliente");

                entity.HasIndex(e => e.Vehiculo, "IX_Inspeccion_Vehiculo");

                entity.Property(e => e.IdTransaccion).HasColumnName("Id_Transaccion");

                entity.Property(e => e.CantidadCombustible)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Cantidad_Combustible");

                entity.Property(e => e.EmpleadoInspeccion).HasColumnName("Empleado_Inspeccion");

                entity.Property(e => e.Estado)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.EstadoGomas)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Estado_Gomas");

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.Gato)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.GomaRespuesta)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Goma_Respuesta");

                entity.Property(e => e.IdCliente).HasColumnName("Id_Cliente");

                entity.Property(e => e.Roturas)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TieneRalladuras)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Tiene_Ralladuras");

                entity.HasOne(d => d.EmpleadoInspeccionNavigation)
                    .WithMany(p => p.Inspeccions)
                    .HasForeignKey(d => d.EmpleadoInspeccion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Inspeccion_Empleados");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Inspeccions)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Inspeccion_Clientes");

                entity.HasOne(d => d.VehiculoNavigation)
                    .WithMany(p => p.Inspeccions)
                    .HasForeignKey(d => d.Vehiculo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Inspeccion_Vehiculos");
            });

            modelBuilder.Entity<Marcass>(entity =>
            {
                entity.HasKey(e => e.IdMarca);

                entity.ToTable("Marcass");

                entity.Property(e => e.IdMarca).HasColumnName("Id_Marca");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Modelo>(entity =>
            {
                entity.HasKey(e => e.IdModelo);

                entity.Property(e => e.IdModelo).HasColumnName("Id_Modelo");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdMarca).HasColumnName("Id_Marca");

                entity.HasOne(d => d.IdMarcaNavigation)
                    .WithMany(p => p.Modelos)
                    .HasForeignKey(d => d.IdMarca)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Modelos_Marcass");
            });

            modelBuilder.Entity<Rentum>(entity =>
            {
                entity.HasKey(e => e.IdRenta)
                    .HasName("PK_RentayDevolucion");

                entity.HasIndex(e => e.Cliente, "IX_Renta_Cliente");

                entity.HasIndex(e => e.DocGarantia, "IX_Renta_Doc_Garantia");

                entity.HasIndex(e => e.Empleado, "IX_Renta_Empleado");

                entity.HasIndex(e => e.Vehiculo, "IX_Renta_Vehiculo");

                entity.Property(e => e.IdRenta)
                    .HasColumnType("decimal(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("Id_Renta");

                entity.Property(e => e.Abono).HasColumnType("money");

                entity.Property(e => e.CantidadDias).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Comentario)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DocGarantia).HasColumnName("Doc_Garantia");

                entity.Property(e => e.Estado)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaDevolucion).HasColumnType("datetime");

                entity.Property(e => e.FechaRenta).HasColumnType("datetime");

                entity.Property(e => e.MontoxDia).HasColumnType("money");

                entity.HasOne(d => d.ClienteNavigation)
                    .WithMany(p => p.Renta)
                    .HasForeignKey(d => d.Cliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Renta_Clientes");

                entity.HasOne(d => d.DocGarantiaNavigation)
                    .WithMany(p => p.Renta)
                    .HasForeignKey(d => d.DocGarantia)
                    .HasConstraintName("FK_Renta_Documento");

                entity.HasOne(d => d.EmpleadoNavigation)
                    .WithMany(p => p.Renta)
                    .HasForeignKey(d => d.Empleado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Renta_Empleados");

                entity.HasOne(d => d.VehiculoNavigation)
                    .WithMany(p => p.Renta)
                    .HasForeignKey(d => d.Vehiculo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Renta_Vehiculos");
            });

            modelBuilder.Entity<TiposdeCombustible>(entity =>
            {
                entity.HasKey(e => e.IdTiposCombustible);

                entity.Property(e => e.IdTiposCombustible).HasColumnName("Id_TiposCombustible");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TiposdeVehiculo>(entity =>
            {
                entity.HasKey(e => e.IdTiposVehiculo);

                entity.Property(e => e.IdTiposVehiculo).HasColumnName("Id_TiposVehiculo");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Vehiculo>(entity =>
            {
                entity.HasKey(e => e.IdVehiculos)
                    .HasName("PK_Vehiculos_1");

                entity.HasIndex(e => e.Marca, "IX_Vehiculos_Marca");

                entity.HasIndex(e => e.Modelo, "IX_Vehiculos_Modelo");

                entity.HasIndex(e => e.TipoCombustible, "IX_Vehiculos_Tipo_Combustible");

                entity.HasIndex(e => e.TipoVehiculo, "IX_Vehiculos_Tipo_Vehiculo");

                entity.Property(e => e.IdVehiculos).HasColumnName("Id_Vehiculos");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.NoChasis)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("No_Chasis");

                entity.Property(e => e.NoMotor)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("No_Motor");

                entity.Property(e => e.NoPlaca)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("No_Placa");

                entity.Property(e => e.TipoCombustible).HasColumnName("Tipo_Combustible");

                entity.Property(e => e.TipoVehiculo).HasColumnName("Tipo_Vehiculo");

                entity.HasOne(d => d.MarcaNavigation)
                    .WithMany(p => p.Vehiculos)
                    .HasForeignKey(d => d.Marca)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Vehiculos_Marcass");

                entity.HasOne(d => d.ModeloNavigation)
                    .WithMany(p => p.Vehiculos)
                    .HasForeignKey(d => d.Modelo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Vehiculos_Modelos");

                entity.HasOne(d => d.TipoCombustibleNavigation)
                    .WithMany(p => p.Vehiculos)
                    .HasForeignKey(d => d.TipoCombustible)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Vehiculos_TiposdeCombustibles");

                entity.HasOne(d => d.TipoVehiculoNavigation)
                    .WithMany(p => p.Vehiculos)
                    .HasForeignKey(d => d.TipoVehiculo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Vehiculos_TiposdeVehiculos");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
