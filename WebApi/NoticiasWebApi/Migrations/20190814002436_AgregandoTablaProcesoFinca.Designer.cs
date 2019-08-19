﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NoticiasWebApi;

namespace NoticiasWebApi.Migrations
{
    [DbContext(typeof(DBContext))]
    [Migration("20190814002436_AgregandoTablaProcesoFinca")]
    partial class AgregandoTablaProcesoFinca
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NoticiasWebApi.Models.Autor", b =>
                {
                    b.Property<int>("AutorID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido")
                        .HasColumnName("Apellido")
                        .HasMaxLength(50);

                    b.Property<string>("Nombre")
                        .HasColumnName("Nombre")
                        .HasMaxLength(50);

                    b.HasKey("AutorID");

                    b.ToTable("Autor");
                });

            modelBuilder.Entity("NoticiasWebApi.Models.Finca", b =>
                {
                    b.Property<int>("idFinca")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("departamento")
                        .HasColumnName("departamento")
                        .HasMaxLength(25);

                    b.Property<string>("descripcion")
                        .HasColumnName("descripcion")
                        .HasMaxLength(150);

                    b.Property<string>("estado")
                        .HasColumnName("estado")
                        .HasMaxLength(15);

                    b.Property<string>("municipio")
                        .HasColumnName("municipio")
                        .HasMaxLength(25);

                    b.Property<string>("nombre")
                        .HasColumnName("nombre")
                        .HasMaxLength(20);

                    b.HasKey("idFinca");

                    b.ToTable("Finca");
                });

            modelBuilder.Entity("NoticiasWebApi.Models.FincaProceso", b =>
                {
                    b.Property<int>("idProceso")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("estado")
                        .HasColumnName("estado")
                        .HasMaxLength(25);

                    b.Property<DateTime>("fechaInicio")
                        .HasColumnName("fechaInicio")
                        .HasColumnType("Datetime");

                    b.Property<string>("nombre")
                        .HasColumnName("nombre")
                        .HasMaxLength(20);

                    b.HasKey("idProceso");

                    b.ToTable("FincaProceso");
                });

            modelBuilder.Entity("NoticiasWebApi.Models.Nombres", b =>
                {
                    b.Property<int>("NombreID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre");

                    b.HasKey("NombreID");

                    b.ToTable("Nombres");
                });

            modelBuilder.Entity("NoticiasWebApi.Models.Productos", b =>
                {
                    b.Property<int>("idProducto")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("descripcion");

                    b.Property<string>("estado");

                    b.Property<string>("nombre");

                    b.Property<string>("tipoSemilla");

                    b.HasKey("idProducto");

                    b.ToTable("Productos");
                });
#pragma warning restore 612, 618
        }
    }
}
