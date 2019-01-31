using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TRACIE_API_IE.Models
{
    public class IE_tblMBPost
    {
        [Key]
        public int PostID { get; set; }
        public Nullable<int> ThreadID { get; set; }
        [ForeignKey("ThreadID")]
        public IE_tblMBThread IE_tblMBThread { get; set; }

        public Nullable<int> ParentID { get; set; }
        [Column(TypeName = "varchar(350)")]
        public string Text { get; set; }
        public string Title { get; set; }
        public Nullable<DateTime> DateCreated { get; set; }
        public Nullable<DateTime> DateUpdated { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public Nullable<int> StatusID { get; set; }
        public Nullable<int> TypeID { get; set; }
        public Nullable<int> Ord { get; set; }
        public Nullable<DateTime> DateLatest { get; set; }
        public Nullable<int> Sticky { get; set; }
    
        
    }
}
