using PetShop.Domain.Enums;

namespace PetShop.Domain.Entities
{
    public class HealthRecord
    {
        public Guid Id { get; set; }

        public Guid PetId { get; set; }
        public Pet Pet { get; set; }

        public HealthRecordType RecordType { get; set; }

        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string? Notes { get; set; }

        public string RecordedBy { get; set; }

    }
}
