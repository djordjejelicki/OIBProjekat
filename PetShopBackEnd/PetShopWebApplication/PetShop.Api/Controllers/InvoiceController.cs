using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetShop.Application.Interfaces.Services;

namespace PetShop.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;

        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        [HttpGet("all")]
        [Authorize(Roles = "Manager")]
        public IActionResult GetAll()
        {
            var invoices = _invoiceService.GetAll();
            return Ok(invoices);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Manager")]
        public IActionResult GetById(Guid id)
        {
            var inovoice = _invoiceService.GetById(id);
            return Ok(inovoice);
        }
    }
}
