﻿using Microsoft.EntityFrameworkCore;
using NoticiasWebApi.Models;
using ProyectoVinowWebApi.Models;

namespace NoticiasWebApi
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions opciones): base(opciones)
        {
            
        }
        public virtual DbSet<Finca> Finca { get; set; }
        public virtual DbSet<FincaProceso> FincaProceso { get; set; }
        public virtual DbSet<LLamadasAFinca> LlamadasAFinca { get; set; }
        public virtual DbSet<FincaEvaluacion> FincaEvaluacion { get; set; }
        public virtual DbSet<Productos> Productos { get; set; }
        public virtual DbSet<Finca> Noticia { get; set; }
        public virtual DbSet<Autor> Autor { get; set;}
        public virtual DbSet<Nombres> Nombres { get; set; }


        protected override void OnModelCreating(ModelBuilder modelB)
        {
            new Finca.Map(modelB.Entity<Finca>());
            new FincaProceso.Map(modelB.Entity<FincaProceso>());
            new LLamadasAFinca.Map(modelB.Entity<LLamadasAFinca>());
            new FincaEvaluacion.Map(modelB.Entity<FincaEvaluacion>());
            new Autor.Map(modelB.Entity<Autor>());
            base.OnModelCreating(modelB);
        }
    }
}
