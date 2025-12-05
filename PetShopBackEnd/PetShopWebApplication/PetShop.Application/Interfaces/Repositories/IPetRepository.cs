using PetShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Application.Interfaces.Repositories
{
    public interface IPetRepository
    {
        IEnumerable<Pet> GetAll();
        IEnumerable<Pet> GetUnsoldPets();
        Pet? GetById(Guid id);
        void Add(Pet pet);
        void Update(Pet pet);
    }
}
