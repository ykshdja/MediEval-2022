/**
 * @author - Yash Khanduja, 000826385
 * @date - 2022/12/02
 * 
 * Statement of Authorship - I hereby declare that this is my own work.
 * 
 */


using MediEval.Data;
using MediEval.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MediEval.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public ActionResult FAQ()
        {
            return View();
        }

        [AcceptVerbs("GET")]
        public ActionResult ContactUs()
        {
            return View();
        }

        [AcceptVerbs("POST")]
        public ActionResult ContactUs(ContactUsModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(model);

                // Do model valid
                return RedirectToAction("ContactUs");

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("error", ex.Message);

                return View(model);
            }
        }

        public ActionResult AboutUs()
        {
            return View();
        }

        public ActionResult PrivacyStatement()
        {
            return View();
        }

        public ActionResult TermsOfService()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


      


    }
}