using PetShop.Application.Interfaces.Repositories;
using PetShop.Application.Interfaces.Services;
using PetShop.Domain.Entities;
using PetShop.Domain.Enums;

namespace PetShop.Infrastructure.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly ILoggerService _loggerService;

        public InvoiceService(IInvoiceRepository invoiceRepository, ILoggerService loggerService)
        {
            _invoiceRepository = invoiceRepository;
            _loggerService = loggerService;
        }
        public Invoice CreateInvoice(User seller, Pet pet, decimal finalPrice)
        {
            var invoice = new Invoice
            {
                Id = Guid.NewGuid(),
                SellerName = seller.Username,
                DateTime = DateTime.Now,
                TotalAmount = finalPrice
            };

            _invoiceRepository.Add(invoice);
            _loggerService.Log(LogLevel.Info, $"Invoice created for pet {pet.Name}, seller: {seller.Username}, total price: {finalPrice}");
            return invoice;
        }

        public IEnumerable<Invoice> GetAll()
        {
            _loggerService.Log(LogLevel.Info, "Invoice list requested.");
            return _invoiceRepository.GetAll();
        }

        public Invoice GetById(Guid id)
        {
            _loggerService.Log(LogLevel.Info, $"Invoice requested: {id}");
            return _invoiceRepository.GetById(id);
        }
    }
}
