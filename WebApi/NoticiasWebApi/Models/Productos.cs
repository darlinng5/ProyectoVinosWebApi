using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProyectoVinowWebApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NoticiasWebApi.Models
{
    public class Productos
    {
      
        public int idProducto { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string estado { get; set; }
        public int idSemilla { get; set; }
        public Semilla Semilla { get; set; }
        public class Map
        {
            public Map(EntityTypeBuilder<Productos> ebProducto)
            {
                ebProducto.HasKey(x => x.idProducto);
                ebProducto.Property(x => x.nombre).HasColumnName(PropiedadesDeModelos.nombre).HasMaxLength(20);
                ebProducto.Property(x => x.descripcion).HasColumnName(PropiedadesDeModelos.descripcion).HasMaxLength(150);
                ebProducto.Property(x => x.estado).HasColumnName(PropiedadesDeModelos.estado).HasMaxLength(15);
                ebProducto.Property(x => x.idSemilla).HasColumnName("idSemilla").HasColumnType("int");
                ebProducto.HasOne(x => x.Semilla);
            }
        }
    }
}
