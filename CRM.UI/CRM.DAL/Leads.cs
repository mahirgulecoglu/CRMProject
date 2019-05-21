namespace CRM.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Leads
    {
        [Key]
        public int LeadID { get; set; }

        public int EmployeeID { get; set; }

        public int CustomerID { get; set; }

        [Required]
        [StringLength(255)]
        public string Lead { get; set; }

        public DateTime LeadDate { get; set; }

        public virtual Customers Customers { get; set; }

        public virtual Employees Employees { get; set; }
    }
}
