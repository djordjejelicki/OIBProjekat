using PetShop.Domain.Entities;

namespace PetShop.Application.Interfaces.Repositories
{
    public interface IHealthRecordRepository
    {
        IEnumerable<HealthRecord> GetByPetId(Guid petId);
        void Add(HealthRecord record);
    }
}
