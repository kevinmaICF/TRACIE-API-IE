using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TRACIE_API_IE.Models
{
    public class IE_tblLogErr
    {
        [Key]
        public int ErrRecID { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string ErrLocation { get; set; }
        [Column(TypeName = "varchar(2000)")]
        public string ErrMessage { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string ErrTitle { get; set; }
        [Column(TypeName = "varchar(500)")]
        public string ErrDesc { get; set; }
        [Column(TypeName = "varchar(150)")]
        public string ErrVal1 { get; set; }
        [Column(TypeName = "varchar(150)")]
        public string ErrVal2 { get; set; }
        [Column(TypeName = "varchar(150)")]
        public string ErrVal3 { get; set; }
        [Column(TypeName = "varchar(150)")]
        public string ErrVal4 { get; set; }
        [Column(TypeName = "varchar(150)")]
        public string ErrVal5 { get; set; }
        public System.Nullable<DateTime> DateCreated { get; set; }
        public System.Nullable<int> UserID { get; set; }
        public System.Nullable<int> ServerID { get; set; }
        public System.Nullable<int> EventTypeID { get; set; }


    }
}
