using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace loyaltytest.Domain.Entities
{
    public class Order
    {
        [Key]
        public long OrderId { get; set; }
        public DateTime OrderDate { get; set; }

        //Relatioship
        public int CustomerId { get; set; }


        //Navigation property
        public Customer Customer { get; set; }
        //public List<Product> Product { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; } = new List<OrderDetails>();

    }
}
