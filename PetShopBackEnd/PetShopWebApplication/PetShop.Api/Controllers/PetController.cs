using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetShop.Api.DTOs;
using PetShop.Application.Interfaces.Services;
using PetShop.Domain.Entities;
using LogLevel = PetShop.Domain.Enums.LogLevel;

namespace PetShop.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetController : ControllerBase
    {
        private readonly IPetService _petService;
        private readonly IWebHostEnvironment _env;
        private readonly ILoggerService _logger;
        public PetController(IPetService petService, IWebHostEnvironment env,ILoggerService logger)
        {
            _petService = petService;
            _env = env;
            _logger = logger;
        }

        [HttpPost]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Add([FromForm] CreatePetRequest request)
        {
            _logger.Log(LogLevel.Info, $"Add pet request by: {User.Identity?.Name}");
            try
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
            catch(InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                _logger.Log(LogLevel.Error, $"Server error while trying to add new pet");
                return StatusCode(500, "Unexpected server error while adding pet.");
            }
        }

        [HttpGet("all")]
        [Authorize(Roles = "Manager")]
        public IActionResult GetAll() 
        {
            _logger.Log(LogLevel.Info, $"All pets requested by: {User.Identity?.Name}");
            return Ok(_petService.GetAllPets());
        }

        [HttpGet("available")]
        [Authorize(Roles = "Seller")]
        public IActionResult GetAvailable() 
        {
            _logger.Log(LogLevel.Info, $"Available pets requested by: {User.Identity?.Name}");
            return Ok(_petService.GetAvailblePets());
        }

        [HttpGet("{id}")]
        [Authorize]

        public IActionResult GetById(Guid id)
        {
            _logger.Log(LogLevel.Info, $"Pet requested with id : {id} by: {User.Identity.Name}");
            var pet = _petService.GetById(id);
            if(pet == null)
            {
                _logger.Log(LogLevel.Warning, $"There is no pet with id: {id}");
                return NotFound();
            }
            return Ok(pet);
        }
    }
}
