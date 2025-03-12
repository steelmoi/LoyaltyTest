using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace loyaltytest.Domain.dtos.Request
{
    public class AddressRequest
    {
        public long AddressId { get; set; }
        public string Street { get; set; }
        public string NumExt { get; set; }
        public string NumInt { get; set; }
        public string Colony { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; }
        public int Status { get; set; } = 1;
        public long RelationShipId { get; set; }
    }
}
