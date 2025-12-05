using PetShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Application.Interfaces.Repositories
{
    public interface IUserRepository
    {
        User? GetByUsername(string username);
        User? GetById(Guid id);
        IEnumerable<User> GetAll();
    }
}
