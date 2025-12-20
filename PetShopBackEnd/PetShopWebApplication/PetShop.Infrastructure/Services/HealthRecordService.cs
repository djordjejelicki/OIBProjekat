using PetShop.Application.Interfaces.Repositories;
using PetShop.Application.Interfaces.Services;
using PetShop.Domain.Entities;
using PetShop.Domain.Enums;

namespace PetShop.Infrastructure.Services
{
    public class HealthRecordService : IHealthRecordService
    {
        private readonly IHealthRecordRepository _healthRecordRepository;
        private readonly ILoggerService _logger;

        public HealthRecordService(IHealthRecordRepository healthRecordRepository,ILoggerService logger)
        {
            _healthRecordRepository = healthRecordRepository;
            _logger = logger;
        }
        public void AddRecord(HealthRecord record)
        {
            if (string.IsNullOrWhiteSpace(record.Notes))
            {
                _logger.Log(LogLevel.Warning, $"Health record for pet {record.PetId} has empty Notes.");
            }

            _healthRecordRepository.Add(record);
            _logger.Log(LogLevel.Info,
            $"Health record added for pet {record.PetId} by {record.RecordedBy}. Type: {record.RecordType}, Date: {record.Date}");
        }

        public IEnumerable<HealthRecord> GetRecords(Guid petId)
        {
            _logger.Log(LogLevel.Info, $"Fetching health records for pet {petId}");
            return _healthRecordRepository.GetByPetId(petId);
        }
    }
}
