using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NoticiasWebApi.Models
{
    public class Productos
    {
        [Key]
        public int idProducto { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string tipoSemilla { get; set; }
        public string estado { get; set; }
        public class Map
        {
            public Map(EntityTypeBuilder<Productos> ebProductos)
            {
                ebProductos.HasKey(x => x.idProducto);
                ebProductos.Property(x => x.nombre).HasColumnName(PropiedadesDeModelos.nombreProducto).HasMaxLength(20);
                ebProductos.Property(x => x.descripcion).HasColumnName(PropiedadesDeModelos.descripcionProducto).HasMaxLength(150);
                ebProductos.Property(x => x.tipoSemilla).HasColumnName(PropiedadesDeModelos.tipoSemillaProducto).HasMaxLength(25);
                ebProductos.Property(x => x.estado).HasColumnName(PropiedadesDeModelos.estadoProducto).HasMaxLength(15);
            }
        }
    }
}
