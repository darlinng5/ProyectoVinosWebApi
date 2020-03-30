using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoVinowWebApi.Models
{
    public class Barrio
    {
        [Key]
        public int idBarrio { get; set; }
        public string nombreBarerio { get; set; }
        public int idMunicipio { get; set; }

        public Municipio municipio { get; set; }

        public class Map
        {
            public Map(EntityTypeBuilder<Barrio> etbBarrio)
            {
                etbBarrio.HasKey(x => x.idBarrio);
                etbBarrio.Property(x => x.nombreBarerio).HasColumnName("Nombre").HasMaxLength(50).IsRequired();
                etbBarrio.Property(x => x.idMunicipio).HasColumnType("int").HasColumnName("idMunicipio").IsRequired();
                etbBarrio.HasOne(x=>x.municipio);
            }
        }
    }
}
