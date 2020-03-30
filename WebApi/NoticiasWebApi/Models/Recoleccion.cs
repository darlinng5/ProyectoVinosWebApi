using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoVinowWebApi.Models
{
    public class Recoleccion
    {
        [Key]
        public int idRecoleccion { get; set; }
        public DateTime fechaRecoleccion { get; set; }
        public int cantidad { get; set; }
        public bool estaClasificada { get; set; }

        public int idRecipiente { get; set; }
        public Recipiente recipiente { get; set; }

        public class Map
        {
            public Map(EntityTypeBuilder<Recoleccion> etbRecoleccion)
            {
                etbRecoleccion.HasKey(x => x.idRecoleccion);
                etbRecoleccion.Property(x => x.fechaRecoleccion).HasColumnType("datetime").HasColumnName("Fecha_Recoleccion").IsRequired();
                etbRecoleccion.Property(x => x.cantidad).HasColumnType("int").HasColumnName("Cantidad").IsRequired();
                etbRecoleccion.Property(x => x.estaClasificada).HasColumnType("bit").HasColumnName("Estado_Clasificacion").IsRequired();
                etbRecoleccion.Property(x => x.idRecipiente).HasColumnType("int").HasColumnName("idRecipiente").IsRequired();
                etbRecoleccion.HasOne(x => x.recipiente);
            }
        }

    }
}
