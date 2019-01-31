using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TRACIE_API_IE.Models
{
    public class IE_tblLogEvent
    {
        [Key]
        public int EventRecID { get; set; }
        public Nullable<int> EventTypeID { get; set; }
        public string EventDesc { get; set; }
        public string EventTitle { get; set; }
        public Nullable<int> DirID { get; set; }
        public Nullable<int> ThreadID { get; set; }
        public Nullable<int> FileID { get; set; }
        public Nullable<DateTime> DateCreated { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<int> ServerID { get; set; }
        public Nullable<int> UserID { get; set; }
    }
}
