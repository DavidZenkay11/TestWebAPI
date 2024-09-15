using Microsoft.AspNetCore.Mvc;
using Negocio;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestWebAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        ProductosAPI api = new ProductosAPI();

        // GET: api/<ValuesController>/products
        [HttpGet("products")]
        public List<Producto> Get()
        {
            return api.GetAll();
        }

        // GET api/<ValuesController>/products/5
        [HttpGet("products/{id}")]
        public Producto Get(int id)
        {
            return api.GetById(id);
        }

        // POST api/<ValuesController>/products
        [HttpPost("products")]
        public Producto Post([FromBody] Producto producto)
        {
            return api.Post(producto);
        }

        // PUT api/<ValuesController>/5
        [HttpPut]
        public Producto Put([FromBody] Producto product)
        {
            return api.Put(product);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            api.Delete(id);
        }
    }
}
