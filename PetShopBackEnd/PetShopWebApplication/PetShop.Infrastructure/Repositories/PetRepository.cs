using PetShop.Application.Interfaces.Repositories;
using PetShop.Domain.Entities;
using PetShop.Infrastructure.Data;

namespace PetShop.Infrastructure.Repositories
{
    public class PetRepository : IPetRepository
    {
        private readonly PetShopDbContext _context;

        public PetRepository(PetShopDbContext context)
        {
            _context = context;
        }
        public void Add(Pet pet)
        {
            _context.Pets.Add(pet);
            _context.SaveChanges();
        }

        public IEnumerable<Pet> GetAll()
        {
            return _context.Pets.ToList();
        }

        public Pet? GetById(Guid id)
        {
            return _context.Pets.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Pet> GetUnsoldPets()
        {
            return _context.Pets.Where(p => !p.Sold).ToList();
        }

        public void Update(Pet pet)
        {
            _context.Pets.Update(pet);
            _context.SaveChanges();
        }
    }
}
