using Domain.Core.Products.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core.User.Entities
{
    public class Manufacturer:Person
    {
        public Manufacturer()
        {
            Role = Enums.Role.Manufacturer;
            Products = new List<Product>();
        }

        public List<Product>? Products { get; set; }
    }
}
