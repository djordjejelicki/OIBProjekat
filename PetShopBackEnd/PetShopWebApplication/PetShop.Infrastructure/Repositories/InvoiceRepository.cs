using PetShop.Application.Interfaces.Repositories;
using PetShop.Domain.Entities;
using PetShop.Infrastructure.Data;

namespace PetShop.Infrastructure.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly PetShopDbContext _context;

        public InvoiceRepository(PetShopDbContext context)
        {
            _context = context;
        }
        public void Add(Invoice invoice)
        {
            _context.Invoices.Add(invoice);
            _context.SaveChanges();
        }

        public IEnumerable<Invoice> GetAll()
        {
           return _context.Invoices.ToList();
        }

       
    }
}
