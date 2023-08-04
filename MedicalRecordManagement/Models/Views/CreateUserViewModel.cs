using System.ComponentModel.DataAnnotations;
using static MedicalRecordManagement.Models.Enums.Enums;

namespace MedicalRecordManagement.Models.Views
{
    public class CreateUserViewModel
    {
        [Required(ErrorMessage = "O campo CPF é obrigatório.")]
        public string? TaxNumber { get; set; }
        [Required(ErrorMessage = "O campo Senha é obrigatório.")]
        public string? Password { get; set; }
        public UserRole Role { get; set; }
    }
}
