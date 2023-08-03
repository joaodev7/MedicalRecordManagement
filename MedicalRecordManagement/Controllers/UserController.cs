using Microsoft.AspNetCore.Mvc;

namespace MedicalRecordManagement.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public IActionResult CreateUser()
        {
            return View();
        }
    }
}
