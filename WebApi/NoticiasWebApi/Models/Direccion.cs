using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoVinowWebApi.Models
{
    public class Direccion
    {
        [Key]
        public int idDireccion { get; set; }
        public string referencia { get; set; }

        public int idBarrio { get; set; }
        public Barrio barrio { get; set; }

        public int idCliente { get; set; }
        public Cliente cliente { get; set; }

        public class Map
        {
            public Map(EntityTypeBuilder<Direccion> etbDireccion)
            {
                etbDireccion.HasKey(x => x.idDireccion);
                etbDireccion.Property(x => x.referencia).HasColumnName("Refererncia").HasMaxLength(700).IsRequired();
                etbDireccion.Property(x => x.idBarrio).HasColumnType("int").HasColumnName("idBarrio").IsRequired();
                etbDireccion.HasOne(x => x.barrio);
                etbDireccion.Property(x => x.idCliente).HasColumnType("int").HasColumnName("idCliente").IsRequired();
                etbDireccion.HasOne(x => x.cliente);
            }
        }

    }
}
