using MedicalRecordManagement.Data;
using MedicalRecordManagement.Models.Domain;
using MedicalRecordManagement.Models.Views;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MedicalRecordManagement.Controllers
{
    public class UserController : Controller
    {
        private readonly MedicalRecordMabagementDbContext dbContext;

        public UserController(MedicalRecordMabagementDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpPost]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserViewModel createUserRequest) 
        {
            if(!ModelState.IsValid)
                return View(createUserRequest);

            var user = new User()
            {
                Id = Guid.NewGuid(),
                TaxNumber = createUserRequest.TaxNumber,
                Password = createUserRequest.Password,
                Role = createUserRequest.Role,
            };

            await dbContext.Users.AddAsync(user);
            await dbContext.SaveChangesAsync();

            return RedirectToAction("Index", "Home");

        }

        public async Task<IActionResult> View (Guid id)
        {
            await dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
            return View();
        }
    }
}
