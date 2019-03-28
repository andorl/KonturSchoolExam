using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WorkManager.Areas.Identity.Data;
using WorkManager.Models;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace WorkManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([FromBody] RegisterData data)
        {
            if (ModelState.IsValid)
            {
                var user = new AppUser { UserName = data.Name, Email = data.Email };

                var result = await userManager.CreateAsync(user, data.Password);
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: true);
                    return Ok();
                }

                return Forbid();
            }

            return BadRequest();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginData data)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager
                    .PasswordSignInAsync(data.Name, data.Password, isPersistent: true, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    return Ok();
                }

                return Unauthorized();
            }

            return BadRequest();
        }
    }
}