using CRM.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.BLL
{
    public class LoginAccessBLL
    {
        static Datacontext dba = new Datacontext();
        public static List<Customers> GetCustomers()
        {
            var customer = dba.Customers.ToList();
            return customer;
        }
        public static Customers GetCustomer(int id)
        {
            return dba.Customers.FirstOrDefault(x => x.CustomerID == id);
        }
        public static void Update(Customers customer)
        {
            dba.SaveChanges();
        }
        public static void Delete(Customers customer)
        {
            dba.Customers.Remove(customer);
            dba.SaveChanges();
        }
        public static void Add(Customers customer)
        {
            dba.Customers.Add(customer);
            dba.SaveChanges();
        }
        public static Employees LoginUser(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                throw new MissingFieldException("kullanıcı adı yada şifreyi boş gönderemezsiniz");
            }
            
            var employee = dba.Employees.Where(e => e.Email == username && e.Password == password).FirstOrDefault();
            return employee;
        }
        public static List<Roles> GetUserRoles(string userName)
        {
            var result = from e in dba.Employees
                         join er in dba.EmployeeRoles on e.EmployeeID equals er.EmployeeID
                         join r in dba.Roles on er.RoleID equals r.RoleID
                         where e.Email == userName
                         select r;

            return result.ToList();
        }

        public static bool UserHasRole(string username, string roleName)
        {
            var result = (from e in dba.Employees
                          join er in dba.EmployeeRoles on e.EmployeeID equals er.EmployeeID
                          join r in dba.Roles on er.RoleID equals r.RoleID
                          where e.Email == username && r.Name == roleName
                          select r).Any();

            return result;
        }
    }
}
