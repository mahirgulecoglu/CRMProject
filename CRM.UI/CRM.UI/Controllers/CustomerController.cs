using CRM.BLL;
using CRM.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRM.UI.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult GetCustomers()
        {
            if (Session["Employee"] == null)
            {
                return RedirectToAction("Hata", "Home");
            }
            else
            {
                Employees employee = Session["Employee"] as Employees;
                if (LoginAccessBLL.UserHasRole(employee.Email, "Admin"))
                {
                    ViewBag.Edit = "Visible";
                    ViewBag.Delete = "Visible";
                    ViewBag.Detail = "Visible";

                }
                else if (LoginAccessBLL.UserHasRole(employee.Email, "Manager"))
                {
                    ViewBag.Edit = "Visible";
                    ViewBag.Delete = "Hidden";
                    ViewBag.Detail = "Visible";
                }
                else
                {
                    ViewBag.Edit = "Hidden";
                    ViewBag.Delete = "Hidden";
                    ViewBag.Detail = "Visible";
                }
                var customer = LoginAccessBLL.GetCustomers();
                return View(customer);
            }

        }

        public ActionResult Edit(int id)
        {
            var customer = LoginAccessBLL.GetCustomer(id);

            return View(customer);
        }

        [HttpPost]
        public ActionResult Edit(Customers customer)
        {
            if (Session["Employee"] == null)
            {
                return RedirectToAction("Hata", "Home");
            }
            Customers cust = LoginAccessBLL.GetCustomer(customer.CustomerID);
            cust.CustomerID = customer.CustomerID;
            cust.BirthDate = customer.BirthDate;
            cust.FirstName = customer.FirstName;
            cust.Phone = customer.Phone;
            cust.Email = customer.Email;
            cust.LastName = customer.LastName;
            LoginAccessBLL.Update(cust);
            return View();
        }

        public ActionResult Delete(int id)
        {
            if (Session["Employee"] == null)
            {
                return RedirectToAction("Hata", "Home");
            }
            var customer = LoginAccessBLL.GetCustomer(id);
            return View(customer);
        }

        [HttpPost]
        public ActionResult Delete(Customers customer)
        {
            if (Session["Employee"] == null)
            {
                return RedirectToAction("Hata", "Home");
            }

            Employees employee = Session["Employee"] as Employees;
            if (!LoginAccessBLL.UserHasRole(employee.Email, "Admin"))
            {
                return RedirectToAction("Hata", "Home");
            }

            Customers cust = LoginAccessBLL.GetCustomer(customer.CustomerID);
            cust.CustomerID = customer.CustomerID;
            cust.BirthDate = customer.BirthDate;
            cust.FirstName = customer.FirstName;
            cust.Phone = customer.Phone;
            cust.Email = customer.Email;
            cust.LastName = customer.LastName;
            LoginAccessBLL.Delete(cust);
            return View();
        }
        public ActionResult Details(int id)
        {
            if (Session["Employee"] == null)
            {
                return RedirectToAction("Hata", "Home");
            }
            var customer = LoginAccessBLL.GetCustomer(id);
            return View(customer);
        }

    }
}