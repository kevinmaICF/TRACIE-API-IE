using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TRACIE_API_IE.Models
{

    public class IE_tblNotification
    {
        [Key]
        public int NotificationRecID { get; set; }
        [Column(TypeName = "varchar(500)")]
        public string NotificationAddress { get; set; }
        [Column(TypeName = "varchar(2000)")]
        public string NotificationMessage { get; set; }
        public Nullable<DateTime> DateCreated { get; set; }
        public Nullable<DateTime> DateUpdated { get; set; }
        public Nullable<int> StatusID { get; set; }
        public string NotificationSubject { get; set; }
    }
}
