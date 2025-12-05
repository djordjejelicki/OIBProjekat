using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetShop.Api.DTOs;
using PetShop.Application.Interfaces.Services;
using PetShop.Domain.Entities;

namespace PetShop.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetController : ControllerBase
    {
        private readonly IPetService _petService;
        public PetController(IPetService petService)
        {
            _petService = petService;
        }

        [HttpPost]
        [Authorize(Roles = "Manager")]
        public IActionResult Add(PetDTO dto)
        {
            var pet = new Pet
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                LatinName = dto.LatinName,
                Price = dto.Price,
                Sold = false,
                Type = dto.Type
            };

            _petService.AddPet(pet);
            return Ok("Pet added successfully");
        }

        [HttpGet]
        [Authorize(Roles = "Manager")]
        public IActionResult GetAll() 
        {
            return Ok(_petService.GetAllPets());
        }

        [HttpGet("avilable")]
        [Authorize(Roles = "Seller")]
        public IActionResult GetAvailable() 
        {
            return Ok(_petService.GetAvailblePets());
        }
    }
}
