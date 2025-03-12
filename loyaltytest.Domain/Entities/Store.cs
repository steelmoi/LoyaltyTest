using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace loyaltytest.Domain.Entities
{
    public class Store
    {
        [Key]
        public int StoreId { get; set; }
        [Required]
        [MaxLength(5)]
        public string StoreCode { get; set; }
        [Required]
        [MaxLength(50)]
        public string StoreName { get; set; }
        [Required]
        public int Status { get; set; } = 1;
        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; }        

        //RelationShip
        public ICollection<Product> Products{ get; set; }
        public AddressStore AddressStore { get; set; }
    }
}
