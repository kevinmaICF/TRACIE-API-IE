using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TRACIE_API_AC.Models
{
    public class IE_tblMBDir
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public IE_tblMBDir()
        {
            this.IE_tblMBThread = new HashSet<IE_tblMBThread>();
        }
    
        public int DirID { get; set; }
        public string Text { get; set; }
        public string TextShort { get; set; }
        public Nullable<int> ParentID { get; set; }
        public Nullable<int> TypeID { get; set; }
        public Nullable<int> StatusID { get; set; }
        public string Path { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<System.DateTime> DateUpdated { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public Nullable<int> Ord { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> DateLatest { get; set; }
        public Nullable<int> Sticky { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IE_tblMBThread> IE_tblMBThread { get; set; }
    }
}
