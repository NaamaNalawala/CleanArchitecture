using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System;
using RentalQuotationModule.Models;
using System.Threading.Tasks;
using RentalQuotationModule.Core.Interfaces;
using RentalQuotationModule.Core.Entities;

namespace RentalQuotationModule.Controllers
{
    public class LoginController : Controller
    {
        private readonly IJwtTokenGenerator _tokengenerator;
        private readonly IUserService _userService;
        public LoginController(IJwtTokenGenerator tokengenerator, IUserService userService)
        {
            _tokengenerator = tokengenerator;
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(User model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userService.AuthenticateUserAsync(model);
                if (user != null)
                {
                    var token = _tokengenerator.GenerateAccessToken(user);
                    Response.Cookies.Append("jwt", token);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.ErrorMessage = "Invalid username or password.";
                }
            }

            return View(model);
        }


    }
}
