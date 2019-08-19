using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NoticiasWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoVinowWebApi.Models
{
    public class LLamadasAFinca
    {
        public int idLLamada { get; set; }
        public DateTime fechaLLamada { get; set; }
        public string observacion { get; set; }
        public DateTime fechaVisita { get; set; }

        public int idProceso { get; set; }

        public FincaProceso FincaProceso { get; set; }

        public class Map
        {
            public Map(EntityTypeBuilder<LLamadasAFinca> ebLLamadasAFinca)
            {
                ebLLamadasAFinca.HasKey(x => x.idLLamada);
                ebLLamadasAFinca.Property(x => x.fechaLLamada).HasColumnName(PropiedadesDeModelos.fechaLLamadaFinca).HasColumnType("Datetime");
                ebLLamadasAFinca.Property(x => x.observacion).HasColumnName(PropiedadesDeModelos.observacionLLamadaFinca).HasMaxLength(20);
                ebLLamadasAFinca.Property(x => x.fechaVisita).HasColumnName(PropiedadesDeModelos.fechaVisitaLLamadaFinca).HasColumnType("Datetime");
                ebLLamadasAFinca.Property(x => x.idProceso).HasColumnName("idProceso").HasColumnType("int");
                ebLLamadasAFinca.HasOne(x => x.FincaProceso);

            }
        }
    }
}
