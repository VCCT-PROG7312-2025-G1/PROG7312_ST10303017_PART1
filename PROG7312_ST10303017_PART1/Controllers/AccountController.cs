using Microsoft.AspNetCore.Mvc;
using PROG7312_ST10303017_PART1.DataStructures;
using PROG7312_ST10303017_PART1.Models;
using PROG7312_ST10303017_PART1.Models.ViewModels;
using PROG7312_ST10303017_PART1.Services;

namespace PROG7312_ST10303017_PART1.Controllers
{
    public class AccountController : Controller
    {
        // GET: /Account/Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (DataManager.ValidateUser(model.Username, model.Password))
                {
                    return RedirectToAction("Dashboard", "Home");
                }
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }
            return View(model);
        }

        public IActionResult Logout()
        {
            DataManager.Logout();
            return RedirectToAction("Login", "Account");
        }
    }
}
