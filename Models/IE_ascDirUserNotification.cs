using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TRACIE_API_AC.Models
{
    public class IE_ascDirUserNotification
    {
        [Key]
        public int DirUserNotificationID { get; set; }
        public int UserID { get; set; }
        public int DirID { get; set; }
        public System.DateTime DateCreated { get; set; }
        public int CreatedBy { get; set; }
    }
}