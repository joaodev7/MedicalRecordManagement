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

        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            var users = await dbContext.Users.ToListAsync();

            return Ok(users);
        }

        [HttpGet]
        public IActionResult CreateUser()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserViewModel createUserRequest) {

            var user = new User()
            {
                Id = Guid.NewGuid(),
                TaxNumber = createUserRequest.TaxNumber,
                Password = createUserRequest.Password,
                Role = createUserRequest.Role,
            };

            await dbContext.Users.AddAsync(user);
            await dbContext.SaveChangesAsync();

            return RedirectToAction("CreateUser");
        
        }
    }
}
