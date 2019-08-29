using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NoticiasWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoVinowWebApi.Models
{
    public class ProductoPresentacion
    {
        public int idProductoPresentacion { get; set; }
        public string nombre { get; set; }


        public class Map
        {
            public Map(EntityTypeBuilder<ProductoPresentacion>ebProductoPresentacion)
            {
                ebProductoPresentacion.HasKey(x => x.idProductoPresentacion);
                ebProductoPresentacion.Property(x => x.nombre).HasColumnName(PropiedadesDeModelos.nombre).HasMaxLength(50);


            }

        }


    }
}
