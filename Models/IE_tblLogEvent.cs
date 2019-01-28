using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TRACIE_API_AC.Models
{
    public class IE_tblLogEvent
    {
        public int EventRecID { get; set; }
        public Nullable<int> EventTypeID { get; set; }
        public string EventDesc { get; set; }
        public string EventTitle { get; set; }
        public Nullable<int> DirID { get; set; }
        public Nullable<int> ThreadID { get; set; }
        public Nullable<int> FileID { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<int> ServerID { get; set; }
        public Nullable<int> UserID { get; set; }
    }
}
