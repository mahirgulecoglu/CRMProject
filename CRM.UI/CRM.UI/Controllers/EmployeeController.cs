using CRM.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRM.UI.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult UserDetail()
        {
            if (Session["Employee"] == null)
            {
                return RedirectToAction("Hata", "Home");
            }

            var employee = Session["Employee"] as Employees;
            return View(employee);
        }
    }
}