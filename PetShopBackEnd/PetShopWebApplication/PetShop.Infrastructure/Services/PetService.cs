using PetShop.Application.Interfaces.Repositories;
using PetShop.Application.Interfaces.Services;
using PetShop.Domain.Entities;
using PetShop.Domain.Enums;

namespace PetShop.Infrastructure.Services
{
    public class PetService : IPetService
    {
        private readonly IPetRepository _petRepository;
        private readonly ILoggerService _loggerService;
        public PetService(IPetRepository petRepository, ILoggerService loggerService)
        {
            _petRepository = petRepository;
            _loggerService = loggerService;
        }
        public void AddPet(Pet pet)
        {
            var total = _petRepository.GetUnsoldPets().Count();
            if (total >= 10)
            {
                _loggerService.Log(LogLevel.Warning, "Attempt to add pet when store already has 10 pets.");
                throw new InvalidOperationException("Max 10 pets allowed in shop.");
            }

            _petRepository.Add(pet);
            _loggerService.Log(LogLevel.Info, $"Pet added successfully: {pet.Name} ({pet.Type})");
        }

        public IEnumerable<Pet> GetAllPets()
        {            
            return _petRepository.GetAll();
        }

        public IEnumerable<Pet> GetAvailblePets()
        {
            return _petRepository.GetUnsoldPets();
        }

        public Pet GetById(Guid id)
        {
            return _petRepository.GetById(id);
        }
    }
}
