using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace loyaltytest.Domain.Entities
{
    public class ProductStore
    {
        public long ProductsProductId { get; set; }
        public int StoresStoreId { get; set; }
    }
}
