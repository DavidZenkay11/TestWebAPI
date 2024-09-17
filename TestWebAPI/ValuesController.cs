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
                return NoContent(); // 204 No Content no hay productos
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
                return NotFound(); // 404 Not Found no se encontró el producto con esa ID
            }

            return Ok(producto); // 200 OK
        }

        // POST api/<ValuesController>/products
        [HttpPost("products")]
        public IActionResult Post([FromBody] Producto producto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Devuelve 400 Bad Request.
            }

            var productoCreado = api.Post(producto);
            return StatusCode(201, productoCreado);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("products/{id}")]
        public IActionResult Put(int id, [FromBody] Producto product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Devuelve 400 Bad Request.
            }
            product.Id = id;

            var productoActualizado = api.Put(product);

            if (productoActualizado == null)
            {
                return NotFound(); // 404 Not Found el producto no existe para actualizar
            } else { return Ok(productoActualizado); }


        }
        // DELETE api/<ValuesController>/5
        [HttpDelete("products/{id}")]
        public IActionResult Delete(int id)
        {
            var eliminado = api.Delete(id);

            if (eliminado == 0) //Si no borró nada eliminado debería dar 0 dando el 404.
            {
                return NotFound(); // 404 Not Found el producto no existe para eliminar
            }

            return NoContent(); // 204 No Content si funcionó correctamente
        }
    }
}
