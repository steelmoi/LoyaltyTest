using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace loyaltytest.Domain.Entities
{
    public class Address
    {
        [Key]
        public long AddressId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Street { get; set; }
        [MaxLength(20)]
        public string NumExt {  get; set; }
        [MaxLength(20)]
        public string NumInt { get; set; }
        [Required]
        [MaxLength(50)]
        public string Colony { get; set; }
        [Required]
        [MaxLength(50)]
        public string City { get; set; }
        [Required]
        [MaxLength(50)]
        public string State { get; set; }
        [Required]
        [MaxLength(10)]
        public string PostalCode { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        [Required]
        public DateTime UpdatedDate { get; set; }
        [Required]
        public int Status { get; set; } = 1;

        //Relationship
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
