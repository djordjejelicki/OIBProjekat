using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetShop.Api.DTOs;
using PetShop.Application.Interfaces.Services;
using PetShop.Domain.Entities;
using PetShop.Domain.Enums;

namespace PetShop.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetController : ControllerBase
    {
        private readonly IPetService _petService;
        private readonly IWebHostEnvironment _env;
        public PetController(IPetService petService, IWebHostEnvironment env)
        {
            _petService = petService;
            _env = env;
        }

        [HttpPost]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Add([FromForm] CreatePetRequest request)
        {
            var pet = new Pet
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                LatinName = request.LatinName,
                Price = request.Price,
                Sold = false,
                Type = request.Type,
                ImageUrl = "/images/default.png"
            };

            if(request.Image != null && request.Image.Length > 0)
            {
                var extension = Path.GetExtension(request.Image.FileName).ToLower();
                var fileName = $"{pet.Id}{extension}";
                var imagePath = Path.Combine(_env.WebRootPath, "images", "pets", fileName);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    await request.Image.CopyToAsync(stream);
                }

                pet.ImageUrl = $"/images/pets/{fileName}";
            }

            _petService.AddPet(pet);
            return Ok("Pet added successfully");
        }

        [HttpGet("all")]
        [Authorize(Roles = "Manager")]
        public IActionResult GetAll() 
        {
            return Ok(_petService.GetAllPets());
        }

        [HttpGet("available")]
        [Authorize(Roles = "Seller")]
        public IActionResult GetAvailable() 
        {
            return Ok(_petService.GetAvailblePets());
        }

        [HttpGet("{id}")]
        [Authorize]

        public IActionResult GetById(Guid id)
        {
            var pet = _petService.GetById(id);
            if(pet == null)
            {
                return NotFound();
            }
            return Ok(pet);
        }
    }
}
