using MedicalRecordManagement.Data;
using MedicalRecordManagement.Models.Domain;
using MedicalRecordManagement.Models.Views;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MedicalRecordManagement.Controllers
{
    public class MedicalRecordController : Controller
    {
        private readonly MedicalRecordMabagementDbContext dbContext;
        private readonly IWebHostEnvironment webHostEnvironment;

        public MedicalRecordController(MedicalRecordMabagementDbContext dbContext, IWebHostEnvironment webHostEnvironment)
        {
            this.dbContext = dbContext;
            this.webHostEnvironment = webHostEnvironment;
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserViewModel userViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var medicalRecord = new MedicalRecord
                    {
                        Id = Guid.NewGuid(),
                        Address = userViewModel.Address,
                        FullName = userViewModel.FullName,
                        CPF = userViewModel.TaxNumber,
                        PhoneNumber = userViewModel.PhoneNumber,
                        CreationDate = DateTime.Now,
                        Photo = userViewModel.Photo,
                    };

                    dbContext.MedicalRecords.Add(medicalRecord);
                    await dbContext.SaveChangesAsync();

                    var user = await dbContext.Users.FirstOrDefaultAsync(u => u.Id == userViewModel.Id && u.DeletionDate == null);

                    if (user == null)
                        throw new Exception("usuário não foi criado");

                    user.MedicalRecord = medicalRecord;
                    user.UpdateDate = DateTime.Now;

                    dbContext.Users.Update(user);
                    await dbContext.SaveChangesAsync();

                    var userVal = await dbContext.Users.FirstOrDefaultAsync(u => u.Id == userViewModel.Id && u.DeletionDate == null);

                    return RedirectToAction("Index", "Home");
                }

                return RedirectToAction("Index","User",userViewModel);

            }
            catch (Exception ex)
            {
                return View();
            }
        }
    }
}
