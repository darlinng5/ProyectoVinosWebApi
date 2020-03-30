using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoVinowWebApi.Models
{
    public class Puntos
    {
        [Key]
        public int idPuntos { get; set; }
        public int puntos { get; set; }

        public int idDireccion { get; set; }
        public Direccion Direccion { get; set; }

        public class Map
        {
            public Map(EntityTypeBuilder<Puntos> etbPuntos)
            {
                etbPuntos.HasKey(x => x.idPuntos);
                etbPuntos.Property(x => x.puntos).HasColumnType("int").HasColumnName("Puntos").IsRequired();
                etbPuntos.Property(x => x.idDireccion).HasColumnType("int").HasColumnName("idDireccion").IsRequired();
                etbPuntos.HasOne(x => x.Direccion);
            }
        }
    }
}
