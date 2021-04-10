using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WIS.Data;
using WIS.Models;

namespace WIS.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var cookieValue = Request.Cookies["WISTOKEN"];
            ViewData["user"] = cookieValue;
            return View();
        }
        
        [HttpPost]
        public IActionResult Logout()
        {
            var cookieOptions = new CookieOptions();
            cookieOptions.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Append("WISTOKEN", "", cookieOptions);
            return View("Index");
        }
        
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}