using MedicalRecordManagement.Data;
using MedicalRecordManagement.Models;
using MedicalRecordManagement.Models.Views;
using Microsoft.AspNetCore.Mvc;

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
        [HttpPost]       
        public IActionResult Login(LoginUserViewModel loginUserViewModel)
        {
            if(!ModelState.IsValid)
                return RedirectToAction("Index",loginUserViewModel);

            return RedirectToAction("Index", "Home");
        }
    }
}