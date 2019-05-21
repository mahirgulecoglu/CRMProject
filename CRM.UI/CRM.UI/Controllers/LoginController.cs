using CRM.UI.Models;
using CRM.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRM.UI.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Logout()
        {
            Session["Employee"] = null;
            return RedirectToAction("Index");

        }
        
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            var employee = LoginAccessBLL.LoginUser(model.UserName, model.Password);

            if (employee == null)
            {
                TempData["Hata"] = "Kullanıcı bulunamadı";
                return RedirectToAction("Index");
            }
            else
            {
                Session["Employee"] = employee;
                return RedirectToAction("Index", "Home");
            }

        }
    }
}