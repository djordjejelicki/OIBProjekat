using PetShop.Application.Interfaces.Repositories;
using PetShop.Domain.Entities;
using PetShop.Infrastructure.Data;

namespace PetShop.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly PetShopDbContext _context;

        public UserRepository(PetShopDbContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User? GetById(Guid id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }

        public User? GetByUsername(string username)
        {
            return _context.Users.FirstOrDefault(u => u.Username == username);
        }
    }
}
