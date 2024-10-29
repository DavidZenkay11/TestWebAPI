using Dapper;
using MySql.Data.MySqlClient;
using Negocio.Modelos;
using RestSharp;
namespace Negocio
{
    public class ProductosAPI
    {

        string connstring = "Server=sql10.freemysqlhosting.net;Database=sql10741376;Uid=sql10741376;Pwd=vqRiz5UenI;";
        public List<Producto> GetAll() {
            List<Producto> ListaProductos = new List<Producto>();
            MySqlConnection conn = new MySqlConnection(connstring);

            conn.Open();
            // MySqlCommand cmd = conn.CreateCommand();
            string sql = "SELECT Id,Description,Title,Price FROM Products";
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
            using (MySqlConnection connection = new MySqlConnection(connstring))
            {
                connection.Open();
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = $"INSERT INTO Productos ('Description','Title') VALUES (\"{""}\",\"{producto.Title}\")";
                int resultado = cmd.ExecuteNonQuery();
            }
            /*producto.Id = Datos.listaProductos.Count +1;
            Datos.listaProductos.Add(producto);*/
            return producto;
        }

        public Producto GetById(int _id)
        {
            MySqlConnection conn = new MySqlConnection(connstring);

            conn.Open();
            string sql = "SELECT Id,Description,Title,Price FROM Products where id = @id";
            Producto producto = conn.QueryFirst<Producto>(sql, new { id = _id });

            return producto;
        }

        public int Delete(int id)
        {
            return Datos.listaProductos.RemoveAll(item => item.Id == id);
        }
        public Producto Put(Producto producto)
        {
            MySqlConnection connection = new MySqlConnection(connstring);
            connection.Open();
            string sql = "update Products set 'price' = @price where id = @id";
            int insertados = connection.Execute(sql, new { price = producto.Price, name = producto.Id });
            return producto;
            /*var product = Datos.listaProductos.FirstOrDefault(item => item.Id == prod.Id);
            if (product == null)
            {
                return new Producto(-1, "", "", 0); 
            }
            Datos.listaProductos.Remove(product);
            Datos.listaProductos.Add(prod);
            return prod;*/
        }
        public List<string> GetAllCategories()
        {
            List<string> listaProductos = new List<string>();
            using (MySqlConnection connection = new MySqlConnection(connstring))
            {
                connection.Open();
                string sql = "SELECT Category FROM Categories";
                listaProductos = connection.Query<string>(sql).ToList();
                return listaProductos;
            }
        }
    }

}