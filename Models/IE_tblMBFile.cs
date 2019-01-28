using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TRACIE_API_AC.Models
{
    public class IE_tblMBFile
    {
        public int FileIDNum { get; set; }
        public string FileID { get; set; }
        public string Text { get; set; }
        public string FileName { get; set; }
        public Nullable<int> FileSize { get; set; }
        public string FileMimeType { get; set; }
        public Nullable<int> FileTypeID { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<System.DateTime> DateUpdated { get; set; }
        public int StatusID { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public string FileExtension { get; set; }
    }
}
