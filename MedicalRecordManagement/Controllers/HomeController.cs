using MedicalRecordManagement.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MedicalRecordManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly MedicalRecordMabagementDbContext dbContext;

        public HomeController(MedicalRecordMabagementDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var users = await dbContext.Users.ToListAsync();

            if (TempData.ContainsKey("ErrorMessage"))
            {
                var errorMessage = TempData["ErrorMessage"] as string;
                // Você pode usar a mensagem de erro para notificações, logs ou para exibição na View.
                // Por exemplo, usando ViewData ou ViewBag para exibir na View:
                ViewBag.ErrorMessage = errorMessage;
            }

            return View(users);
        }

    }
}
