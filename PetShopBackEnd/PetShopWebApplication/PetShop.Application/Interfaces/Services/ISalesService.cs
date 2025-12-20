namespace PetShop.Application.Interfaces.Services
{
    public interface ISalesService
    {
        decimal ApplyPriceModifier(decimal basePrice);
    }
}
