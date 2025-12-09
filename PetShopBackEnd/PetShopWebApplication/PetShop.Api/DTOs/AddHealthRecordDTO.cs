using PetShop.Domain.Enums;

namespace PetShop.Api.DTOs
{
    public class AddHealthRecordDTO
    {
        public Guid PetId { get; set; }
        public HealthRecordType RecordType { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string? Notes { get; set; }
    }
}
