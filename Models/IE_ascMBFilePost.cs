using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TRACIE_API_IE.Models
{
    public class IE_ascMBFilePost
    {
        [Key]
        public int FilePostID { get; set; }
        public int FileIDNum { get; set; }
        public Nullable<int> PostID { get; set; } 
        public Nullable<DateTime> DateCreated { get; set; }
        public Nullable<int> CreatedBy { get; set; }
    }
} 