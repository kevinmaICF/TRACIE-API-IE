using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TRACIE_API_IE.Models
{
    public class AspNetUserTokens
    {
        [Key]

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public AspNetUsers AspNetUsers { get; set; }
        [Key]
        [StringLength(450)]
        public string LoginProvider { get; set; }
        [Key]
        [StringLength(450)]
        public string Name { get; set; }
       
        public string Value { get; set; }

       

    }
}
