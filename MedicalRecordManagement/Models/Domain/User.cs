using static MedicalRecordManagement.Models.Enums.Enums;

namespace MedicalRecordManagement.Models.Domain
{
    public class User
    {
        public Guid Id { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public UserRole Role { get; set; }
    }
}
