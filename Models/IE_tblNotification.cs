using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TRACIE_API_AC.Models
{

    public class IE_tblNotification
    {
        public int NotificationRecID { get; set; }
        public string NotificationAddress { get; set; }
        public string NotificationMessage { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<System.DateTime> DateUpdated { get; set; }
        public Nullable<int> StatusID { get; set; }
        public string NotificationSubject { get; set; }
    }
}
