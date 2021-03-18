using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WIS.Data;
using WIS.Models;
using WIS.Utils;

namespace WIS.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IUserRepo _repository;

        public RegisterController(IUserRepo userRepo)
        {
            _repository = userRepo;
        }
        // GET
        public IActionResult Index()
        {
            return View();
        }
        
        // POST: Users/Create
        [HttpPost]
        public async Task<IActionResult> Index(User user)
        {
            // updated user.password to hashed password
            var hashSalt = Extensions.GenerateSaltedHash(user.HashPassword);
            user.HashPassword = hashSalt.HashPassword;
            user.Salt = hashSalt.Salt;
            user.CreatedAt = DateTime.Now;
            await _repository.Create(user);
            return RedirectToAction("Index", "Login");
        }
    }
}