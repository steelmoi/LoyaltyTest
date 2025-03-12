using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace loyaltytest.Domain.Entities
{
    public class OrderDetails
    {
        public int Id { get; set; }
        public int OrderId { get; set; } // Foreign key property
        public string Name { get; set; }
        public string Quantity { get; set; }
        public Order Order { get; set; } // Navigation property

        public List<Product> Products { get; set; }
    }
}
