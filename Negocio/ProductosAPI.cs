using Dapper;
using MySql.Data.MySqlClient;
using Negocio.Modelos;
using RestSharp;
namespace Negocio
{
    public class ProductosAPI
    {

        string connstring = "Server=sql10.freemysqlhosting.net;Database=sql10739703;Uid=sql10739703;Pwd=d4q6qAjJg6;";
        public List<Producto> GetAll() {
            List<Producto> ListaProductos = new List<Producto>();
            MySqlConnection conn = new MySqlConnection(connstring);

            conn.Open();
           // MySqlCommand cmd = conn.CreateCommand();
            string sql = "SELECT Id,Description,Name,Price FROM Products";
            ListaProductos = conn.Query<Producto>(sql).ToList();
           /* while (reader.Read()) 
            {
                int id = reader.GetInt32("id");
                string name = reader.GetString("name");
                string description = reader.GetString("description");
                decimal price = reader.GetDecimal("price");
                Producto p = new Producto(id, name, description, 0);
                ListaProductos.Add(p);
            }*/

            return ListaProductos;
        }
        public Producto Post(Producto producto)
        {
            producto.Id = Datos.listaProductos.Count +1;
            Datos.listaProductos.Add(producto);
            return producto;
        }

        public Producto GetById(int _id)
        {
            MySqlConnection conn = new MySqlConnection(connstring);

            conn.Open();
            string sql = "SELECT Id,Description,Name,Price FROM Products where id = @id";
            Producto producto = conn.QueryFirst<Producto>(sql, new {id = _id});

            return producto;
        }

        public int Delete(int id)
        {
            return Datos.listaProductos.RemoveAll(item => item.Id == id);
        }
        public Producto Put(Producto prod)
        {
            var product = Datos.listaProductos.FirstOrDefault(item => item.Id == prod.Id);
            if (product == null)
            {
                return new Producto(-1, "", "", 0); 
            }
            Datos.listaProductos.Remove(product);
            Datos.listaProductos.Add(prod);
            return prod;
        }
    }
}