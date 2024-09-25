using Microsoft.AspNetCore.Mvc;
using Negocio;
using Negocio.Modelos;

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
            try
            {
                var productos = api.GetAll();

                if (productos == null || !productos.Any())
                {
                    return NoContent(); // 204 No Content no hay productos
                }

                return Ok(productos); // 200 OK
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); // Devuelve 400 Bad Request con el mensaje de la excepción
            }
        }

        // GET api/<ValuesController>/products/5
        [HttpGet("products/{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var producto = api.GetById(id);

                if (producto == null)
                {
                    return NotFound(); // 404 Not Found no se encontró el producto con esa ID
                }
                return Ok(producto); // 200 OK
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); // Devuelve 400 Bad Request con el mensaje de la excepción
            }
        }

        // POST api/<ValuesController>/products
        [HttpPost("products")]
        public IActionResult Post([FromBody] Producto producto)
        {
            Producto productoCreado;
            try
            {
                productoCreado = api.Post(producto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return StatusCode(201, productoCreado);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("products/{id}")]
        public IActionResult Put(int id, [FromBody] Producto product)
        {
            try
            {
                product.Id = id;
                var productoActualizado = api.Put(product);
                if (productoActualizado == null)
                {
                    return NotFound(); // 404 Not Found si el producto no existe para actualizar
                }
                return Ok(productoActualizado); // 200 OK si se actualiza correctamente
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); // Devuelve 400 Bad Request con el mensaje de la excepción
            }
        }
        // DELETE api/<ValuesController>/5
        [HttpDelete("products/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var eliminado = api.Delete(id);

                if (eliminado == 0) // Si no se borró nada, eliminado debería ser 0.
                {
                    return NotFound(); // 404 Not Found si el producto no existe para eliminar
                }

                return NoContent(); // 204 No Content si funcionó correctamente
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); // Devuelve 400 Bad Request con el mensaje de la excepción
            }
        }
    }
}
