using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TRACIE_API_AC.Models
{
    public class IE_tblNotificationQueue
    {
        public int NotificationQueueID { get; set; }
        public Nullable<int> NotificationTemplateID { get; set; }
        public Nullable<int> EventTypeID { get; set; }
        public Nullable<int> ThreadID { get; set; }
        public Nullable<int> DirID { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<int> StatusID { get; set; }
        public Nullable<System.DateTime> DateSent { get; set; }
        public Nullable<int> ParentID { get; set; }
    }
}
