using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoVinowWebApi.Models
{
    public class Departamento
    {
        [Key]
        public int idDepartamento { get; set; }
        public string codigoDepartamento { get; set; }
        public string nombreDepartamento { get; set; }

        public class Map
        {
            public Map(EntityTypeBuilder<Departamento> etbDepartamento)
            {
                etbDepartamento.HasKey(x => x.idDepartamento);
                etbDepartamento.Property(x => x.codigoDepartamento).HasColumnName("Codigo").HasMaxLength(13).IsRequired();
                etbDepartamento.Property(x => x.nombreDepartamento).HasColumnName("Nombre").HasMaxLength(50).IsRequired();                
            }
        }

    }
}
