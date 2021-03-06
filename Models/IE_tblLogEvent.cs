using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TRACIE_API_IE.Models
{
    public class IE_tblLogEvent
    {
        [Key]
        public int EventRecID { get; set; }
        public int EventTypeID { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string EventLocation { get; set; }
        [Column(TypeName = "varchar(500)")]
        public string EventDesc { get; set; }
        [Column(TypeName = "varchar(150)")]
        public string EventTitle { get; set; }
        [Column(TypeName = "varchar(150)")]
        public string EventVar1 { get; set; }
        [Column(TypeName = "varchar(150)")]
        public string EventVar2 { get; set; }
        [Column(TypeName = "varchar(150)")]
        public string EventVar4 { get; set; }
        [Column(TypeName = "varchar(150)")]
        public string EventVar5 { get; set; }

        public System.Nullable<DateTime> DateCreated { get; set; }
        public System.Nullable<int> UserID { get; set; }
        public System.Nullable<int> ServerID { get; set; }
        public string EventVar3 { get; set; }
    }
}
