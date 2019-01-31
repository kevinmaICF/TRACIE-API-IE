using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TRACIE_API_IE.Models
{
    public class IE_tblMBFile
    {
        [Key]        
        public int FileIDNum { get; set; }
        [Column(TypeName = "varchar(128)")]
        public string FileID { get; set; }
        [Column(TypeName = "varchar(250)")]
        public string Text { get; set; }
        [Column(TypeName = "varchar(250)")]
        public string FileName { get; set; }
        public Nullable<int> FileSize { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string FileMimeType { get; set; }
        public Nullable<int> FileTypeID { get; set; }
        public Nullable<DateTime> DateCreated { get; set; }
        public Nullable<DateTime> DateUpdated { get; set; }
        public int StatusID { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        [Column(TypeName = "varchar(10)")]
        public string FileExtension { get; set; }
    }
}
