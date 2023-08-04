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

            return View(users);
        }

    }
}
