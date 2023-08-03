using static MedicalRecordManagement.Models.Enums.Enums;

namespace MedicalRecordManagement.Models.Views
{
    public class CreateUserViewModel
    {
        public string? TaxNumber { get; set; }
        public string? Password { get; set; }
        public UserRole Role { get; set; }
    }
}
