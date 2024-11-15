using Dapper;
using MySql.Data.MySqlClient;
using Negocio.Modelos;
using RestSharp;
namespace Negocio
{
    public class ProductosAPI
    {

        string connstring = "Server=db4free.net;Database=lasnieves110424;Uid=lasnieves110424;Pwd=lasnieves110424;";
        public List<Producto> GetAll() {
            List<Producto> ListaProductos = new List<Producto>();
            MySqlConnection conn = new MySqlConnection(connstring);

            conn.Open();

            string sql = "SELECT Id,Description,Title,Price FROM Products";
            ListaProductos = conn.Query<Producto>(sql).ToList();


            return ListaProductos;
        }
        public Producto Post(Producto producto)
        {
            using (MySqlConnection connection = new MySqlConnection(connstring))
            {
                connection.Open();

                string sql = "INSERT INTO Products (Title, Description, Category, Price) VALUES (@Title, @Description, @Category, @Price)";

              
                int resultado = connection.Execute(sql, new
                {
                    Title = producto.Title,
                    Description = producto.Description,
                    Category = producto.Category,
                    Price = producto.Price
                });

                return producto;
            }
        }
        public Producto GetById(int _id)
        {
            MySqlConnection connection = new MySqlConnection(connstring);

            connection.Open();
            string sql = "SELECT Id,Description,Title,Price FROM Products where id = @id";
            Producto producto = connection.QueryFirst<Producto>(sql, new { id = _id });

            return producto;
        }

        public int Delete(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(connstring))
            {
                connection.Open();
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "DELETE FROM Products WHERE Id = @id";
                cmd.Parameters.AddWithValue("@id", id);

                int resultado = cmd.ExecuteNonQuery();
                return resultado;
            }
        }

        public Producto Put(Producto producto)
        {
            using (MySqlConnection connection = new MySqlConnection(connstring))
            {
                connection.Open();

                string sql = "UPDATE Products SET Title = @Title, Description = @Description, Category = @Category, Price = @Price WHERE Id = @Id";

                int filasAfectadas = connection.Execute(sql, new
                {
                    Title = producto.Title,
                    Description = producto.Description,
                    Category = producto.Category,
                    Price = producto.Price
                });

                if (filasAfectadas > 0)
                {
                    return producto; 
                }
                else
                {
                    return null; 
                }
            }
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