using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TRACIE_API_IE.Models
{
    public class IE_tblLogEventUser
    {
        [Key]
        public int EventRecID { get; set; }
        public int EventTypeID { get; set; }
        public int UserID { get; set; }
        public string EventDesc { get; set; }
        public string EventTitle { get; set; }
        public DateTime DateCreated { get; set; }
        public int? CreatedBy { get; set; }
        public int? ServerID { get; set; }
        public int? EntryPointID { get; set; }

    }
}
