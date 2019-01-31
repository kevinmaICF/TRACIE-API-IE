using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TRACIE_API_IE.Models
{
    public class IE_ascThreadUser
    {
        [Key]
        public int ThreadUserID { get; set; }
        public int ThreadID { get; set; }
        [ForeignKey("ThreadID")]
        public IE_tblMBThread IE_tblMBThread { get; set; }
        public int UserID { get; set; }
        public Nullable<DateTime> DateCreated { get; set; }
        public Nullable<int> CreatedBy { get; set; }

        
    }
}