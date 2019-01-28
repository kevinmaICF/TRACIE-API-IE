using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TRACIE_API_AC.Models
{
    public class IE_luNotificationTemplate
    {
        public int NotificationTemplateID { get; set; }
        public string TemplateText { get; set; }
        public string TemplateSubject { get; set; }
        public string TemplateTitle { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<System.DateTime> DateUpdated { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
    }
}
