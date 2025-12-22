using PetShop.Application.Interfaces.Services;
using PetShop.Infrastructure.Services.Sales;

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

        public ISalesService? GetCurrentService()
        {
            var now = DateTime.Now.TimeOfDay;

            var dayStart = new TimeSpan(8, 0, 0);
            var dayEnd = new TimeSpan(16, 0, 0);
            var nightEnd = new TimeSpan(22, 0, 0);

            if (now >= dayStart && now < dayEnd)
                return _dayS;

            if (now >= dayEnd && now < nightEnd) 
                return _nightS;

            return null;

            
        }
    }
}
