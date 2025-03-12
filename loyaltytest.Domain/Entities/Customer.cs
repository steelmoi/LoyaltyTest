using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace loyaltytest.Domain.Entities
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        [Required]
        [MaxLength(50)]
        public string CustomerName { get; set; }
        [Required]
        [MaxLength(50)]
        public string CustomerFirstName { get; set; }   
        [MaxLength(50)]
        public string CustomerLastName { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set;}
        [Required]
        public int Status { get; set; } = 1;

        //relationships
        public Order Order { get; set; }
        public Address Address { get; set; }
        //public List<Order> Orders { get; set; }
        public List<Users> Users { get; set; }
    }
}
