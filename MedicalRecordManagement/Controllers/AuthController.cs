using MedicalRecordManagement.Auth;
using MedicalRecordManagement.Data;
using MedicalRecordManagement.Models.Views;
using Microsoft.AspNetCore.Mvc;

namespace MedicalRecordManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IJwtService _jwtService;
        private readonly MedicalRecordMabagementDbContext dbContext;

        public AuthController(IJwtService jwtService, MedicalRecordMabagementDbContext dbContext)
        {
            _jwtService = jwtService;
            this.dbContext = dbContext;
        }

        [HttpPost("Auth")]
        public IActionResult Auth(LoginUserViewModel model)
        {
            var user = dbContext.Users.Find(model.TaxNumber);

            if (user == null)
            {
                return Unauthorized();
            }

            var token = _jwtService.GenerateJwtToken(user.Id.ToString());
            return Ok(new { token });
        }
    }
}
