using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Modelos
{
    public class Producto
    {
        public Producto() { }
        public Producto(int id, string title, string description,string category, decimal price)
        {
            Id = id;
            Title = title;
            Description = description;
            Category = category;
            Price = price;
        }

        [Range(1, int.MaxValue, ErrorMessage = "El Id debe ser un número mayor que cero.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string Title { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "El Precio debe ser un número mayor que cero.")]
        public decimal Price { get; set; }
    }

}
