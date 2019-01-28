using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TRACIE_API_IE.Models
{
    public class AspNetUserRoles
    {
        [Key]
        [StringLength(450)]
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public AspNetUsers AspNetUsers { get; set; }

        [Key]
        public string RoleId { get; set; }
        [ForeignKey("RoleId")]
        public AspNetRoles AspNetRoles { get; set; }
    }
}
