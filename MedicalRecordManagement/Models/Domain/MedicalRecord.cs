using System.ComponentModel.DataAnnotations;

namespace MedicalRecordManagement.Models.Domain
{
    public class MedicalRecord
    {
        public Guid Id { get; set; }
        public string? FullName { get; set; }
        public string? Photo { get; set; } // Caminho ou URL da foto
        [Required]
        [RegularExpression(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$", ErrorMessage = "CPF inválido")]
        public string? CPF { get; set; }
        public string? PhoneNumber { get; set; } // Formato E.164: "+5511987654321"
        public string? Address { get; set; }
    }
}
