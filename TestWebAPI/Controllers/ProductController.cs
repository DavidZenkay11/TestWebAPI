using Microsoft.AspNetCore.Mvc;
using Negocio;
using Negocio.Modelos;


namespace TestWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        ProductosAPI api = new ProductosAPI();

        // GET: api/<ProductController>/products
        [HttpGet("products")]
        public IActionResult Get()
        {
            try
            {
                var productos = api.GetAll();

                if (productos == null || !productos.Any())
                {
                    return NotFound(new { Message = "No se encontraron productos." }); 
                }

                return Ok(productos); 
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Hubo un error al obtener los productos.", Error = ex.Message }); 
            }
        }

        // GET api/<ProductController>/products/5
        [HttpGet("products/{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var producto = api.GetById(id);

                if (producto == null)
                {
                    return NotFound(new { Message = "Producto no encontrado." }); 
                }
                return Ok(producto); 
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Hubo un error al obtener el producto.", Error = ex.Message }); 
            }
        }

        // POST api/<ProductController>/products
        [HttpPost("products")]
        public IActionResult Post([FromBody] Producto producto)
        {
            Producto productoCreado;
            try
            {
                productoCreado = api.Post(producto);

                if (productoCreado == null)
                {
                    return BadRequest(new { Message = "No se pudo crear el producto." }); 
                }

                return StatusCode(201, productoCreado); 
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "Hubo un error al crear el producto.", Error = ex.Message }); 
            }
        }

        // PUT api/<ProductController>/5
        [HttpPut("products/{id}")]
        public IActionResult Put(int id, [FromBody] Producto producto)
        {
            try
            {
                producto.Id = id;
                var productoActualizado = api.Put(producto);

                if (productoActualizado == null)
                {
                    return NotFound(new { Message = "Producto no encontrado." }); 
                }

                return Ok(productoActualizado); 
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "Hubo un error al actualizar el producto.", Error = ex.Message }); 
            }
        }
        // DELETE api/<ProductController>/5
        [HttpDelete("products/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var eliminado = api.Delete(id);

                if (eliminado == 0)
                {
                    return NotFound(new { Message = "Producto no encontrado para eliminar." }); 
                }

                return NoContent(); 
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "Hubo un error al eliminar el producto.", Error = ex.Message }); 
            }
        }

        [HttpGet("categories")]
        public IActionResult GetCategories()
        {
            try
            {
                ProductosAPI productosAPI = new ProductosAPI();
                var categorias = productosAPI.GetAllCategories();

                if (categorias == null || !categorias.Any())
                {
                    return NotFound(new { Message = "No se encontraron categorías." });
                }

                return Ok(categorias); 
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "Hubo un error al obtener las categorías.", Error = ex.Message });
            }
        }
    }
}
