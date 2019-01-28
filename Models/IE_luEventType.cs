using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TRACIE_API_AC.Models
{ 
    public class IE_luEventType
    {
        public int EventTypeID { get; set; }
        public string EventTypeText { get; set; }
        public System.DateTime DateCreated { get; set; }
    }
}
