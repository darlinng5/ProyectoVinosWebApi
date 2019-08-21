using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NoticiasWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoVinowWebApi.Models
{
    public class FincaEvaluacion
    {
        public int idEvaluacion { get; set; }
        public string observacion { get; set; }
        public DateTime fechaVisita { get; set; }
        public string valoracionTerreno { get; set; }

        public DateTime fechaInspeccion { get; set; }
        public string estado { get; set; }

        public int idProceso { get; set; }

        public FincaProceso FincaProceso { get; set; }


        public class Map
        {
            public Map(EntityTypeBuilder<FincaEvaluacion> ebFincaEvaluacion)
            {
                ebFincaEvaluacion.HasKey(x => x.idEvaluacion);
                ebFincaEvaluacion.Property(x => x.observacion).HasColumnName(PropiedadesDeModelos.observacion).HasMaxLength(int.MaxValue);
                ebFincaEvaluacion.Property(x => x.fechaVisita).HasColumnName(PropiedadesDeModelos.fechaVisita).HasColumnType("Datetime");
                ebFincaEvaluacion.Property(x => x.valoracionTerreno).HasColumnName(PropiedadesDeModelos.valoracionTerreno).HasMaxLength(20);
                ebFincaEvaluacion.Property(x => x.fechaInspeccion).HasColumnName(PropiedadesDeModelos.fechaInspeccion).HasColumnType("Datetime");
                ebFincaEvaluacion.Property(x => x.estado).HasColumnName(PropiedadesDeModelos.estado).HasMaxLength(20);
                ebFincaEvaluacion.Property(x => x.idProceso).HasColumnName("idProceso").HasColumnType("int");
                ebFincaEvaluacion.HasOne(x => x.FincaProceso);
            }
        }

    }
}
