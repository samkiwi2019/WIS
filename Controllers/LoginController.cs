using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WIS.Data;
using WIS.Models;
using WIS.Utils;

namespace WIS.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserRepo _repository;

        public LoginController(IUserRepo userRepo)
        {
            _repository = userRepo;
        }

        // GET
        public IActionResult Index()
        {
            return View();
        }


        public class LoggedUser
        {
            public string Email { get; set; }
            public string HashPassword { get; set; }
        }

        // POST: Users/Create
        [HttpPost]
        public async Task<IActionResult> Index(LoggedUser user)
        {
            var u = await _repository.VerifyUser(user.Email, user.HashPassword);
            var cookieOptions = new CookieOptions();
            cookieOptions.Expires = DateTime.Now.AddDays(7);
            Response.Cookies.Append("WISTOKEN", u.Email, cookieOptions);
            return RedirectToAction("Index", "Home");
        }
    }
}