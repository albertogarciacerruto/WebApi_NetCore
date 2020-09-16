using System;
using System.Collections.Generic;
using System.Linq;
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
    public class CategoriaController : ControllerBase
    {
        private readonly AppDbContext context;

        public CategoriaController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/<CategoriaController>
        [HttpGet]
        public IEnumerable<Categoria> Get()
        {
            return context.Categoria.ToList().AsQueryable();
        }

        // GET api/<CategoriaController>/5
        [HttpGet("{id}")]
        public Categoria Get(int id)
        {
            var categoria = context.Categoria.Where(o => o.Id == id).FirstOrDefault();
            return categoria;
        }

        // POST api/<CategoriaController>
        [HttpPost]
        public ActionResult Post([FromBody] Categoria categoria)
        {
            try
            {
                context.Categoria.Add(categoria);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // PUT api/<CategoriaController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Categoria categoria)
        {
            if (categoria.Id == id)
            {
                context.Entry(categoria).State = EntityState.Modified;
                context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE api/<CategoriaController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var categoria = context.Categoria.FirstOrDefault(p => p.Id == id);
            if (categoria != null)
            {
                context.Categoria.Remove(categoria);
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
