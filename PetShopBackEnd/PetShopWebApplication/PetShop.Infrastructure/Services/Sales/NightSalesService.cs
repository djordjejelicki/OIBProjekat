using PetShop.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Infrastructure.Services.Sales
{
    public class NightSalesService : ISalesService
    {
        public decimal ApplyPriceModifier(decimal basePrice)
        {
            return basePrice * 1.10m; ;
        }
    }
}
