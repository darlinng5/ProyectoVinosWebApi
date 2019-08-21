using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NoticiasWebApi.Models
{
    public class Finca
    {

        [Key]
        public int idFinca { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string departamento { get; set; }
        public string municipio { get; set; }
        public string estado { get; set; }

       

        public class Map
        {
            public Map(EntityTypeBuilder<Finca> ebFinca)
            {
                ebFinca.HasKey(x => x.idFinca);
                ebFinca.Property(x => x.nombre).HasColumnName(PropiedadesDeModelos.nombre).HasMaxLength(20);
                ebFinca.Property(x => x.descripcion).HasColumnName(PropiedadesDeModelos.descripcion).HasMaxLength(150);
                ebFinca.Property(x => x.departamento).HasColumnName(PropiedadesDeModelos.departamento).HasMaxLength(25);
                ebFinca.Property(x => x.municipio).HasColumnName(PropiedadesDeModelos.municipio).HasMaxLength(25);
                ebFinca.Property(x => x.estado).HasColumnName(PropiedadesDeModelos.estado).HasMaxLength(15);
            }
        }




    }
}
