using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Core.Interfaces;
using Project.Core.Model;

namespace Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaBusiness _business;
        public CategoriaController(ICategoriaBusiness business)
        {
            _business = business;
        }

        [HttpPost]
        public ActionResult AddCategoria([FromBody] Categoria categoria)
        {
            _business.AddCategoria(categoria);
            return Ok();
        }
        [HttpGet("{Id}")]
        public ActionResult GetById(Guid Id)
        {
            return Ok(_business.GetCategoriaById(Id));
        }
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_business.GetCategorias());
        }

    }
}