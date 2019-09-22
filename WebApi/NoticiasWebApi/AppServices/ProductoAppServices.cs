using NoticiasWebApi;
using NoticiasWebApi.Models;
using ProyectoVinowWebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoVinowWebApi.AppServices
{
    public class ProductoAppServices
    {
        public readonly DBContext _DB;
        public readonly ProductoDomain _productoDomain;

        public ProductoAppServices(DBContext dBContext, ProductoDomain productoDomain)
        {
            _DB = dBContext;
            _productoDomain = productoDomain;
        }

        public async Task<string> IngresarProducto(Productos producto)
        {
            var respuestaProductoDomain = _productoDomain.validarIngresoProducto(producto);
            bool ErrorEnDomain = respuestaProductoDomain != null;

            if (ErrorEnDomain)
            {
                return respuestaProductoDomain;
            }

            try
            {
                producto.estado = PropiedadesDeModelos.estadoCreado;
                _DB.Add(producto);
                await _DB.SaveChangesAsync();
            }
            catch (Exception e)
            {

                return e.Message;
            }

            return null;
        }
    }
}
