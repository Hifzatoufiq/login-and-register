using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        readonly MyContext _context;
        public HomeController(ILogger<HomeController> logger,MyContext db)
        {
            _logger = logger;
            _context = db;
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();  // Clear all session data
            return RedirectToAction("Index", "Home");  // Redirect to home or login page
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(register us)
        {
            if (ModelState.IsValid)
            {
                var use = new register();
                use.Email = us.Email;
                use.Password = us.Password;
                use.Name = us.Name;
                use.Role = "user";
                _context.table1.Add(use);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(us);
        }
        public IActionResult login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult login(login s)
        {
           
           var obj = _context.table1.FirstOrDefault(x=>x.Email== s.Email && x.Password==s.Password);
            if (obj != null)
            {
               HttpContext.Session.SetString("Email", obj.Email);
                HttpContext.Session.SetString("Role", obj.Role);
                if (obj.Role == "user")
                {
                    return RedirectToAction("Index");

                }
                else if (obj.Role == "admin")
                {
                    return RedirectToAction("dashboard");
                }
            }
            return View();
        }
           
        public IActionResult dashboard()
        {
            return View();
        }
                    
        /*[HttpPost]
        public IActionResult login(login hel)
        {
            var user = _context.table1.FirstOrDefault(x => x.Email == hel.Email && x.Password == hel.Password);
            if (user != null)
            {
                HttpContext.Session.SetString("Email", user.Email);
                HttpContext.Session.SetString("Role", user.Role);
                if (user.Role == "user")
                {
                    return RedirectToAction("Index");
                }
                else if (user.Role == "admin")
                {
                    return RedirectToAction("dashboard");
                }

            }
            else
            {
                ViewBag.InvalidEmailPass = "invalid email or password";
            }
            return View();

        }
        public IActionResult dashboard()
        {
            return View();
        }*/



        public IActionResult create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult create(product model)
        {
            if (ModelState.IsValid)
            {
                _context.table2.Add(model);
                _context.SaveChanges();
                return RedirectToAction("list");

            }
            return View();
        }
        public IActionResult list(product us)
        {
            var list = _context.table2.ToList();

            return View(list);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
