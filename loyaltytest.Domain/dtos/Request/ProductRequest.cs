using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace loyaltytest.Domain.dtos.Request
{
    public class ProductRequest
    {
        public long ProductId { get; set; }
        public string SKUProduct { get; set; }        
        public string Description { get; set; }
        public decimal Price { get; set; }       
        public string Image { get; set; } = string.Empty;
        public int Stock { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; }
        public int Status { get; set; } = 1;
    }
}
