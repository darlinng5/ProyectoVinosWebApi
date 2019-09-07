using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NoticiasWebApi;
using NoticiasWebApi.Models;

namespace ProyectoVinowWebApi.Controllers
{
    [Route("api/productos")]
    [ApiController]
    public class ProductoController : ControllerBase
    {


        public readonly DBContext _Db;
        public ProductoController(DBContext _DBcontext)
        {
            _Db = _DBcontext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Productos>>> getProductos()
        {
            return await _Db.Productos.ToArrayAsync();
        }

    }
}