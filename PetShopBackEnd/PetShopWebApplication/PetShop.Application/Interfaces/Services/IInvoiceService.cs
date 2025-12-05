using PetShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Application.Interfaces.Services
{
    public interface IInvoiceService
    {
        Invoice CreateInvoice(User seller, Pet pet, decimal finalPrice);
        IEnumerable<Invoice> GetAll();
        Invoice GetById(Guid id);
    }
}
