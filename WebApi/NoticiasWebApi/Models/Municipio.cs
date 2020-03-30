using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoVinowWebApi.Models
{
    public class Municipio
    {
        [Key]
        public int idMunicipio { get; set; }
        public string codigoMunicipio { get; set; }
        public string nombreMunicipio { get; set; }
        public int idDepartamento { get; set; }

        public Departamento departamento { get; set; }

        public class Map
        {
            public Map(EntityTypeBuilder<Municipio> etbMunicipio)
            {
                etbMunicipio.HasKey(x => x.idMunicipio);
                etbMunicipio.Property(x => x.codigoMunicipio).HasColumnName("Codigo").HasMaxLength(13).IsRequired();
                etbMunicipio.Property(x => x.nombreMunicipio).HasColumnName("Nombre").HasMaxLength(50).IsRequired();
                etbMunicipio.Property(x => x.idDepartamento).HasColumnType("int").HasColumnName("idDepartamento").IsRequired();
                etbMunicipio.HasOne(x => x.departamento);
            }
        }
    }
}
