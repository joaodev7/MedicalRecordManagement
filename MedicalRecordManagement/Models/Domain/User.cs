using static MedicalRecordManagement.Models.Enums.Enums;

namespace MedicalRecordManagement.Models.Domain
{
    public class User : BaseModel
    {
        public Guid Id { get; set; }
        public string? TaxNumber { get; set; }
        public string? Password { get; set; }
        public UserRole Role { get; set; }
        public MedicalRecord? MedicalRecord { get; set; }
    }
}
