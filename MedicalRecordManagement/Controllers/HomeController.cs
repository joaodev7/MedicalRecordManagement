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
            var users = await dbContext.Users.Where(u => u.DeletionDate == null).ToListAsync();

            if (TempData.ContainsKey("ErrorMessage"))
            {
                var errorMessage = TempData["ErrorMessage"] as string;
                ViewBag.ErrorMessage = errorMessage;
            }

            return View(users);
        }

    }
}
