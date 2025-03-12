using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace loyaltytest.Domain.Entities
{
    public class Product
    {
        [Key]
        public long ProductId { get; set; }
        [Required, MaxLength(100)]
        public string SKUProduct { get; set; }
        [Required, MaxLength(200)]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required, MaxLength(250)]
        public string Image { get; set; }
        public int Stock {  get; set; }
        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; }
        public int Status { get; set; } = 1;

        // Navigation property
        public List<Store> Stores { get; set; }
        //public List<Order> Orders { get; set; }
        public List<OrderDetails> OrderDetails { get; set; }
    }
}
