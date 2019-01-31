using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TRACIE_API_IE.Models
{
    public class IE_tblNotificationQueue
    {
        [Key]
        public int NotificationQueueID { get; set; }
        public Nullable<int> NotificationTemplateID { get; set; }
        public Nullable<int> EventTypeID { get; set; }
        public Nullable<int> ThreadID { get; set; }
        public Nullable<int> DirID { get; set; }
        public Nullable<DateTime> DateCreated { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<int> StatusID { get; set; }
        public Nullable<DateTime> DateSent { get; set; }
        public Nullable<int> ParentID { get; set; }
    }
}
