using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TRACIE_API_AC.Models
{
    public class IE_ascThreadUserUnsubscribe
    {
        [Key]
        public int ThreadUserUnsubscribe { get; set; }
        public int ThreadID { get; set; }
        public int UserID { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<int> CreatedBy { get; set; }
    }
}