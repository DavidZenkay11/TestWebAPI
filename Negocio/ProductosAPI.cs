using Negocio.Modelos;
using RestSharp;
namespace Negocio
{
    public class ProductosAPI
    {


        public List<Producto> GetAll() {

            return Datos.listaProductos.OrderBy(item => item.Id).ToList();
        }
        public Producto Post(Producto producto)
        {
            producto.Id = Datos.listaProductos.Count +1;
            Datos.listaProductos.Add(producto);
            return producto;
        }

        public Producto GetById(int id)
        {
            // Busca el producto por id, si no lo encuentra devuelve null
            var producto = Datos.listaProductos.FirstOrDefault(item => item.Id == id);

            return producto;
        }
        public void Update(Producto producto) { }
        public int Delete(int id)
        {
            return Datos.listaProductos.RemoveAll(item => item.Id == id);
        }
        public Producto Put(Producto prod)
        {
            var product = Datos.listaProductos.FirstOrDefault(item => item.Id == prod.Id);
            if (product == null)
            {
                return new Producto(-1, "", 0); 
            }
            Datos.listaProductos.Remove(product);
            Datos.listaProductos.Add(prod);
            return prod;
        }
    }
}