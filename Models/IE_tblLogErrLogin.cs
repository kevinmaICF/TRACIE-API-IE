using System;
using System.ComponentModel.DataAnnotations;

namespace TRACIE_API_AC.Models
{
    public class AC_tblLogErrLogin
    {
        [Key]
        public int RecID { get; set; }
        public Nullable<int> UserID { get; set; }
        public Nullable<int> ServerID { get; set; }
        public Nullable<int> EntryPointID { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public int StatusID { get; set; }
        public Nullable<System.DateTime> DateUpdated { get; set; }
    }
}