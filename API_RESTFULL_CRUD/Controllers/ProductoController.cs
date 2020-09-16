using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using API_RESTFULL_CRUD.Contexts;
using API_RESTFULL_CRUD.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_RESTFULL_CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly AppDbContext context;

        public ProductoController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/<ProductoController>
        [HttpGet]
        public IEnumerable<Producto> Get()
        {
            return context.Producto.Include(p => p.Categoria).ToList();
        }

        // GET api/<ProductoController>/5
        [HttpGet("{id}")]
        public Producto Get(int id)
        {
            var producto = context.Producto.FirstOrDefault(p => p.Id == id);
            return producto;
        }

        // GET api/<ProductoController>/5
        [HttpGet("categoria/{id}")]
        public IEnumerable<Producto> Producto_Categoria_Get(int id)
        {
            var productos = context.Producto.Where(p => p.Categoria_Id == id).ToList();
            return productos;
        }

        // POST api/<ProductoController>
        [HttpPost]
        public ActionResult Post([FromBody] Producto producto)
        {
            try
            {
                context.Producto.Add(producto);
                context.SaveChanges();
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest();
            }
            
        }

        // PUT api/<ProductoController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Producto producto)
        {
            if(producto.Id == id)
            {
                context.Entry(producto).State = EntityState.Modified;
                context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE api/<ProductoController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var producto = context.Producto.FirstOrDefault(p => p.Id == id);
            if(producto != null)
            {
                context.Producto.Remove(producto);
                context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
