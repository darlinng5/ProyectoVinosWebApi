using Microsoft.EntityFrameworkCore;
//using NoticiasWebApi.Models;
using ProyectoVinowWebApi.Models;

namespace NoticiasWebApi
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions opciones): base(opciones)
        {
            
        }

        public virtual DbSet<tipoRecipiente> TipoRecipiente { get; set; }
        public virtual DbSet<Cliente> cliente { get; set; }
        public virtual DbSet<Departamento> departamento { get; set; }
        public virtual DbSet<Ajuste> ajuste { get; set; }
        public virtual DbSet<Municipio> municipio { get; set; }
        public virtual DbSet<Barrio> barrio { get; set; }
        public virtual DbSet<Direccion> direccion { get; set; }
        public virtual DbSet<Puntos> puntos { get; set; }
        public virtual DbSet<Recipiente> recipiente { get; set; }
        public virtual DbSet<Recoleccion> recoleccion { get; set; }
        public virtual DbSet<Canjeo> canjeo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelB)
        {
            new tipoRecipiente.Map(modelB.Entity<tipoRecipiente>());
            new Cliente.Map(modelB.Entity<Cliente>());
            new Departamento.Map(modelB.Entity<Departamento>());
            new Ajuste.Map(modelB.Entity<Ajuste>());
            new Municipio.Map(modelB.Entity<Municipio>());
            new Barrio.Map(modelB.Entity<Barrio>());
            new Direccion.Map(modelB.Entity<Direccion>());
            new Puntos.Map(modelB.Entity<Puntos>());
            new Recipiente.Map(modelB.Entity<Recipiente>());
            new Recoleccion.Map(modelB.Entity<Recoleccion>());
            new Canjeo.Map(modelB.Entity<Canjeo>());

            base.OnModelCreating(modelB);
        }
    }
}
