using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Negocio.Modelos;

namespace Negocio
{
    public class Datos
    {
        static public List<Producto> listaProductos = new List<Producto>() { new Producto(1, "Pelota", 200), new Producto(2, "Camiseta", 250), new Producto(3, "Arco", 300) };

    }
}
