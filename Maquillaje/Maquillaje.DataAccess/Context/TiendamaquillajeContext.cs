﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using Maquillaje.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Maquillaje.DataAccess.Context
{
    public partial class TiendamaquillajeContext : DbContext
    {
        public TiendamaquillajeContext()
        {
        }

        public TiendamaquillajeContext(DbContextOptions<TiendamaquillajeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Vw_Gral_tbClientes_LIST> Vw_Gral_tbClientes_LIST { get; set; }
        public virtual DbSet<Vw_Gral_tbDepartamentos_LIST> Vw_Gral_tbDepartamentos_LIST { get; set; }
        public virtual DbSet<Vw_Gral_tbEmpleados_LIST> Vw_Gral_tbEmpleados_LIST { get; set; }
        public virtual DbSet<Vw_Gral_tbEstadosCiviles_LIST> Vw_Gral_tbEstadosCiviles_LIST { get; set; }
        public virtual DbSet<Vw_Gral_tbMunicipios_LIST> Vw_Gral_tbMunicipios_LIST { get; set; }
        public virtual DbSet<Vw_Gral_tbSucursales_LIST> Vw_Gral_tbSucursales_LIST { get; set; }
        public virtual DbSet<Vw_Gral_tbUsuarios_LIST> Vw_Gral_tbUsuarios_LIST { get; set; }
        public virtual DbSet<Vw_Maqui_tbCategorias_LIST> Vw_Maqui_tbCategorias_LIST { get; set; }
        public virtual DbSet<Vw_Maqui_tbInventario_LIST> Vw_Maqui_tbInventario_LIST { get; set; }
        public virtual DbSet<Vw_Maqui_tbMetodoPago_LIST> Vw_Maqui_tbMetodoPago_LIST { get; set; }
        public virtual DbSet<Vw_Maqui_tbProductos_LIST> Vw_Maqui_tbProductos_LIST { get; set; }
        public virtual DbSet<Vw_Maqui_tbProveedores_LIST> Vw_Maqui_tbProveedores_LIST { get; set; }
        public virtual DbSet<Vw_Maqui_tbVentasDetalle_LIST> Vw_Maqui_tbVentasDetalle_LIST { get; set; }
        public virtual DbSet<Vw_Maqui_tbVentas_LIST> Vw_Maqui_tbVentas_LIST { get; set; }
        public virtual DbSet<tbCategorias> tbCategorias { get; set; }
        public virtual DbSet<tbClientes> tbClientes { get; set; }
        public virtual DbSet<tbDepartamentos> tbDepartamentos { get; set; }
        public virtual DbSet<tbEmpleados> tbEmpleados { get; set; }
        public virtual DbSet<tbEstadosCiviles> tbEstadosCiviles { get; set; }
        public virtual DbSet<tbInventario> tbInventario { get; set; }
        public virtual DbSet<tbMetodoPago> tbMetodoPago { get; set; }
        public virtual DbSet<tbMunicipios> tbMunicipios { get; set; }
        public virtual DbSet<tbProductos> tbProductos { get; set; }
        public virtual DbSet<tbProveedores> tbProveedores { get; set; }
        public virtual DbSet<tbSucursales> tbSucursales { get; set; }
        public virtual DbSet<tbUsuarios> tbUsuarios { get; set; }
        public virtual DbSet<tbVentas> tbVentas { get; set; }
        public virtual DbSet<tbVentasDetalle> tbVentasDetalle { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Vw_Gral_tbClientes_LIST>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Vw_Gral_tbClientes_LIST");

                entity.Property(e => e.cli_DNI)
                    .IsRequired()
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.Property(e => e.cli_EstadoCivil)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.cli_FechaNacimiento).HasColumnType("date");

                entity.Property(e => e.cli_Municipio)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.cli_Nombre)
                    .IsRequired()
                    .HasMaxLength(501);

                entity.Property(e => e.cli_Telefono)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.cli_sexo)
                    .IsRequired()
                    .HasMaxLength(9)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Vw_Gral_tbDepartamentos_LIST>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Vw_Gral_tbDepartamentos_LIST");

                entity.Property(e => e.dep_Descripcion)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.dep_ID).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Vw_Gral_tbEmpleados_LIST>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Vw_Gral_tbEmpleados_LIST");

                entity.Property(e => e.emp_Correo)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.emp_DNI)
                    .IsRequired()
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.Property(e => e.emp_EstadoCivil)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.emp_FechaNacimiento).HasColumnType("date");

                entity.Property(e => e.emp_Municipio)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.emp_Nombre)
                    .IsRequired()
                    .HasMaxLength(501);

                entity.Property(e => e.emp_Sexo)
                    .IsRequired()
                    .HasMaxLength(9)
                    .IsUnicode(false);

                entity.Property(e => e.emp_Sucursal)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.emp_Telefono)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Vw_Gral_tbEstadosCiviles_LIST>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Vw_Gral_tbEstadosCiviles_LIST");

                entity.Property(e => e.est_Descripcion)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.est_ID).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Vw_Gral_tbMunicipios_LIST>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Vw_Gral_tbMunicipios_LIST");

                entity.Property(e => e.mun_Descripcion)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.mun_depID)
                    .IsRequired()
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<Vw_Gral_tbSucursales_LIST>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Vw_Gral_tbSucursales_LIST");

                entity.Property(e => e.suc_Descripcion)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.suc_Municipio)
                    .IsRequired()
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<Vw_Gral_tbUsuarios_LIST>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Vw_Gral_tbUsuarios_LIST");

                entity.Property(e => e.Empleado)
                    .IsRequired()
                    .HasMaxLength(501);

                entity.Property(e => e.usu_Usuario)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Vw_Maqui_tbCategorias_LIST>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Vw_Maqui_tbCategorias_LIST");

                entity.Property(e => e.cat_Descripcion)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.cat_Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Vw_Maqui_tbInventario_LIST>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Vw_Maqui_tbInventario_LIST");

                entity.Property(e => e.pro_Nombre)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Vw_Maqui_tbMetodoPago_LIST>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Vw_Maqui_tbMetodoPago_LIST");

                entity.Property(e => e.met_Descripcion)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.met_Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Vw_Maqui_tbProductos_LIST>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Vw_Maqui_tbProductos_LIST");

                entity.Property(e => e.cat_Descripcion)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.pro_Codigo)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.pro_Nombre)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.pro_PrecioUnitario).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.pro_Proveedor)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.pro_StockInicial)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.prv_NombreCompañia)
                    .IsRequired()
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<Vw_Maqui_tbProveedores_LIST>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Vw_Maqui_tbProveedores_LIST");

                entity.Property(e => e.prv_DireccionContacto)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.prv_DireccionEmpresa)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.prv_Municipio)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.prv_NombreCompañia)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.prv_NombreContacto)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.prv_SexoContacto)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.prv_TelefonoContacto)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Vw_Maqui_tbVentasDetalle_LIST>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Vw_Maqui_tbVentasDetalle_LIST");

                entity.Property(e => e.vde_Producto)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Vw_Maqui_tbVentas_LIST>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Vw_Maqui_tbVentas_LIST");

                entity.Property(e => e.met_Descripcion)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.suc_Descripcion)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ven_Cliente)
                    .IsRequired()
                    .HasMaxLength(501);

                entity.Property(e => e.ven_Empleado)
                    .IsRequired()
                    .HasMaxLength(501);

                entity.Property(e => e.ven_Fecha).HasColumnType("datetime");
            });

            modelBuilder.Entity<tbCategorias>(entity =>
            {
                entity.HasKey(e => e.cat_Id)
                    .HasName("PK__tbCatego__DD5AD195DA664301");

                entity.ToTable("tbCategorias", "Maqui");

                entity.Property(e => e.cat_Descripcion)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.cat_Estado).HasDefaultValueSql("((1))");

                entity.Property(e => e.cat_FechaCrea)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.cat_FechaModi).HasColumnType("datetime");

                entity.HasOne(d => d.cat_UsuCreaNavigation)
                    .WithMany(p => p.tbCategoriascat_UsuCreaNavigation)
                    .HasForeignKey(d => d.cat_UsuCrea)
                    .HasConstraintName("FK_Maqui_tbCategorias_cat_UsuCrea_Gral_tbUsuarios_usu_ID");

                entity.HasOne(d => d.cat_UsuModiNavigation)
                    .WithMany(p => p.tbCategoriascat_UsuModiNavigation)
                    .HasForeignKey(d => d.cat_UsuModi)
                    .HasConstraintName("FK_Maqui_tbCategorias_cat_UsuModi_Gral_tbUsuarios_usu_ID");
            });

            modelBuilder.Entity<tbClientes>(entity =>
            {
                entity.HasKey(e => e.cli_ID)
                    .HasName("PK__tbClient__FFECE5773889EFB3");

                entity.ToTable("tbClientes", "Gral");

                entity.HasIndex(e => e.cli_DNI, "UQ_Gral_tbClientes_cli_DNI")
                    .IsUnique();

                entity.Property(e => e.cli_Apellido)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.cli_DNI)
                    .IsRequired()
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.Property(e => e.cli_Estado).HasDefaultValueSql("((1))");

                entity.Property(e => e.cli_FechaCrea)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.cli_FechaModi).HasColumnType("datetime");

                entity.Property(e => e.cli_FechaNacimiento).HasColumnType("date");

                entity.Property(e => e.cli_Nombre)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.cli_Sexo)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.cli_Telefono)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.cli_EstadoCivilNavigation)
                    .WithMany(p => p.tbClientes)
                    .HasForeignKey(d => d.cli_EstadoCivil)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Gral_tbClientes_cli_EstadoCivil_Gral_tbEstadoCivil_est_ID");

                entity.HasOne(d => d.cli_MunicipioNavigation)
                    .WithMany(p => p.tbClientes)
                    .HasForeignKey(d => d.cli_Municipio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Gral_tbClientes_cli_Municipio_Gral_tbMunicipios_mun_ID");

                entity.HasOne(d => d.cli_UsuarioCreaNavigation)
                    .WithMany(p => p.tbClientescli_UsuarioCreaNavigation)
                    .HasForeignKey(d => d.cli_UsuarioCrea)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Gral_tbClientes_cli_UsuarioCrea_Gral_tbUsuarios_usu_ID");

                entity.HasOne(d => d.cli_UsuarioModiNavigation)
                    .WithMany(p => p.tbClientescli_UsuarioModiNavigation)
                    .HasForeignKey(d => d.cli_UsuarioModi)
                    .HasConstraintName("FK_Gral_tbClientes_cli_UsuarioModi_Gral_tbUsuarios_usu_ID");
            });

            modelBuilder.Entity<tbDepartamentos>(entity =>
            {
                entity.HasKey(e => e.dep_ID)
                    .HasName("PK__tbDepart__BB4CBBC04FE4EB20");

                entity.ToTable("tbDepartamentos", "Gral");

                entity.Property(e => e.dep_Descripcion)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.dep_FechaCrea)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.dep_FechaModi).HasColumnType("datetime");

                entity.HasOne(d => d.dep_UsuarioCreaNavigation)
                    .WithMany(p => p.tbDepartamentosdep_UsuarioCreaNavigation)
                    .HasForeignKey(d => d.dep_UsuarioCrea)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Gral_tbDepartamentos_dep_UsuarioCrea_Gral_tbUsuarios_usu_ID");

                entity.HasOne(d => d.dep_UsuarioModiNavigation)
                    .WithMany(p => p.tbDepartamentosdep_UsuarioModiNavigation)
                    .HasForeignKey(d => d.dep_UsuarioModi)
                    .HasConstraintName("FK_Gral_tbDepartamentos_dep_UsuarioModi_Gral_tbUsuarios_usu_ID");
            });

            modelBuilder.Entity<tbEmpleados>(entity =>
            {
                entity.HasKey(e => e.emp_ID)
                    .HasName("PK__tbEmplea__128545C913475940");

                entity.ToTable("tbEmpleados", "Gral");

                entity.HasIndex(e => e.emp_DNI, "UQ_Gral_tbEmpleados_emp_DNI")
                    .IsUnique();

                entity.Property(e => e.emp_Apellido)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.emp_Correo)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.emp_DNI)
                    .IsRequired()
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.Property(e => e.emp_Estado).HasDefaultValueSql("((1))");

                entity.Property(e => e.emp_FechaCrea)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.emp_FechaModi).HasColumnType("datetime");

                entity.Property(e => e.emp_FechaNacimiento).HasColumnType("date");

                entity.Property(e => e.emp_Nombre)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.emp_Sexo)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.emp_Telefono)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.emp_EstadoCivilNavigation)
                    .WithMany(p => p.tbEmpleados)
                    .HasForeignKey(d => d.emp_EstadoCivil)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Gral_tbEmpleados_emp_EstadoCivil_Gral_tbEstadoCivil_est_ID");

                entity.HasOne(d => d.emp_MunicipioNavigation)
                    .WithMany(p => p.tbEmpleados)
                    .HasForeignKey(d => d.emp_Municipio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Gral_tbEmpleados_emp_Municipio_Gral_tbMunicipios_mun_ID");

                entity.HasOne(d => d.emp_SucursalNavigation)
                    .WithMany(p => p.tbEmpleados)
                    .HasForeignKey(d => d.emp_Sucursal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Gral_tbEmpleados_emp_Sucursal_Gral_tbSucursales_emp_Sucursal_suc_Id");

                entity.HasOne(d => d.emp_UsuarioCreaNavigation)
                    .WithMany(p => p.tbEmpleadosemp_UsuarioCreaNavigation)
                    .HasForeignKey(d => d.emp_UsuarioCrea)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Gral_tbEmpleados_emp_UsuarioCrea_Gral_tbUsuarios_usu_ID");

                entity.HasOne(d => d.emp_UsuarioModiNavigation)
                    .WithMany(p => p.tbEmpleadosemp_UsuarioModiNavigation)
                    .HasForeignKey(d => d.emp_UsuarioModi)
                    .HasConstraintName("FK_Gral_tbEmpleados_emp_UsuarioModi_Gral_tbUsuarios_usu_ID");
            });

            modelBuilder.Entity<tbEstadosCiviles>(entity =>
            {
                entity.HasKey(e => e.est_ID)
                    .HasName("PK__tbEstado__40ADEC90EDE4B490");

                entity.ToTable("tbEstadosCiviles", "Gral");

                entity.Property(e => e.est_Descripcion)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.est_FechaCrea)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.est_FechaModi).HasColumnType("datetime");

                entity.HasOne(d => d.est_UsuarioCreaNavigation)
                    .WithMany(p => p.tbEstadosCivilesest_UsuarioCreaNavigation)
                    .HasForeignKey(d => d.est_UsuarioCrea)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Gral_tbEstadosCiviles_est_UsuarioCrea_Gral_tbUsuarios_usu_ID");

                entity.HasOne(d => d.est_UsuarioModiNavigation)
                    .WithMany(p => p.tbEstadosCivilesest_UsuarioModiNavigation)
                    .HasForeignKey(d => d.est_UsuarioModi)
                    .HasConstraintName("FK_Gral_tbEstadosCiviles_est_UsuarioModi_Gral_tbUsuarios_usu_ID");
            });

            modelBuilder.Entity<tbInventario>(entity =>
            {
                entity.HasKey(e => e.inv_Id)
                    .HasName("PK__tbInvent__A7F1E3E1332041AC");

                entity.ToTable("tbInventario", "Maqui");

                entity.Property(e => e.inv_Estado).HasDefaultValueSql("((1))");

                entity.Property(e => e.inv_FechaCrea)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.inv_FechaModi).HasColumnType("datetime");

                entity.HasOne(d => d.inv_ProductoNavigation)
                    .WithMany(p => p.tbInventario)
                    .HasForeignKey(d => d.inv_Producto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Maqui_tbInventario_Maqui_tbProducto");

                entity.HasOne(d => d.inv_UsuCreaNavigation)
                    .WithMany(p => p.tbInventarioinv_UsuCreaNavigation)
                    .HasForeignKey(d => d.inv_UsuCrea)
                    .HasConstraintName("FK_Maqui_tbInventario_inv_UsuCrea_Gral_tbUsuarios_usu_ID");

                entity.HasOne(d => d.inv_usuModiNavigation)
                    .WithMany(p => p.tbInventarioinv_usuModiNavigation)
                    .HasForeignKey(d => d.inv_usuModi)
                    .HasConstraintName("FK_Maqui_tbInventario_inv_usuModi_Gral_tbUsuarios_usu_ID");
            });

            modelBuilder.Entity<tbMetodoPago>(entity =>
            {
                entity.HasKey(e => e.met_Id)
                    .HasName("PK__tbMetodo__820DEB1E365F3FB4");

                entity.ToTable("tbMetodoPago", "Maqui");

                entity.Property(e => e.met_Descripcion)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.met_Estado).HasDefaultValueSql("((1))");

                entity.Property(e => e.met_FechaCrea)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.met_FechaModi).HasColumnType("datetime");

                entity.HasOne(d => d.met_UsuCreaNavigation)
                    .WithMany(p => p.tbMetodoPagomet_UsuCreaNavigation)
                    .HasForeignKey(d => d.met_UsuCrea)
                    .HasConstraintName("FK_Maqui_tbMetodoPago_met_UsuCrea_Gral_tbUsuarios_usu_ID");

                entity.HasOne(d => d.met_usuModiNavigation)
                    .WithMany(p => p.tbMetodoPagomet_usuModiNavigation)
                    .HasForeignKey(d => d.met_usuModi)
                    .HasConstraintName("FK_Maqui_tbMetodoPago_met_usuModi_Gral_tbUsuarios_usu_ID");
            });

            modelBuilder.Entity<tbMunicipios>(entity =>
            {
                entity.HasKey(e => e.mun_ID)
                    .HasName("PK__tbMunici__130DA68FCF6DDED1");

                entity.ToTable("tbMunicipios", "Gral");

                entity.Property(e => e.mun_Descripcion)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.mun_FechaCrea)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.mun_FechaModi).HasColumnType("datetime");

                entity.HasOne(d => d.mun_UsuarioCreaNavigation)
                    .WithMany(p => p.tbMunicipiosmun_UsuarioCreaNavigation)
                    .HasForeignKey(d => d.mun_UsuarioCrea)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Gral_tbMunicipios_mun_UsuarioCrea_Gral_tbUsuarios_usu_ID");

                entity.HasOne(d => d.mun_UsuarioModiNavigation)
                    .WithMany(p => p.tbMunicipiosmun_UsuarioModiNavigation)
                    .HasForeignKey(d => d.mun_UsuarioModi)
                    .HasConstraintName("FK_Gral_tbMunicipios_mun_UsuarioModi_Gral_tbUsuarios_usu_ID");

                entity.HasOne(d => d.mun_dep)
                    .WithMany(p => p.tbMunicipios)
                    .HasForeignKey(d => d.mun_depID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Gral_tbMunicipios_mun_depID_Gral_tbDepartamentos_dep_ID");
            });

            modelBuilder.Entity<tbProductos>(entity =>
            {
                entity.HasKey(e => e.pro_Id)
                    .HasName("PK__tbProduc__335D708E81F8ED20");

                entity.ToTable("tbProductos", "Maqui");

                entity.HasIndex(e => e.pro_Codigo, "UK_Maqui_tbProductos_pro_Codigo")
                    .IsUnique();

                entity.Property(e => e.pro_Codigo)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.pro_Estado).HasDefaultValueSql("((1))");

                entity.Property(e => e.pro_FechaCrea)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.pro_FechaModi).HasColumnType("datetime");

                entity.Property(e => e.pro_Nombre)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.pro_PrecioUnitario).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.pro_StockInicial)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.pro_CategoriaNavigation)
                    .WithMany(p => p.tbProductos)
                    .HasForeignKey(d => d.pro_Categoria)
                    .HasConstraintName("FK_Maqui_tbProductos_pro_Categoria_Maqui_tbCategorias_cat_ID");

                entity.HasOne(d => d.pro_ProveedorNavigation)
                    .WithMany(p => p.tbProductos)
                    .HasForeignKey(d => d.pro_Proveedor)
                    .HasConstraintName("FK_Maqui_tbProductos_Maqui_tbProveedores_pro_Proveedor");

                entity.HasOne(d => d.pro_UsuModiNavigation)
                    .WithMany(p => p.tbProductospro_UsuModiNavigation)
                    .HasForeignKey(d => d.pro_UsuModi)
                    .HasConstraintName("FK_Maqui_tbProductos_pro_UsuModi_Gral_tbUsuarios_usu_ID");

                entity.HasOne(d => d.pro_usuCreaNavigation)
                    .WithMany(p => p.tbProductospro_usuCreaNavigation)
                    .HasForeignKey(d => d.pro_usuCrea)
                    .HasConstraintName("FK_Maqui_tbProductos_pro_usuCrea_Gral_tbUsuarios_usu_ID");
            });

            modelBuilder.Entity<tbProveedores>(entity =>
            {
                entity.HasKey(e => e.prv_ID)
                    .HasName("PK__tbProvee__28A716C89F2A3552");

                entity.ToTable("tbProveedores", "Maqui");

                entity.Property(e => e.prv_DireccionContacto)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.prv_DireccionEmpresa)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.prv_Estado).HasDefaultValueSql("((1))");

                entity.Property(e => e.prv_FechaCrea)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.prv_FechaModi).HasColumnType("datetime");

                entity.Property(e => e.prv_NombreCompañia)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.prv_NombreContacto)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.prv_SexoContacto)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.prv_TelefonoContacto)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.prv_MunicipioNavigation)
                    .WithMany(p => p.tbProveedores)
                    .HasForeignKey(d => d.prv_Municipio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PK_Maqui_tbProveedores_Gral_tbMunicipios_prv_Municipio");

                entity.HasOne(d => d.prv_UsuarioCreaNavigation)
                    .WithMany(p => p.tbProveedoresprv_UsuarioCreaNavigation)
                    .HasForeignKey(d => d.prv_UsuarioCrea)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Maqui_tbProveedores_prv_UsuarioCrea_Gral_tbUsuarios_usu_ID");

                entity.HasOne(d => d.prv_UsuarioModiNavigation)
                    .WithMany(p => p.tbProveedoresprv_UsuarioModiNavigation)
                    .HasForeignKey(d => d.prv_UsuarioModi)
                    .HasConstraintName("FK_Maqui_tbProveedores_prv_UsuarioModi_Gral_tbUsuarios_usu_ID");
            });

            modelBuilder.Entity<tbSucursales>(entity =>
            {
                entity.HasKey(e => e.suc_Id)
                    .HasName("PK__tbSucurs__C6E323770E308BB7");

                entity.ToTable("tbSucursales", "Gral");

                entity.Property(e => e.suc_Descripcion)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.suc_Estado).HasDefaultValueSql("((1))");

                entity.Property(e => e.suc_FechaCrea)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.suc_FechaModi).HasColumnType("datetime");

                entity.HasOne(d => d.suc_MunicipioNavigation)
                    .WithMany(p => p.tbSucursales)
                    .HasForeignKey(d => d.suc_Municipio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Maqui_tbSucursales_Gral_tbMunicipios");

                entity.HasOne(d => d.suc_UsuCreaNavigation)
                    .WithMany(p => p.tbSucursalessuc_UsuCreaNavigation)
                    .HasForeignKey(d => d.suc_UsuCrea)
                    .HasConstraintName("FK_Gral_tbSucursales_suc_UsuCrea_Gral_tbUsuarios_usu_ID");

                entity.HasOne(d => d.suc_usuModiNavigation)
                    .WithMany(p => p.tbSucursalessuc_usuModiNavigation)
                    .HasForeignKey(d => d.suc_usuModi)
                    .HasConstraintName("FK_Gral_tbSucursales_suc_usuModi_Gral_tbUsuarios_usu_ID");
            });

            modelBuilder.Entity<tbUsuarios>(entity =>
            {
                entity.HasKey(e => e.usu_ID)
                    .HasName("PK__tbUsuari__43056324CF4C2EBE");

                entity.ToTable("tbUsuarios", "Gral");

                entity.HasIndex(e => e.usu_Usuario, "UQ_Gral_tbUsuarios_usu_Usuario")
                    .IsUnique();

                entity.Property(e => e.usu_Clave).IsRequired();

                entity.Property(e => e.usu_Estado).HasDefaultValueSql("((1))");

                entity.Property(e => e.usu_FechaCrea)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.usu_FechaModi).HasColumnType("datetime");

                entity.Property(e => e.usu_Usuario)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.usu_emp)
                    .WithMany(p => p.tbUsuarios)
                    .HasForeignKey(d => d.usu_empID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Gral_tbUsuarios_usu_empID_Gral_tbEmpleados_emp_ID");
            });

            modelBuilder.Entity<tbVentas>(entity =>
            {
                entity.HasKey(e => e.ven_Id)
                    .HasName("PK__tbVentas__7BA9B7516857618F");

                entity.ToTable("tbVentas", "Maqui");

                entity.Property(e => e.ven_Estado).HasDefaultValueSql("((1))");

                entity.Property(e => e.ven_Fecha).HasColumnType("datetime");

                entity.Property(e => e.ven_FechaCrea)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ven_FechaModi).HasColumnType("datetime");

                entity.HasOne(d => d.ven_ClienteNavigation)
                    .WithMany(p => p.tbVentas)
                    .HasForeignKey(d => d.ven_Cliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Maqui_tbVentas_Gral_tbClientes_ven_Cliente");

                entity.HasOne(d => d.ven_EmpleadoNavigation)
                    .WithMany(p => p.tbVentas)
                    .HasForeignKey(d => d.ven_Empleado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Maqui_tbVentas_Gral_tbClientes_ven_Empleado");

                entity.HasOne(d => d.ven_MetodoPagoNavigation)
                    .WithMany(p => p.tbVentas)
                    .HasForeignKey(d => d.ven_MetodoPago)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Maqui_tbVentas_Maqui_tbMetodoPago_ven_MetodoPago");

                entity.HasOne(d => d.ven_SucursalNavigation)
                    .WithMany(p => p.tbVentas)
                    .HasForeignKey(d => d.ven_Sucursal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Maqui_tbVentas_Maqui_tbSucursales_ven_Sucursal");

                entity.HasOne(d => d.ven_UsuCreaNavigation)
                    .WithMany(p => p.tbVentasven_UsuCreaNavigation)
                    .HasForeignKey(d => d.ven_UsuCrea)
                    .HasConstraintName("FK_Maqui_tbVentas_ven_UsuCrea_Gral_tbUsuarios_usu_ID");

                entity.HasOne(d => d.ven_UsuModiNavigation)
                    .WithMany(p => p.tbVentasven_UsuModiNavigation)
                    .HasForeignKey(d => d.ven_UsuModi)
                    .HasConstraintName("FK_Maqui_tbVentas_ven_UsuModi_Gral_tbUsuarios_usu_ID");
            });

            modelBuilder.Entity<tbVentasDetalle>(entity =>
            {
                entity.HasKey(e => e.vde_Id)
                    .HasName("PK__tbVentas__C993F9CF31AA32C4");

                entity.ToTable("tbVentasDetalle", "Maqui");

                entity.Property(e => e.vde_Estado).HasDefaultValueSql("((1))");

                entity.Property(e => e.vde_FechaCrea)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.vde_FechaModi).HasColumnType("datetime");

                entity.HasOne(d => d.vde_ProductoNavigation)
                    .WithMany(p => p.tbVentasDetalle)
                    .HasForeignKey(d => d.vde_Producto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Maqui_tbVentasDetalles_tbMaqui_Produtos_VD_Producto");

                entity.HasOne(d => d.vde_UsuCreaNavigation)
                    .WithMany(p => p.tbVentasDetallevde_UsuCreaNavigation)
                    .HasForeignKey(d => d.vde_UsuCrea)
                    .HasConstraintName("FK_Maqui_tbVentasDetalle_vde_UsuCrea_Gral_tbUsuarios_usu_ID");

                entity.HasOne(d => d.vde_UsuModiNavigation)
                    .WithMany(p => p.tbVentasDetallevde_UsuModiNavigation)
                    .HasForeignKey(d => d.vde_UsuModi)
                    .HasConstraintName("FK_Maqui_tbVentasDetalle_vde_UsuModi_Gral_tbUsuarios_usu_ID");

                entity.HasOne(d => d.vde_Venta)
                    .WithMany(p => p.tbVentasDetalle)
                    .HasForeignKey(d => d.vde_VentaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Maqui_tbVentas_MaquiDetalles_tbVentasDetalle_VD_VentaId");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}