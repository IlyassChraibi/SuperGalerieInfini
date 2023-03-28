using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VsGalerie.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VsGalerie.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        UserManager<User> userManager;
        RoleManager<IdentityRole> roleManager;

        public AccountController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        // POST api/Account/Login

       

        // POST: api/<AccountController>
        [HttpPost]
        public async Task<ActionResult> Register(RegisterDTO register)
        {
            if (register.Password != register.PasswordConfirm)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new {Message = " Les deux mots de passe spécifiés sont différents."});
            }

            User user = new User()
            {
                UserName = register.UserName,
                Email = register.Email
            };
            IdentityResult identityResult = await this.userManager.CreateAsync(user, register.Password);

            if (!identityResult.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return Ok(new {Message = "Inscription réussie !"});
        }
    }
}
