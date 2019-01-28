using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TRACIE_API_AC.Models
{
    public class IE_tblMBPost
    {
        public int PostID { get; set; }
        public Nullable<int> ThreadID { get; set; }
        public Nullable<int> ParentID { get; set; }
        public string Text { get; set; }
        public string Title { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<System.DateTime> DateUpdated { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public Nullable<int> StatusID { get; set; }
        public Nullable<int> TypeID { get; set; }
        public Nullable<int> Ord { get; set; }
        public Nullable<System.DateTime> DateLatest { get; set; }
        public Nullable<int> Sticky { get; set; }
    
        public virtual IE_tblMBThread IE_tblMBThread { get; set; }
    }
}
