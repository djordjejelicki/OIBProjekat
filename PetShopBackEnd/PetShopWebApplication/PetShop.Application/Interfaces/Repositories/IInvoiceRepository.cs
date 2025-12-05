using PetShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Application.Interfaces.Repositories
{
    public interface IInvoiceRepository
    {
        void Add(Invoice invoice);
        IEnumerable<Invoice> GetAll();
        Invoice GetById(Guid id);
    }
}
