using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Producto
    {
        public Producto(int _Id, string _Name, int _Price)
        {
            Id = _Id;
            Name = _Name;
            Price = _Price;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
    }
}
