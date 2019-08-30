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
    [Migration("20190828020105_AddTableFincaCompra")]
    partial class AddTableFincaCompra
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

                    b.Property<int>("idFinca")
                        .HasColumnName("idFinca")
                        .HasColumnType("int");

                    b.Property<int>("idProducto")
                        .HasColumnName("idProducto")
                        .HasColumnType("int");

                    b.Property<string>("nombre")
                        .HasColumnName("nombre")
                        .HasMaxLength(20);

                    b.HasKey("idProceso");

                    b.HasIndex("idFinca");

                    b.HasIndex("idProducto");

                    b.ToTable("FincaProceso");
                });

            modelBuilder.Entity("NoticiasWebApi.Models.Productos", b =>
                {
                    b.Property<int>("idProducto")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("descripcion")
                        .HasColumnName("descripcion")
                        .HasMaxLength(150);

                    b.Property<string>("estado")
                        .HasColumnName("estado")
                        .HasMaxLength(15);

                    b.Property<int>("idSemilla")
                        .HasColumnName("idSemilla")
                        .HasColumnType("int");

                    b.Property<string>("nombre")
                        .HasColumnName("nombre")
                        .HasMaxLength(20);

                    b.HasKey("idProducto");

                    b.HasIndex("idSemilla");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("ProyectoVinowWebApi.Models.FincaCompra", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("cantidad")
                        .HasConversion(new ValueConverter<decimal, decimal>(v => default(decimal), v => default(decimal), new ConverterMappingHints(precision: 38, scale: 17)))
                        .HasColumnName("cantidad")
                        .HasColumnType("decimal");

                    b.Property<int>("esPagoAlContado")
                        .HasColumnType("int");

                    b.Property<int>("idProceso")
                        .HasColumnName("idProceso")
                        .HasColumnType("int");

                    b.Property<int>("idProductoPresentacion")
                        .HasColumnName("idProductoPresentacion");

                    b.Property<string>("observacion")
                        .HasColumnName("Observacion")
                        .HasMaxLength(150);

                    b.Property<decimal>("valorUnitario")
                        .HasConversion(new ValueConverter<decimal, decimal>(v => default(decimal), v => default(decimal), new ConverterMappingHints(precision: 38, scale: 17)))
                        .HasColumnName("valorUnitario")
                        .HasColumnType("decimal");

                    b.HasKey("id");

                    b.HasIndex("idProceso");

                    b.HasIndex("idProductoPresentacion");

                    b.ToTable("FincaCompra");
                });

            modelBuilder.Entity("ProyectoVinowWebApi.Models.FincaEvaluacion", b =>
                {
                    b.Property<int>("idEvaluacion")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("estado")
                        .HasColumnName("estado")
                        .HasMaxLength(20);

                    b.Property<DateTime>("fechaInspeccion")
                        .HasColumnName("fechaInspeccion")
                        .HasColumnType("Datetime");

                    b.Property<DateTime>("fechaVisita")
                        .HasColumnName("fechaVisita")
                        .HasColumnType("Datetime");

                    b.Property<int>("idProceso")
                        .HasColumnName("idProceso")
                        .HasColumnType("int");

                    b.Property<string>("observacion")
                        .HasColumnName("Observacion")
                        .HasMaxLength(2147483647);

                    b.Property<string>("valoracionTerreno")
                        .HasColumnName("valoracionTerreno")
                        .HasMaxLength(20);

                    b.HasKey("idEvaluacion");

                    b.HasIndex("idProceso");

                    b.ToTable("FincaEvaluacion");
                });

            modelBuilder.Entity("ProyectoVinowWebApi.Models.FincaInspeccion", b =>
                {
                    b.Property<int>("idInspeccion")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("estado")
                        .HasColumnName("estado")
                        .HasMaxLength(20);

                    b.Property<DateTime>("fechaCompra")
                        .HasColumnName("fechaCompra")
                        .HasColumnType("Datetime");

                    b.Property<DateTime>("fechaVisita")
                        .HasColumnName("fechaVisita")
                        .HasColumnType("Datetime");

                    b.Property<int>("idProceso")
                        .HasColumnName("idProceso")
                        .HasColumnType("int");

                    b.Property<string>("observacion")
                        .HasColumnName("Observacion")
                        .HasMaxLength(2147483647);

                    b.HasKey("idInspeccion");

                    b.HasIndex("idProceso");

                    b.ToTable("FincaInspeccion");
                });

            modelBuilder.Entity("ProyectoVinowWebApi.Models.LLamadasAFinca", b =>
                {
                    b.Property<int>("idLLamada")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("fechaLLamada")
                        .HasColumnName("fechaLLamada")
                        .HasColumnType("Datetime");

                    b.Property<DateTime>("fechaVisita")
                        .HasColumnName("fechaVisita")
                        .HasColumnType("Datetime");

                    b.Property<int>("idProceso")
                        .HasColumnName("idProceso")
                        .HasColumnType("int");

                    b.Property<string>("observacion")
                        .HasColumnName("Observacion")
                        .HasMaxLength(2147483647);

                    b.HasKey("idLLamada");

                    b.HasIndex("idProceso");

                    b.ToTable("LlamadasAFinca");
                });

            modelBuilder.Entity("ProyectoVinowWebApi.Models.ProductoPresentacion", b =>
                {
                    b.Property<int>("idProductoPresentacion")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("nombre")
                        .HasColumnName("nombre")
                        .HasMaxLength(50);

                    b.HasKey("idProductoPresentacion");

                    b.ToTable("ProductoPresentacion");
                });

            modelBuilder.Entity("ProyectoVinowWebApi.Models.Semilla", b =>
                {
                    b.Property<int>("idSemilla")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("descripcion")
                        .HasColumnName("descripcion")
                        .HasMaxLength(150);

                    b.Property<string>("estado")
                        .HasColumnName("estado")
                        .HasMaxLength(15);

                    b.Property<string>("nombre")
                        .HasColumnName("nombre")
                        .HasMaxLength(40);

                    b.HasKey("idSemilla");

                    b.ToTable("Semilla");
                });

            modelBuilder.Entity("NoticiasWebApi.Models.FincaProceso", b =>
                {
                    b.HasOne("NoticiasWebApi.Models.Finca", "Finca")
                        .WithMany()
                        .HasForeignKey("idFinca")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NoticiasWebApi.Models.Productos", "Productos")
                        .WithMany()
                        .HasForeignKey("idProducto")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NoticiasWebApi.Models.Productos", b =>
                {
                    b.HasOne("ProyectoVinowWebApi.Models.Semilla", "Semilla")
                        .WithMany()
                        .HasForeignKey("idSemilla")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProyectoVinowWebApi.Models.FincaCompra", b =>
                {
                    b.HasOne("NoticiasWebApi.Models.FincaProceso", "FincaProceso")
                        .WithMany()
                        .HasForeignKey("idProceso")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProyectoVinowWebApi.Models.ProductoPresentacion", "ProductoPresentacion")
                        .WithMany()
                        .HasForeignKey("idProductoPresentacion")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProyectoVinowWebApi.Models.FincaEvaluacion", b =>
                {
                    b.HasOne("NoticiasWebApi.Models.FincaProceso", "FincaProceso")
                        .WithMany()
                        .HasForeignKey("idProceso")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProyectoVinowWebApi.Models.FincaInspeccion", b =>
                {
                    b.HasOne("NoticiasWebApi.Models.FincaProceso", "FincaProceso")
                        .WithMany()
                        .HasForeignKey("idProceso")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProyectoVinowWebApi.Models.LLamadasAFinca", b =>
                {
                    b.HasOne("NoticiasWebApi.Models.FincaProceso", "FincaProceso")
                        .WithMany()
                        .HasForeignKey("idProceso")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
