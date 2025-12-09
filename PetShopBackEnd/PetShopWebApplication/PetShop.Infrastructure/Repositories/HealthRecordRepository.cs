using PetShop.Application.Interfaces.Repositories;
using PetShop.Domain.Entities;
using PetShop.Infrastructure.Data;

namespace PetShop.Infrastructure.Repositories
{
    public class HealthRecordRepository : IHealthRecordRepository
    {
        private readonly PetShopDbContext _context;

        public HealthRecordRepository(PetShopDbContext context)
        {
            _context = context;
        }
        public void Add(HealthRecord record)
        {
            _context.HealthRecords.Add(record);
            _context.SaveChanges();
        }

        public IEnumerable<HealthRecord> GetByPetId(Guid petId)
        {
            return _context.HealthRecords.Where(r => r.PetId == petId).OrderByDescending(r => r.Date).ToList();
        }
    }
}
