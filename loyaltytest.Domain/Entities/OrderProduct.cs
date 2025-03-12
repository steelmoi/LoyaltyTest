using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace loyaltytest.Domain.Entities
{
    public class OrderProduct
    {
        [Key]
        public long OrderProductId { get; set; }

        public long ProductId { get; set; }
        public Product Product { get; set; }

        public long OrderId { get; set; }
        public Order Order { get; set; }

        public DateTime Date { get; set; }
        public int Quantity { get; set; }
    }
}
