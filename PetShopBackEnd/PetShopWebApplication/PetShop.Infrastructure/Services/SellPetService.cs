using PetShop.Application.Interfaces.Repositories;
using PetShop.Application.Interfaces.Services;
using PetShop.Domain.Entities;
using PetShop.Domain.Enums;

namespace PetShop.Infrastructure.Services
{
    public class SellPetService : ISellPetService
    {
        private readonly IPetRepository _petRepository;
        private readonly IInvoiceService _invoiceService;
        private readonly SalesSelectorService _salesSelectorService;
        private readonly ILoggerService _logger;

        public SellPetService(IPetRepository petRepository, IInvoiceService invoiceService, SalesSelectorService salesSelectorService, ILoggerService logger)
        {
            _petRepository = petRepository;
            _invoiceService = invoiceService;
            _salesSelectorService = salesSelectorService;
            _logger = logger;
        }

        public Invoice SellPet(Guid petId, User seller)
        {
            var pet = _petRepository.GetById(petId);
            if (pet == null)
            {
                _logger.Log(LogLevel.Error, $"Attempt to sell non-existing pet. PetId: {petId}");
                throw new InvalidOperationException("Pet not found.");
            }

            if (pet.Sold)
            {
                _logger.Log(LogLevel.Warning, $"Attempt to resell pet {pet.Name} which is already sold.");
                throw new InvalidOperationException("Pet is already sold.");
            }

            var salesService = _salesSelectorService.GetCurrentService();
            var finalAmount = salesService.ApplyPriceModifier((decimal)pet.Price);

            pet.Sold = true;
            _petRepository.Update(pet);

            var invoice = _invoiceService.CreateInvoice(seller, pet, finalAmount);
            _logger.Log(LogLevel.Info, $"Pet sold: {pet.Name} by {seller.Username}. Final price: {finalAmount}");
            return invoice;

        }
    }
}
