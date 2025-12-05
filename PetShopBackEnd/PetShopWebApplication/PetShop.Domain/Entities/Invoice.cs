using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Domain.Entities
{
    public class Invoice
    {
        public Guid Id { get; set; }
        public string? SellerName { get; set; }
        public DateTime DateTime { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
