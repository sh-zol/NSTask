using Domain.Core.User.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core.Products.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public DateTime ProduceDate { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public int ManufacturerId { get; set; }
        public string ManufacturerEmail { get; set; }
        public string ManufacturerPhoneNumber { get; set; }
    }
}
