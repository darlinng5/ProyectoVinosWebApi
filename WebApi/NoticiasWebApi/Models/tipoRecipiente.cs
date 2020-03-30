using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoVinowWebApi.Models
{
    public class tipoRecipiente
    {
        [Key]
        public int idTipoRecipiente { get; set; }
        public string nombreRecipiente { get; set; }

        public class Map
        {
            public Map(EntityTypeBuilder<tipoRecipiente> etbTipoRecipiente)
            {
                etbTipoRecipiente.HasKey(x=>x.idTipoRecipiente);
                etbTipoRecipiente.Property(x => x.nombreRecipiente).HasColumnName("Nombre").HasMaxLength(50).IsRequired();
            }
        }
    }
}
