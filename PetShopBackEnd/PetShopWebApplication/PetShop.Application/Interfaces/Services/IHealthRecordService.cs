using PetShop.Domain.Entities;

namespace PetShop.Application.Interfaces.Services
{
    public interface IHealthRecordService
    {
        IEnumerable<HealthRecord> GetRecords(Guid petId);
        void AddRecord(HealthRecord record);
    }
}
