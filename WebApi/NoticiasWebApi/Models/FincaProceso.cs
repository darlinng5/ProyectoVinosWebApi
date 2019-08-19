using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoticiasWebApi.Models
{
    public class FincaProceso
    {
        public int idProceso { get; set; }
        public string nombre { get; set; }
        public DateTime fechaInicio { get; set; }
        public string estado { get; set; }

        public int idFinca { get; set; }
        public Finca Finca { get; set; }


        public class Map
        {
            public Map(EntityTypeBuilder<FincaProceso> ebFincaProceso)
            {
                ebFincaProceso.HasKey(x => x.idProceso);
                ebFincaProceso.Property(x => x.nombre).HasColumnName(PropiedadesDeModelos.nombreFincaProceso).HasMaxLength(20);
                ebFincaProceso.Property(x => x.fechaInicio).HasColumnName(PropiedadesDeModelos.FechaInicioFincaProceso).HasColumnType("Datetime");
                ebFincaProceso.Property(x => x.estado).HasColumnName(PropiedadesDeModelos.estadoFincaProceso).HasMaxLength(25);
                ebFincaProceso.Property(x => x.idFinca).HasColumnName("idFinca").HasColumnType("int");
                ebFincaProceso.HasOne(x => x.Finca);
            }
        }
    }
}
