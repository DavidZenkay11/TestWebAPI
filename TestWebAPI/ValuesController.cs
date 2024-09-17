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
        public IActionResult Get()
        {
            var productos = api.GetAll();

            if (productos == null || !productos.Any())
            {
                return NoContent(); // 204 No Content
            }

            return Ok(productos); // 200 OK
        }

        // GET api/<ValuesController>/products/5
        [HttpGet("products/{id}")]
        public IActionResult Get(int id)
        {
            var producto = api.GetById(id);

            if (producto == null)
            {
                return NotFound(); // 404 Not Found
            }

            return Ok(producto); // 200 OK
        }

        // POST api/<ValuesController>/products
        [HttpPost("products")]
        public IActionResult Post([FromBody] Producto producto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var productoCreado = api.Post(producto);
            return StatusCode(201, productoCreado);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("products")]
        public IActionResult Put([FromBody] Producto product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var productoActualizado = api.Put(product);
            return Ok(productoActualizado);
        }
        // DELETE api/<ValuesController>/5
        [HttpDelete("products/{id}")]
        public IActionResult Delete(int id)
        {
            api.Delete(id);
            return NoContent(); // 204 No Content
        }
    }
}
