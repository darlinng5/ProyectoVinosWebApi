using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NoticiasWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoVinowWebApi.Models
{
    public class Semilla
    {
        public int idSemilla { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string estado { get; set; }

        public class Map
        {
            public Map(EntityTypeBuilder<Semilla> ebSemilla)
            {
                ebSemilla.HasKey(x => x.idSemilla);
                ebSemilla.Property(x => x.nombre).HasColumnName(PropiedadesDeModelos.nombre).HasMaxLength(40);
                ebSemilla.Property(x => x.descripcion).HasColumnName(PropiedadesDeModelos.descripcion).HasMaxLength(150);
                ebSemilla.Property(x => x.estado).HasColumnName(PropiedadesDeModelos.estado).HasMaxLength(15);
            }
        }

    }
}
