using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TRACIE_API_IE.Models
{
    public class IE_luNotificationTemplate
    {
        [Key]
        public int NotificationTemplateID { get; set; }
        [Column(TypeName = "varchar(8000)")]
        public string TemplateText { get; set; }
        public string TemplateSubject { get; set; }
        public string TemplateTitle { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<System.DateTime> DateUpdated { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
    }
}
