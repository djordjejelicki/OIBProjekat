using PetShop.Application.Interfaces.Services;
using PetShop.Infrastructure.Services.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Infrastructure.Services
{
    public class SalesSelectorService
    {
        private readonly DaySalesService _dayS;
        private readonly NightSalesService _nightS;

        public SalesSelectorService( DaySalesService dayS, NightSalesService nightS)
        {
            _dayS = dayS;
            _nightS = nightS;
        }

        public ISalesService GetCurrentService()
        {
            var now = DateTime.Now.TimeOfDay;

            var dayStart = new TimeSpan(8, 0, 0);
            var dayEnd = new TimeSpan(16, 0, 0);

            if (now >= dayStart && now < dayEnd)
                return _dayS;

            return _nightS;

            
        }
    }
}
