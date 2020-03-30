using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoVinowWebApi.Models
{
    public class Canjeo
    {
        [Key]
        public int idCanjeo { get; set; }
        public DateTime fechaCanjeo { get; set; }
        public int puntosCajeados { get; set; }
        public float valorEnDinero { get; set; }

        public int idDirecion { get; set; }
        public Direccion direccion { get; set; }

        public class Map
        {
            public Map(EntityTypeBuilder<Canjeo> etbCanjeo)
            {
                etbCanjeo.HasKey(x => x.idCanjeo);
                etbCanjeo.Property(x => x.fechaCanjeo).HasColumnType("datetime").HasColumnName("Fecha_Canjeo").IsRequired();
                etbCanjeo.Property(x => x.puntosCajeados).HasColumnType("int").HasColumnName("Puntos_Canjeados").IsRequired();
                etbCanjeo.Property(x => x.valorEnDinero).HasColumnType("float").HasColumnName("Valor_En_Dinero");
                etbCanjeo.Property(x => x.idDirecion).HasColumnType("int").HasColumnName("idDireccion").IsRequired();
                etbCanjeo.HasOne(x => x.direccion);
            }
        }

    }
}
