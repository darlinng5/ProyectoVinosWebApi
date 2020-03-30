using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoVinowWebApi.Models
{
    public class Recipiente
    {
        [Key]
        public int idRecipiente { get; set; }
        public string nombreRecipiente { get; set; }

        public int idTipoRecipiente { get; set; }
        public tipoRecipiente TipoRecipiente { get; set; }

        public class Map
        {
            public Map(EntityTypeBuilder<Recipiente> etbRecipiente)
            {
                etbRecipiente.HasKey(x => x.idRecipiente);
                etbRecipiente.Property(x => x.nombreRecipiente).HasColumnName("Recipiente").HasMaxLength(70).IsRequired();
                etbRecipiente.Property(x => x.idTipoRecipiente).HasColumnType("int").HasColumnName("idTipoRecipiente").IsRequired();
                etbRecipiente.HasOne(x => x.TipoRecipiente);
            }
        }
    }
}
