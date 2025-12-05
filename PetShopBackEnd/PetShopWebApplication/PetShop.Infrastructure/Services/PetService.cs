using PetShop.Application.Interfaces.Repositories;
using PetShop.Application.Interfaces.Services;
using PetShop.Domain.Entities;

namespace PetShop.Infrastructure.Services
{
    public class PetService : IPetService
    {
        private readonly IPetRepository _petRepository;

        public PetService(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }
        public void AddPet(Pet pet)
        {
            var total = _petRepository.GetUnsoldPets().Count();
            if (total >= 10)
                throw new Exception("Max 10 pets allowed in shop.");

            _petRepository.Add(pet);
        }

        public IEnumerable<Pet> GetAllPets()
        {
            return _petRepository.GetAll();
        }

        public IEnumerable<Pet> GetAvailblePets()
        {
            return _petRepository.GetUnsoldPets();
        }
    }
}
