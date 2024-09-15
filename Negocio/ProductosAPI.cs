using RestSharp;
namespace Negocio
{
    public class ProductosAPI
    {
        List<Producto> listaProductos = new List<Producto>();

        public List<Producto> GetAll() {

            return Datos.listaProductos.OrderBy(item => item.Id).ToList();
        }
        public Producto Post(Producto producto)
        {
            Datos.listaProductos.Add(producto);
            return producto;
        }

        public Producto GetById(int id)
        {
            return Datos.listaProductos.Where(item => item.Id == id).First();
        }
        public void Update(Producto producto) { }
        public int Delete(int id)
        {
            return Datos.listaProductos.RemoveAll(item => item.Id == id);
        }
        public Producto Put(Producto prod)
        {
            var product = Datos.listaProductos.Where(item => item.Id == prod.Id).First();
            Datos.listaProductos.Remove(product);
            Datos.listaProductos.Add(prod);
            return product;
        }
    }
}