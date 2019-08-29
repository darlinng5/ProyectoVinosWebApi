using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NoticiasWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoVinowWebApi.Models
{
    public class FincaCompra
    {
        public int id { get; set; }
        public double valorUnitario { get; set; }
        public double cantidad { get; set; }
        public int esPagoAlContado { get; set; }
        public string observacion { get; set; }

        public int idProceso { get; set; }

        public FincaProceso FincaProceso { get; set; }

        public int idProductoPresentacion { get; set; }
        public ProductoPresentacion ProductoPresentacion { get; set; }


        public class Map
        {
            public Map(EntityTypeBuilder<FincaCompra> ebFincaCompra)
            {

                ebFincaCompra.HasKey(x=>x.id);
                ebFincaCompra.Property(x => x.valorUnitario).HasColumnName(PropiedadesDeModelos.valorUnitario).HasColumnType("decimal");
                ebFincaCompra.Property(x => x.cantidad).HasColumnName(PropiedadesDeModelos.cantidad).HasColumnType("decimal");
                ebFincaCompra.Property(x => x.esPagoAlContado).HasColumnType(PropiedadesDeModelos.esPagoAlContado).HasColumnType("int");
                ebFincaCompra.Property(x => x.observacion).HasColumnName(PropiedadesDeModelos.observacion).HasMaxLength(150);
                ebFincaCompra.Property(x => x.idProceso).HasColumnName("idProceso").HasColumnType("int");
                ebFincaCompra.HasOne(x => x.FincaProceso);
                ebFincaCompra.Property(x => x.idProductoPresentacion).HasColumnName("idProductoPresentacion");
                ebFincaCompra.HasOne(x => x.ProductoPresentacion);

            }
        }



    }
}
