using CRM.BLL;
using CRM.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRM.UI.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {
            if (Session["Employee"] == null)
            {
                return RedirectToAction("Hata", "Home");
            }

            var employee = Session["Employee"] as Employees;

            ViewBag.OnaylaVisibilityText = "hidden";
            ViewBag.ReddetVisibilityText = "hidden";
            ViewBag.KargolaVisibilityText = "hidden";

            if (LoginAccessBLL.UserHasRole(employee.Email, "Admin"))
            {
                ViewBag.OnaylaVisibilityText = "visible";
                ViewBag.ReddetVisibilityText = "visible";
                ViewBag.KargolaVisibilityText = "visible";
            }

            return View();
        }

        public ActionResult Approve()
        {
            if (Session["Employee"] == null)
            {
                return RedirectToAction("Hata", "Home");
            }

            var employee = Session["Employee"] as Employees;

            if (!LoginAccessBLL.UserHasRole(employee.Email, "Admin"))
            {
                return RedirectToAction("Hata", "Home");
            }

            //Onaylama işlemini yap

            return RedirectToAction("Index");
        }
    }
}