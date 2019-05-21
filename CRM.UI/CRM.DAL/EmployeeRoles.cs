namespace CRM.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EmployeeRoles
    {
        [Key]
        public int EmployeeRoleID { get; set; }

        public int RoleID { get; set; }

        public int EmployeeID { get; set; }

        public virtual Employees Employees { get; set; }

        public virtual Roles Roles { get; set; }
    }
}
