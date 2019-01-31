using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TRACIE_API_IE.Models
{
    public class IE_tblEvent
    {
        [Key]
        public int EventID { get; set; }
        public Nullable<int> EventTypeID { get; set; }
        public string EventTitle { get; set; }
        public string EventVar1 { get; set; }
        public string EventVar2 { get; set; }
        public Nullable<int> StatusID { get; set; }
        public Nullable<DateTime> DateCreated { get; set; }
        public Nullable<int> CreatedBy { get; set; }
    }
}
