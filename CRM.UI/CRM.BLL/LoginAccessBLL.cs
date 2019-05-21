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
        public static Employees LoginUser(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                throw new MissingFieldException("kullanıcı adı yada şifreyi boş gönderemezsiniz");
            }

            Datacontext db = new Datacontext();
            var employee = db.Employees.Where(e => e.Email == username && e.Password == password).FirstOrDefault();
            return employee;
        }
        public static List<Roles> GetUserRoles(string userName)
        {
            Datacontext db = new Datacontext();

            var result = from e in db.Employees
                         join er in db.EmployeeRoles on e.EmployeeID equals er.EmployeeID
                         join r in db.Roles on er.RoleID equals r.RoleID
                         where e.Email == userName
                         select r;

            return result.ToList();
        }

        public static bool UserHasRole(string username, string roleName)
        {
            Datacontext db = new Datacontext();

            var result = (from e in db.Employees
                          join er in db.EmployeeRoles on e.EmployeeID equals er.EmployeeID
                          join r in db.Roles on er.RoleID equals r.RoleID
                          where e.Email == username && r.Name == roleName
                          select r).Any();

            return result;
        }
    }
}
