using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TRACIE_API_IE.Models
{
    public class IE_tblMBDir
    {    
        [Key]
        public int DirID { get; set; }
        [Column(TypeName = "varchar(300)")]
        public string Text { get; set; }
        [Column(TypeName = "varchar(300)")]
        public string TextShort { get; set; }
        public Nullable<int> ParentID { get; set; }
        public Nullable<int> TypeID { get; set; }
        public Nullable<int> StatusID { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Path { get; set; }
        public Nullable<DateTime> DateCreated { get; set; }
        public Nullable<DateTime> DateUpdated { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public Nullable<int> Ord { get; set; }
        [Column(TypeName = "varchar(3500)")]
        public string Description { get; set; }
        public Nullable<DateTime> DateLatest { get; set; }
        public Nullable<int> Sticky { get; set; }
    

    }
}
