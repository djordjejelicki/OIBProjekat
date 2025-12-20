using PetShop.Domain.Entities;

namespace PetShop.Application.Interfaces.Services
{
    public interface ISellPetService
    {
        Invoice SellPet(Guid petId, User seller);
    }
}
