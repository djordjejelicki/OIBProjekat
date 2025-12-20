using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetShop.Application.Interfaces.Services;
using LogLevel = PetShop.Domain.Enums.LogLevel;

namespace PetShop.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;
        private readonly ILoggerService _logger;

        public InvoiceController(IInvoiceService invoiceService, ILoggerService logger)
        {
            _invoiceService = invoiceService;
            _logger = logger;
        }

        [HttpGet("all")]
        [Authorize(Roles = "Manager")]
        public IActionResult GetAll()
        {
            _logger.Log(LogLevel.Info,$"Invoice list requested by: {User.Identity?.Name}");
            var invoices = _invoiceService.GetAll();
            return Ok(invoices);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Manager")]
        public IActionResult GetById(Guid id)
        {
            _logger.Log(LogLevel.Info, $"Invoice requested with id: {id}, by: {User.Identity?.Name}");
            var invoice = _invoiceService.GetById(id);
            if (invoice == null) 
            {
                _logger.Log(LogLevel.Warning, $"There is no invoice with id: {id}");
                return NotFound();
            }
            return Ok(invoice);
        }
    }
}
