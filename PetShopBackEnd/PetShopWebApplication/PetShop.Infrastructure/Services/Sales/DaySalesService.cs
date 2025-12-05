using PetShop.Application.Interfaces.Services;

namespace PetShop.Infrastructure.Services.Sales
{
    public class DaySalesService : ISalesService
    {
        public decimal ApplyPriceModifier(decimal basePrice)
        {
            return basePrice * 0.85m;
        }
    }
}
