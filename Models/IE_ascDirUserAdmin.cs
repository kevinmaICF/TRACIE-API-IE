using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TRACIE_API_IE.Models
{
    public class IE_ascDirUserAdmin
    {
        [Key]
        public int DirUserAdminID { get; set; }
        public int UserID { get; set; }
        public int DirID { get; set; }
        public System.DateTime DateCreated { get; set; }
        public int CreatedBy { get; set; }
    }
}