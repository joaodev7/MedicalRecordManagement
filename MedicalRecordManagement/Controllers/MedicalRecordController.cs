using MedicalRecordManagement.Data;
using MedicalRecordManagement.Models.Domain;
using MedicalRecordManagement.Models.Views;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> Create(UserViewModel userViewModel, IFormFile photo)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var medicalRecord = new MedicalRecord
                    {
                        Id = Guid.NewGuid(),
                        Address = userViewModel.Address,
                        CPF = userViewModel.TaxNumber,
                        PhoneNumber = userViewModel.PhoneNumber,
                        CreationDate = DateTime.Now,
                    };

                    if (photo != null && photo.Length > 0)
                    {
                        try
                        {
                            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(photo.FileName);

                            string filePath = Path.Combine(webHostEnvironment.WebRootPath, "Uploads", fileName);

                            using (var fileStream = new FileStream(filePath, FileMode.Create))
                            {
                                await photo.CopyToAsync(fileStream);
                            }

                            medicalRecord.Photo = "/Uploads/" + fileName;
                        }
                        catch (Exception ex)
                        {
                            TempData["ErrorMessage"] = "Error while uploading photo: " + ex.Message;
                            return View(medicalRecord);
                        }
                    }

                    dbContext.MedicalRecords.Add(medicalRecord);
                    await dbContext.SaveChangesAsync();

                    return RedirectToAction("Index", "Home");
                }

                return View();

            }
            catch (Exception ex)
            {
                return View();
            }
        }
    }
}
