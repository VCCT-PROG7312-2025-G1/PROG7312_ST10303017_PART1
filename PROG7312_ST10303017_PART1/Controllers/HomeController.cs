using Microsoft.AspNetCore.Mvc;
using PROG7312_ST10303017_PART1.DataStructures;
using PROG7312_ST10303017_PART1.Models;
using PROG7312_ST10303017_PART1.Models.ViewModels;
using PROG7312_ST10303017_PART1.Services;
using System.Diagnostics;


namespace PROG7312_ST10303017_PART1.Controllers
{
    // Main controller for handling home page and user dashboard
    public class HomeController : Controller
    {
        // Helper method to check if user is authenticated
        private bool IsUserAuthenticated() => DataManager.CurrentUser != null;

        public IActionResult Index()
        {
            return RedirectToAction("Login", "Account");
        }

        // GET action for the user dashboard
        public IActionResult Dashboard()
        {
            if (!IsUserAuthenticated()) return RedirectToAction("Login", "Account");

            ViewBag.FullName = DataManager.CurrentUser.FullName;
            return View();
        }

        // GET action for the Report Issues page
        public IActionResult NewRequest()
        {
            if (!IsUserAuthenticated()) return RedirectToAction("Login", "Account");

            // Pass an empty ViewModel to the view
            return View(new NewRequestViewModel());
        }

        // POST action for the Report Issues page
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult NewRequest(NewRequestViewModel model)
        {
            if (!IsUserAuthenticated()) return RedirectToAction("Login", "Account");

            if (ModelState.IsValid)
            {
                // Map the ViewModel to our ServiceRequest domain model
                var newRequest = new ServiceRequest
                {
                    Location = model.Location,
                    Category = model.Category,
                    Description = model.Description,
                    SubmittedDate = DateTime.Now,
                    Status = "Submitted",
                    SubmittedByUsername = DataManager.CurrentUser.Username
                };

                // Handle the file upload
                if (model.MediaAttachment != null && model.MediaAttachment.Length > 0)
                {
                    newRequest.MediaFileName = model.MediaAttachment.FileName;
                }

                // Submit to our data manager
                DataManager.SubmitNewRequest(newRequest);

                TempData["SuccessMessage"] = "Your report has been submitted successfully!";

                return RedirectToAction("MyReports");
            }

            // If the model is not valid, return to the form with the errors
            return View(model);
        }

        public IActionResult MyReports()
        {
            if (!IsUserAuthenticated()) return RedirectToAction("Login", "Account");

            var reports = DataManager.GetRequestsForCurrentUser();
            return View(reports);
        }

        public IActionResult LocalEvents()
        {
            if (!IsUserAuthenticated()) return RedirectToAction("Login", "Account");
            return View();
        }

        public IActionResult ServiceStatus()
        {
            if (!IsUserAuthenticated()) return RedirectToAction("Login", "Account");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
