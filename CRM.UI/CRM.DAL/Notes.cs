namespace CRM.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Notes
    {
        [Key]
        public int NoteID { get; set; }

        public int CustomerID { get; set; }

        [Required]
        public string Note { get; set; }

        public virtual Customers Customers { get; set; }
    }
}
