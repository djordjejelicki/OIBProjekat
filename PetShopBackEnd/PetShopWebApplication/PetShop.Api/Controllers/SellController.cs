using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetShop.Domain.Entities;
using PetShop.Domain.Enums;
using PetShop.Infrastructure.Services;
using System.Security.Claims;

namespace PetShop.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SellController : ControllerBase
    {
      private readonly SellPetService _sellPetService;
        public SellController(SellPetService salePetService) 
        {
            _sellPetService = salePetService;
        }

        [HttpPost("{petId}")]
        [Authorize(Roles = "Seller")]
        public IActionResult Sell(Guid petId)
        {
            var sellerId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var username = User.FindFirstValue(ClaimTypes.Name);
          

            var seller = new User
            {
                Id = sellerId,
                Username = username,
                Role = RoleType.Seller
            };

            var invoice = _sellPetService.SellPet(petId, seller);
            return Ok(invoice);
        }
    }
}
