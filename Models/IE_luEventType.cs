using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TRACIE_API_IE.Models
{ 
    public class IE_luEventType
    {
        [Key]        
        public int EventTypeID { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string EventTypeText { get; set; }
        public System.DateTime DateCreated { get; set; }
    }
}
