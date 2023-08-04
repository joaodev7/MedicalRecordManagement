using System.ComponentModel.DataAnnotations;

namespace MedicalRecordManagement.Models.Views
{
    public class LoginUserViewModel
    {
        [Required(ErrorMessage = "O campo CPF é obrigatório.")]
        [TaxNumber(ErrorMessage = "CPF inválido")]
        public string? TaxNumber { get; set; }
        [Required(ErrorMessage = "O campo Senha é obrigatório.")]
        public string? Password { get; set; }
    }
}
