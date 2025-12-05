using PetShop.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Domain.Entities
{
    public class Pet
    {
        public Guid Id { get; set; }
        public string? LatinName { get; set; }
        public string? Name { get; set; }
        public PetType Type { get; set; }
        public decimal? Price { get; set; }
        public bool Sold { get; set; }
    }
}
