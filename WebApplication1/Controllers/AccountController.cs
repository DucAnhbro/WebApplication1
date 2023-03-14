using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class AccountController : Controller
    {
        
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Customer customer)
        {
            if(ModelState.IsValid)
            {
               using(var context = new DemodatbaseContext())
                {
                    var check = context.Customers.FirstOrDefault(x => x.UserName == customer.UserName);
                    if(check == null)
                    {
                        context.Customers.Add(customer);
                        context.SaveChanges();
                    }
                    else
                    {
                        ViewBag.error = "Username already exists.";
                        return RedirectToAction("Register");
                    }
                }
            }
            return View("Login");
        }

        public ActionResult login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            if (ModelState.IsValid)
            {
                using (var context = new DemodatbaseContext())
                {
                    var data = context.Customers.Where(a => a.UserName.Equals(username) && a.Password.Equals(password)).FirstOrDefault();
                    if (data != null)
                    {
                        HttpContext.Session.SetString(username, "UserName");
                        HttpContext.Session.SetString(password, "Password");
                        if(data.UserName == "Admin")
                        {
                            return RedirectToAction("Index", "Customers");
                        }
                        if(data.Role == 1)
                        {
                            return RedirectToAction("","");
                        }
                        if(data.Role == 2)
                        {
                            return RedirectToAction("HomePage", "HomePage");

                        }
                    }
                    else
                    {
                        ViewBag.error = "Login fail.";
                        return RedirectToAction("Login");

                    }
                }
            }
            return View();
        }

        public ActionResult Logout()
        {
            return RedirectToAction("Login");
        }

    }
}
