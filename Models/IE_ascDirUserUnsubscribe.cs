using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TRACIE_API_IE.Models
{
    public class IE_ascDirUserUnsubscribe
    {
        [Key]
        public int DirUserUnsubscribeeID { get; set; }
        public int UserID { get; set; }
        public int DirID { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<int> CreatedBy { get; set; }
    }
}