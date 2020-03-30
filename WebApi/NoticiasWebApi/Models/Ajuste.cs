using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoVinowWebApi.Models
{
    public class Ajuste
    {
        [Key]
        public int idAjuste { get; set; }
        public string nombreAjuste { get; set; }
        public float valor { get; set; }

        public class Map
        {
            public Map(EntityTypeBuilder<Ajuste> etbAjuste)
            {
                etbAjuste.HasKey(x => x.idAjuste);
                etbAjuste.Property(x => x.nombreAjuste).HasColumnName("Nombre").HasMaxLength(50).IsRequired();
                etbAjuste.Property(x => x.valor).HasColumnType("float").HasColumnName("Valor").HasMaxLength(13).IsRequired();
            }
        }
    }
}
