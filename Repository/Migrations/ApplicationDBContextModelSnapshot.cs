﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repository.DBContext;

#nullable disable

namespace Repository.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    partial class ApplicationDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Domain.Activo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("Estatus")
                        .HasColumnType("bit");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Activos");
                });

            modelBuilder.Entity("Domain.Activo_Empleado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Fecha_Asignacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Fecha_Entrega")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Fecha_Liberacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("Id_Activo")
                        .HasColumnType("int");

                    b.Property<int>("Id_Empleado")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Id_Activo");

                    b.HasIndex("Id_Empleado");

                    b.ToTable("Activo-Empleado");
                });

            modelBuilder.Entity("Domain.Persona", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("CURP")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<DateTime>("Fecha_Nacimiento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Personas");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Persona");
                });

            modelBuilder.Entity("Domain.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("Domain.Empleado", b =>
                {
                    b.HasBaseType("Domain.Persona");

                    b.Property<bool>("Estatus")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Fecha_Ingreso")
                        .HasColumnType("datetime2");

                    b.Property<int>("Numero_Empleado")
                        .HasColumnType("int");

                    b.ToTable("Personas");

                    b.HasDiscriminator().HasValue("Empleado");
                });

            modelBuilder.Entity("Domain.Activo_Empleado", b =>
                {
                    b.HasOne("Domain.Activo", "activo")
                        .WithMany("Activo_Empleados")
                        .HasForeignKey("Id_Activo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Empleado", "empleado")
                        .WithMany("Activo_Empleados")
                        .HasForeignKey("Id_Empleado")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("activo");

                    b.Navigation("empleado");
                });

            modelBuilder.Entity("Domain.Activo", b =>
                {
                    b.Navigation("Activo_Empleados");
                });

            modelBuilder.Entity("Domain.Empleado", b =>
                {
                    b.Navigation("Activo_Empleados");
                });
#pragma warning restore 612, 618
        }
    }
}
