using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace SmartShopCuzco_AdminPanel.Models;

public partial class SmartshopcuzcoContext : DbContext
{
    public SmartshopcuzcoContext()
    {
    }

    public SmartshopcuzcoContext(DbContextOptions<SmartshopcuzcoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cargo> Cargos { get; set; }

    public virtual DbSet<Categoriaproducto> Categoriaproductos { get; set; }

    public virtual DbSet<Dentradainsumo> Dentradainsumos { get; set; }

    public virtual DbSet<Dentradaproducto> Dentradaproductos { get; set; }

    public virtual DbSet<Distrito> Distritos { get; set; }

    public virtual DbSet<Dsalidainsumo> Dsalidainsumos { get; set; }

    public virtual DbSet<Dsalidaproducto> Dsalidaproductos { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<Hentradainsumo> Hentradainsumos { get; set; }

    public virtual DbSet<Hentradaproducto> Hentradaproductos { get; set; }

    public virtual DbSet<Hsalidainsumo> Hsalidainsumos { get; set; }

    public virtual DbSet<Hsalidaproducto> Hsalidaproductos { get; set; }

    public virtual DbSet<Insumo> Insumos { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Proveedor> Proveedors { get; set; }

    public virtual DbSet<Sexo> Sexos { get; set; }

    public virtual DbSet<Tipodireccion> Tipodireccions { get; set; }

    public virtual DbSet<Tipodocumento> Tipodocumentos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;database=smartshopcuzco;user=root;password=1234", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.42-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Cargo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("cargo");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Estado)
                .HasColumnType("bit(1)")
                .HasColumnName("ESTADO");
            entity.Property(e => e.Nombre)
                .HasMaxLength(40)
                .HasColumnName("NOMBRE");
        });

        modelBuilder.Entity<Categoriaproducto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("categoriaproducto");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Estado)
                .HasColumnType("bit(1)")
                .HasColumnName("ESTADO");
            entity.Property(e => e.Nombre)
                .HasMaxLength(40)
                .HasColumnName("NOMBRE");
        });

        modelBuilder.Entity<Dentradainsumo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("dentradainsumo");

            entity.HasIndex(e => e.IdHentradaInsumo, "ID_HENTRADA_INSUMO");

            entity.HasIndex(e => e.IdInsumo, "ID_INSUMO");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Cantidad).HasColumnName("CANTIDAD");
            entity.Property(e => e.Estado)
                .HasColumnType("bit(1)")
                .HasColumnName("ESTADO");
            entity.Property(e => e.IdHentradaInsumo).HasColumnName("ID_HENTRADA_INSUMO");
            entity.Property(e => e.IdInsumo).HasColumnName("ID_INSUMO");
            entity.Property(e => e.PrecioUnitario)
                .HasPrecision(10, 2)
                .HasColumnName("PRECIO_UNITARIO");

            entity.HasOne(d => d.IdHentradaInsumoNavigation).WithMany(p => p.Dentradainsumos)
                .HasForeignKey(d => d.IdHentradaInsumo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("dentradainsumo_ibfk_1");

            entity.HasOne(d => d.IdInsumoNavigation).WithMany(p => p.Dentradainsumos)
                .HasForeignKey(d => d.IdInsumo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("dentradainsumo_ibfk_2");
        });

        modelBuilder.Entity<Dentradaproducto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("dentradaproducto");

            entity.HasIndex(e => e.IdHentradaProducto, "ID_HENTRADA_PRODUCTO");

            entity.HasIndex(e => e.IdProducto, "ID_PRODUCTO");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Cantidad).HasColumnName("CANTIDAD");
            entity.Property(e => e.Estado)
                .HasColumnType("bit(1)")
                .HasColumnName("ESTADO");
            entity.Property(e => e.IdHentradaProducto).HasColumnName("ID_HENTRADA_PRODUCTO");
            entity.Property(e => e.IdProducto).HasColumnName("ID_PRODUCTO");
            entity.Property(e => e.PrecioUnitario)
                .HasPrecision(10, 2)
                .HasColumnName("PRECIO_UNITARIO");

            entity.HasOne(d => d.IdHentradaProductoNavigation).WithMany(p => p.Dentradaproductos)
                .HasForeignKey(d => d.IdHentradaProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("dentradaproducto_ibfk_1");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.Dentradaproductos)
                .HasForeignKey(d => d.IdProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("dentradaproducto_ibfk_2");
        });

        modelBuilder.Entity<Distrito>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("distrito");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Estado)
                .HasColumnType("bit(1)")
                .HasColumnName("ESTADO");
            entity.Property(e => e.Nombre)
                .HasMaxLength(40)
                .HasColumnName("NOMBRE");
        });

        modelBuilder.Entity<Dsalidainsumo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("dsalidainsumo");

            entity.HasIndex(e => e.IdHsalidaInsumo, "ID_HSALIDA_INSUMO");

            entity.HasIndex(e => e.IdInsumo, "ID_INSUMO");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Cantidad).HasColumnName("CANTIDAD");
            entity.Property(e => e.Estado)
                .HasColumnType("bit(1)")
                .HasColumnName("ESTADO");
            entity.Property(e => e.IdHsalidaInsumo).HasColumnName("ID_HSALIDA_INSUMO");
            entity.Property(e => e.IdInsumo).HasColumnName("ID_INSUMO");
            entity.Property(e => e.PrecioUnitario)
                .HasPrecision(10, 2)
                .HasColumnName("PRECIO_UNITARIO");

            entity.HasOne(d => d.IdHsalidaInsumoNavigation).WithMany(p => p.Dsalidainsumos)
                .HasForeignKey(d => d.IdHsalidaInsumo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("dsalidainsumo_ibfk_1");

            entity.HasOne(d => d.IdInsumoNavigation).WithMany(p => p.Dsalidainsumos)
                .HasForeignKey(d => d.IdInsumo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("dsalidainsumo_ibfk_2");
        });

        modelBuilder.Entity<Dsalidaproducto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("dsalidaproducto");

            entity.HasIndex(e => e.IdHsalidaProducto, "ID_HSALIDA_PRODUCTO");

            entity.HasIndex(e => e.IdProducto, "ID_PRODUCTO");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Cantidad).HasColumnName("CANTIDAD");
            entity.Property(e => e.Estado)
                .HasColumnType("bit(1)")
                .HasColumnName("ESTADO");
            entity.Property(e => e.IdHsalidaProducto).HasColumnName("ID_HSALIDA_PRODUCTO");
            entity.Property(e => e.IdProducto).HasColumnName("ID_PRODUCTO");
            entity.Property(e => e.PrecioUnitario)
                .HasPrecision(10, 2)
                .HasColumnName("PRECIO_UNITARIO");

            entity.HasOne(d => d.IdHsalidaProductoNavigation).WithMany(p => p.Dsalidaproductos)
                .HasForeignKey(d => d.IdHsalidaProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("dsalidaproducto_ibfk_1");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.Dsalidaproductos)
                .HasForeignKey(d => d.IdProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("dsalidaproducto_ibfk_2");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("empleado");

            entity.HasIndex(e => e.IdCargo, "ID_CARGO");

            entity.HasIndex(e => e.IdSexo, "ID_SEXO");

            entity.HasIndex(e => e.IdTipoDocumento, "ID_TIPO_DOCUMENTO");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ApellidoMa)
                .HasMaxLength(40)
                .HasColumnName("APELLIDO_MA");
            entity.Property(e => e.ApellidoPa)
                .HasMaxLength(40)
                .HasColumnName("APELLIDO_PA");
            entity.Property(e => e.Celular)
                .HasMaxLength(20)
                .HasColumnName("CELULAR");
            entity.Property(e => e.Clave)
                .HasMaxLength(40)
                .HasColumnName("CLAVE");
            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .HasColumnName("CORREO");
            entity.Property(e => e.Estado)
                .HasColumnType("bit(1)")
                .HasColumnName("ESTADO");
            entity.Property(e => e.IdCargo).HasColumnName("ID_CARGO");
            entity.Property(e => e.IdSexo).HasColumnName("ID_SEXO");
            entity.Property(e => e.IdTipoDocumento).HasColumnName("ID_TIPO_DOCUMENTO");
            entity.Property(e => e.Nombre)
                .HasMaxLength(40)
                .HasColumnName("NOMBRE");
            entity.Property(e => e.NumeroDocumento)
                .HasMaxLength(20)
                .HasColumnName("NUMERO_DOCUMENTO");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .HasColumnName("TELEFONO");
            entity.Property(e => e.Usuario)
                .HasMaxLength(40)
                .HasColumnName("USUARIO");

            entity.HasOne(d => d.IdCargoNavigation).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.IdCargo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("empleado_ibfk_2");

            entity.HasOne(d => d.IdSexoNavigation).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.IdSexo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("empleado_ibfk_3");

            entity.HasOne(d => d.IdTipoDocumentoNavigation).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.IdTipoDocumento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("empleado_ibfk_1");
        });

        modelBuilder.Entity<Hentradainsumo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("hentradainsumo");

            entity.HasIndex(e => e.IdEmpleado, "ID_EMPLEADO");

            entity.HasIndex(e => e.IdProveedor, "ID_PROVEEDOR");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Estado)
                .HasColumnType("bit(1)")
                .HasColumnName("ESTADO");
            entity.Property(e => e.Fecha).HasColumnName("FECHA");
            entity.Property(e => e.IdEmpleado).HasColumnName("ID_EMPLEADO");
            entity.Property(e => e.IdProveedor).HasColumnName("ID_PROVEEDOR");

            entity.HasOne(d => d.IdEmpleadoNavigation).WithMany(p => p.Hentradainsumos)
                .HasForeignKey(d => d.IdEmpleado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("hentradainsumo_ibfk_2");

            entity.HasOne(d => d.IdProveedorNavigation).WithMany(p => p.Hentradainsumos)
                .HasForeignKey(d => d.IdProveedor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("hentradainsumo_ibfk_1");
        });

        modelBuilder.Entity<Hentradaproducto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("hentradaproducto");

            entity.HasIndex(e => e.IdEmpleado, "ID_EMPLEADO");

            entity.HasIndex(e => e.IdProveedor, "ID_PROVEEDOR");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Estado)
                .HasColumnType("bit(1)")
                .HasColumnName("ESTADO");
            entity.Property(e => e.Fecha).HasColumnName("FECHA");
            entity.Property(e => e.IdEmpleado).HasColumnName("ID_EMPLEADO");
            entity.Property(e => e.IdProveedor).HasColumnName("ID_PROVEEDOR");

            entity.HasOne(d => d.IdEmpleadoNavigation).WithMany(p => p.Hentradaproductos)
                .HasForeignKey(d => d.IdEmpleado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("hentradaproducto_ibfk_2");

            entity.HasOne(d => d.IdProveedorNavigation).WithMany(p => p.Hentradaproductos)
                .HasForeignKey(d => d.IdProveedor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("hentradaproducto_ibfk_1");
        });

        modelBuilder.Entity<Hsalidainsumo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("hsalidainsumo");

            entity.HasIndex(e => e.IdEmpleado, "ID_EMPLEADO");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Estado)
                .HasColumnType("bit(1)")
                .HasColumnName("ESTADO");
            entity.Property(e => e.Fecha).HasColumnName("FECHA");
            entity.Property(e => e.IdEmpleado).HasColumnName("ID_EMPLEADO");

            entity.HasOne(d => d.IdEmpleadoNavigation).WithMany(p => p.Hsalidainsumos)
                .HasForeignKey(d => d.IdEmpleado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("hsalidainsumo_ibfk_1");
        });

        modelBuilder.Entity<Hsalidaproducto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("hsalidaproducto");

            entity.HasIndex(e => e.IdEmpleado, "ID_EMPLEADO");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Estado)
                .HasColumnType("bit(1)")
                .HasColumnName("ESTADO");
            entity.Property(e => e.Fecha).HasColumnName("FECHA");
            entity.Property(e => e.IdEmpleado).HasColumnName("ID_EMPLEADO");

            entity.HasOne(d => d.IdEmpleadoNavigation).WithMany(p => p.Hsalidaproductos)
                .HasForeignKey(d => d.IdEmpleado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("hsalidaproducto_ibfk_1");
        });

        modelBuilder.Entity<Insumo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("insumo");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Cantidad).HasColumnName("CANTIDAD");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .HasColumnName("DESCRIPCION");
            entity.Property(e => e.Estado)
                .HasColumnType("bit(1)")
                .HasColumnName("ESTADO");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("NOMBRE");
            entity.Property(e => e.Precio)
                .HasPrecision(10, 2)
                .HasColumnName("PRECIO");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("producto");

            entity.HasIndex(e => e.IdCategoriaProducto, "ID_CATEGORIA_PRODUCTO");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Cantidad).HasColumnName("CANTIDAD");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .HasColumnName("DESCRIPCION");
            entity.Property(e => e.Estado)
                .HasColumnType("bit(1)")
                .HasColumnName("ESTADO");
            entity.Property(e => e.IdCategoriaProducto).HasColumnName("ID_CATEGORIA_PRODUCTO");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("NOMBRE");
            entity.Property(e => e.Precio)
                .HasPrecision(10, 2)
                .HasColumnName("PRECIO");

            entity.HasOne(d => d.IdCategoriaProductoNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.IdCategoriaProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("producto_ibfk_1");
        });

        modelBuilder.Entity<Proveedor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("proveedor");

            entity.HasIndex(e => e.IdDistrito, "ID_DISTRITO");

            entity.HasIndex(e => e.IdTipoDireccion, "ID_TIPO_DIRECCION");

            entity.HasIndex(e => e.IdTipoDocumento, "ID_TIPO_DOCUMENTO");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Celular)
                .HasMaxLength(20)
                .HasColumnName("CELULAR");
            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .HasColumnName("CORREO");
            entity.Property(e => e.Direccion)
                .HasMaxLength(200)
                .HasColumnName("DIRECCION");
            entity.Property(e => e.Estado)
                .HasColumnType("bit(1)")
                .HasColumnName("ESTADO");
            entity.Property(e => e.IdDistrito).HasColumnName("ID_DISTRITO");
            entity.Property(e => e.IdTipoDireccion).HasColumnName("ID_TIPO_DIRECCION");
            entity.Property(e => e.IdTipoDocumento).HasColumnName("ID_TIPO_DOCUMENTO");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("NOMBRE");
            entity.Property(e => e.NumeroDocumento)
                .HasMaxLength(20)
                .HasColumnName("NUMERO_DOCUMENTO");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .HasColumnName("TELEFONO");

            entity.HasOne(d => d.IdDistritoNavigation).WithMany(p => p.Proveedors)
                .HasForeignKey(d => d.IdDistrito)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("proveedor_ibfk_2");

            entity.HasOne(d => d.IdTipoDireccionNavigation).WithMany(p => p.Proveedors)
                .HasForeignKey(d => d.IdTipoDireccion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("proveedor_ibfk_3");

            entity.HasOne(d => d.IdTipoDocumentoNavigation).WithMany(p => p.Proveedors)
                .HasForeignKey(d => d.IdTipoDocumento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("proveedor_ibfk_1");
        });

        modelBuilder.Entity<Sexo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("sexo");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Estado)
                .HasColumnType("bit(1)")
                .HasColumnName("ESTADO");
            entity.Property(e => e.Nombre)
                .HasMaxLength(20)
                .HasColumnName("NOMBRE");
        });

        modelBuilder.Entity<Tipodireccion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tipodireccion");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Estado)
                .HasColumnType("bit(1)")
                .HasColumnName("ESTADO");
            entity.Property(e => e.Nombre)
                .HasMaxLength(40)
                .HasColumnName("NOMBRE");
        });

        modelBuilder.Entity<Tipodocumento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tipodocumento");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Estado)
                .HasColumnType("bit(1)")
                .HasColumnName("ESTADO");
            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .HasColumnName("NOMBRE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
