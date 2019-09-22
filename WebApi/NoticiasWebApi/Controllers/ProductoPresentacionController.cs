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
using ProyectoVinowWebApi.Models;

namespace ProyectoVinowWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoPresentacionController : ControllerBase
    {
        public readonly DBContext _Db;
        public readonly ProductoAppServices _productoAppServices;

        public ProductoPresentacionController(DBContext _DBcontext, ProductoAppServices productoAppServices)
        {
            _Db = _DBcontext;
            _productoAppServices = productoAppServices;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductoPresentacion>>> getProductoPresentacion()
        {
            return await _Db.ProductoPresentacion.ToArrayAsync();
        }
    }
}