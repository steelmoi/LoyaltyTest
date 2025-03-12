using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace loyaltytest.Domain.dtos.Request
{
    public class CustomerRequest
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; }
        public int Status { get; set; } = 1;
    }
}
