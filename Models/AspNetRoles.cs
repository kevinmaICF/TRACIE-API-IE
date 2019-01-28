using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TRACIE_API_IE.Models
{
    public class AspNetRoles
    {
        [StringLength(450)]
        public string Id { get; set; }
        
        public string ConcurrencyStamp { get; set; }
        [StringLength(256)]
        public string Name { get; set; }
        [StringLength(256)]
        public string NormalizedName { get; set; }
        
    }
}
