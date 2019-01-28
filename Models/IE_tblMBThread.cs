using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TRACIE_API_AC.Models
{
    public class IE_tblMBThread
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public IE_tblMBThread()
        {
            this.IE_ascThreadUser = new HashSet<IE_ascThreadUser>();
            this.IE_tblMBPost = new HashSet<IE_tblMBPost>();
        }
    
        public int ThreadID { get; set; }
        public Nullable<int> DirID { get; set; }
        public string Text { get; set; }
        public string Title { get; set; }
        public Nullable<int> StatusID { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<System.DateTime> DateUpdated { get; set; }
        public Nullable<int> PostCount { get; set; }
        public Nullable<int> FileCount { get; set; }
        public Nullable<int> TypeID { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public Nullable<System.DateTime> DateLatest { get; set; }
        public string Description { get; set; }
        public Nullable<int> Sticky { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IE_ascThreadUser> IE_ascThreadUser { get; set; }
        public virtual IE_tblMBDir IE_tblMBDir { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IE_tblMBPost> IE_tblMBPost { get; set; }
    }
}
