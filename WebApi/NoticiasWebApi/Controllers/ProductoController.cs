using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NoticiasWebApi;
using NoticiasWebApi.Models;
using ProyectoVinowWebApi.AppServices;

namespace ProyectoVinowWebApi.Controllers
{
    [Route("api/productos")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        public readonly DBContext _Db;
        public readonly ProductoAppServices _productoAppServices;
        public ProductoController(DBContext _DBcontext, ProductoAppServices productoAppServices)
        {
            _Db = _DBcontext;
            _productoAppServices = productoAppServices;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Productos>>> getProductos()
        {
            return await _Db.Productos.ToArrayAsync();
        }

        public async Task<ActionResult> postProducto(Productos producto)
        {
            var respuestaProductoAppServices = await _productoAppServices.IngresarProducto(producto);
            bool ingresoInCorrectoDeProducto = respuestaProductoAppServices != null;
            if (ingresoInCorrectoDeProducto)
            {
                return BadRequest(respuestaProductoAppServices);
            }
            else
            {
                return Ok("Ingreso correcto de producto");
            }
        }

    }
}