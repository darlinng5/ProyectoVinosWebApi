using NoticiasWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoVinowWebApi.Domains
{
    public class ProductoDomain
    {
        public string validarIngresoProducto(Productos producto)
        {
            bool modeloProductoEstaVacio = producto == null;
            if (modeloProductoEstaVacio)
            {
                return "El modelo de producto esta vacio";
            }

            bool estaNombreVacio = producto.nombre == string.Empty;
            if (estaNombreVacio)
            {
                return "El nombre del producto esta vacio";
            }

            bool esEstadoIncorrecto = producto.estado != PropiedadesDeModelos.estadoCreado;
            if (esEstadoIncorrecto)
            {
                return "El estado es incorrecto";
            }

            return null;
        }
    }
}
