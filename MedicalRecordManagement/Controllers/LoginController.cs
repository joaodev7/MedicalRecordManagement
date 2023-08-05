using MedicalRecordManagement.Data;
using MedicalRecordManagement.Models;
using MedicalRecordManagement.Models.Views;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            if (TempData.ContainsKey("ErrorMessage"))
            {
                var errorMessage = TempData["ErrorMessage"] as string;
                ViewBag.ErrorMessage = errorMessage;
            }
            return View();
        }
        [HttpPost]       
        public IActionResult Login(LoginUserViewModel loginUserViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                    return RedirectToAction("Index", loginUserViewModel);

                var user = dbContext.Users.FirstOrDefault(u => u.TaxNumber == loginUserViewModel.TaxNumber && u.DeletionDate == null);

                if (user == null)
                    throw new Exception("Usuário não cadastrado");

                if (user.Password == loginUserViewModel.Password)
                    return RedirectToAction("Index", "Home");
                else
                    throw new Exception("Senha inválida");

            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Index", "Login");
            }
        }
    }
}