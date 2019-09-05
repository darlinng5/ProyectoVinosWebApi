using Microsoft.EntityFrameworkCore;
using NoticiasWebApi.Models;
using ProyectoVinowWebApi.Models;

namespace NoticiasWebApi
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions opciones): base(opciones)
        {
            
        }
        public virtual DbSet<Productos> Productos { get; set; }
        public virtual DbSet<Semilla> Semilla { get; set; }
        public virtual DbSet<Finca> Finca { get; set; }
        public virtual DbSet<FincaProceso> FincaProceso { get; set; }
        public virtual DbSet<LLamadasAFinca> LLamadasAFinca { get; set; }
        public virtual DbSet<FincaEvaluacion> FincaEvaluacion { get; set; }
        public virtual DbSet<FincaInspeccion> FincaInspeccion { get; set; }

        public virtual DbSet<ProductoPresentacion> ProductoPresentacion { get; set; }
        public virtual DbSet<FincaCompra> FincaCompra { get; set; }


        protected override void OnModelCreating(ModelBuilder modelB)
        {
            new ProductoPresentacion.Map(modelB.Entity<ProductoPresentacion>());
            new FincaCompra.Map(modelB.Entity<FincaCompra>());
            new Productos.Map(modelB.Entity<Productos>());
            new Semilla.Map(modelB.Entity<Semilla>());
            new Finca.Map(modelB.Entity<Finca>());
            new FincaProceso.Map(modelB.Entity<FincaProceso>());
            new LLamadasAFinca.Map(modelB.Entity<LLamadasAFinca>());
            new FincaEvaluacion.Map(modelB.Entity<FincaEvaluacion>());
            new FincaInspeccion.Map(modelB.Entity<FincaInspeccion>());
            base.OnModelCreating(modelB);
        }
    }
}
