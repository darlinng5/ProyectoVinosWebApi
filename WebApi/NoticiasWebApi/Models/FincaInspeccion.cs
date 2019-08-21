using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NoticiasWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoVinowWebApi.Models
{
    public class FincaInspeccion
    {
        public int idInspeccion { get; set; }
        public string observacion { get; set; }
        public DateTime fechaVisita { get; set; }
        public DateTime fechaCompra { get; set; }
        public string estado { get; set; }

        public int idProceso { get; set; }

        public FincaProceso FincaProceso { get; set; }


        public class Map
        {
            public Map(EntityTypeBuilder<FincaInspeccion> ebFincaInspeccion)
            {
                ebFincaInspeccion.HasKey(x => x.idInspeccion);
                ebFincaInspeccion.Property(x => x.observacion).HasColumnName(PropiedadesDeModelos.observacion).HasMaxLength(int.MaxValue);
                ebFincaInspeccion.Property(x => x.fechaVisita).HasColumnName(PropiedadesDeModelos.fechaVisita).HasColumnType("Datetime");
                ebFincaInspeccion.Property(x => x.fechaCompra).HasColumnName(PropiedadesDeModelos.fechaCompra).HasColumnType("Datetime");
                ebFincaInspeccion.Property(x => x.estado).HasColumnName(PropiedadesDeModelos.estado).HasMaxLength(20);
                ebFincaInspeccion.Property(x => x.idProceso).HasColumnName("idProceso").HasColumnType("int");
                ebFincaInspeccion.HasOne(x => x.FincaProceso);
            }
        }
    }
}
