using static MedicalRecordManagement.Models.Enums.Enums;

namespace MedicalRecordManagement.Models.Views
{
    public class UserViewModel
    {
        public Guid Id { get; set; }
        public string? TaxNumber { get; set; }
        public UserRole Role { get; set; }
        public string? FullName { get; set; }
        public string? Photo { get; set; } // Caminho ou URL da foto
        public string? PhoneNumber { get; set; } // Formato E.164: "+5511987654321"
        public string? Address { get; set; }
    }
}
