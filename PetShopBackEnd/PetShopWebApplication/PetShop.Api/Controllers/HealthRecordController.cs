using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetShop.Api.DTOs;
using PetShop.Application.Interfaces.Services;
using PetShop.Domain.Entities;
using LogLevel = PetShop.Domain.Enums.LogLevel;


namespace PetShop.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HealthRecordController : ControllerBase
    {
        private readonly IHealthRecordService _healthRecordService;
        private readonly ILoggerService _logger;

        public HealthRecordController(IHealthRecordService healthRecordService, ILoggerService logger)
        {
            _healthRecordService = healthRecordService;
            _logger = logger;
        }

        [HttpGet("{petId}")]
        public IActionResult GetByPetId(Guid petId) 
        {
            _logger.Log(LogLevel.Info, $"Health record GET request for pet {petId}");
            return Ok(_healthRecordService.GetRecords(petId));
        }

        [HttpPost]
        [Authorize(Roles = "Manager")]
        public IActionResult Add(AddHealthRecordDTO dto)
        {
            try
            {
                var record = new HealthRecord
                {
                    Id = Guid.NewGuid(),
                    PetId = dto.PetId,
                    Date = dto.Date,
                    RecordType = dto.RecordType,
                    Description = dto.Description,
                    Notes = dto.Notes,
                    RecordedBy = User.Identity?.Name ?? "Uknown"
                };

                _logger.Log(LogLevel.Info,
                            $"New health record submission for PetId={record.PetId} by {record.RecordedBy}");

                _healthRecordService.AddRecord(record);
                return Ok("Health record added");
            }
            catch (Exception ex) 
            {
                _logger.Log(LogLevel.Error, $"Failed to add health record: {ex.Message}");
                return StatusCode(500, "Server error while adding record");
            }
        }
    }
}
