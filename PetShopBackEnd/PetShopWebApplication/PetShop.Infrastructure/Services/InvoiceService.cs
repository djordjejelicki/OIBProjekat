using PetShop.Application.Interfaces.Repositories;
using PetShop.Application.Interfaces.Services;
using PetShop.Domain.Entities;
using PetShop.Infrastructure.Repositories;

namespace PetShop.Infrastructure.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository _invoiceRepository;

        public InvoiceService(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
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
            return invoice;
        }

        public IEnumerable<Invoice> GetAll()
        {
            return _invoiceRepository.GetAll();
        }
    }
}
