using MedicalRecordManagement.Data;
using MedicalRecordManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MedicalRecordManagement.Controllers
{
    public class LoginController : Controller
    {
        private readonly MedicalRecordMabagementDbContext dbContext;

        public LoginController(MedicalRecordMabagementDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Login(string cpf, string password, string userType)
        {
            // Aqui você pode implementar a lógica de autenticação.
            // Por exemplo, verificar se o usuário e senha são válidos em um banco de dados
            // e se o usuário selecionou "Paciente" ou "Médico".

            // Após a autenticação, você pode redirecionar para outras páginas específicas,
            // dependendo do tipo de usuário:

            if (userType == "Paciente")
            {
                return RedirectToPage("/Paciente/Index");
            }
            else if (userType == "Médico")
            {
                return RedirectToPage("/Medico/Index");
            }
            else
            {
                // Caso o tipo de usuário seja inválido, você pode retornar uma página de erro.
                return RedirectToPage("/Error");
            }
        }
    }
}