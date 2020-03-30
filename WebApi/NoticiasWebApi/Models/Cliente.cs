using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoVinowWebApi.Models
{
    public class Cliente
    {
        [Key]
        public int idCliente { get; set; }
        public string identidad { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string telefono { get; set; }

        public class Map
        {
            public Map(EntityTypeBuilder<Cliente> etbCliente)
            {
                etbCliente.HasKey(x => x.idCliente);
                etbCliente.Property(x => x.identidad).HasColumnName("Identidad").HasMaxLength(13).IsRequired();
                etbCliente.Property(x => x.nombres).HasColumnName("Nombres").HasMaxLength(50).IsRequired();
                etbCliente.Property(x => x.apellidos).HasColumnName("Apellidos").HasMaxLength(50).IsRequired();
                etbCliente.Property(x => x.telefono).HasColumnName("Telefono").HasMaxLength(8);
            }
        }

    }
}
