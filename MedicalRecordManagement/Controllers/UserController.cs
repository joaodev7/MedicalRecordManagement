using MedicalRecordManagement.Data;
using MedicalRecordManagement.Models.Domain;
using MedicalRecordManagement.Models.Views;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

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
            if (!ModelState.IsValid)
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

        public async Task<IActionResult> View(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                    throw new Exception("Valor invalido");

                var user = await dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
                var medicalRecord = await dbContext.MedicalRecords.FirstOrDefaultAsync(u => u.Id == user.MedicalRecord.Id);

                var userViewModel = new UserViewModel
                {
                    Id = id,
                    FullName = medicalRecord.FullName,
                    Address = medicalRecord.Address,
                    PhoneNumber = medicalRecord.PhoneNumber,
                    Photo = medicalRecord.Photo,
                    Role = user.Role,
                    TaxNumber = user.TaxNumber,
                };

                return View(user);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
