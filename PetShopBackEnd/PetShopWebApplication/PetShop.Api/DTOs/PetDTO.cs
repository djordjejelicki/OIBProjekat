using PetShop.Domain.Enums;

namespace PetShop.Api.DTOs
{
    public class PetDTO
    {
        public string LatinName { get; set; }
        public string Name { get; set; }
        public PetType Type { get; set; }
        public decimal Price { get; set; }
    }
}
