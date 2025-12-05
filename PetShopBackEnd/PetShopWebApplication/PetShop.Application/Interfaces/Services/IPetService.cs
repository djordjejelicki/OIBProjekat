using PetShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Application.Interfaces.Services
{
    public interface IPetService
    {
        IEnumerable<Pet> GetAllPets();
        IEnumerable<Pet> GetAvailblePets();
        void AddPet(Pet pet);
    }
}
