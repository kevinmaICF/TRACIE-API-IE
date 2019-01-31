using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TRACIE_API_IE.Models
{
    public class IE_tblUserContactInformation
    {
        [Key]
      
        public int UserContactID { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string UserFirstName { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string UserLastName { get; set; }
  
        [Column(TypeName = "varchar(128)")]
        public string UId { get; set; }

        public System.Nullable<DateTime> DateCreated { get; set; }
        public System.Nullable<DateTime> DateUpdated { get; set; }
        [Column(TypeName = "varchar(10)")]
        public string UserPrefTitle { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string UserPhone1 { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string UserPhone1Ext { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string UserPhone2 { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string UserPhone2Ext { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string UserStreet1 { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string UserStreet2 { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string UserCity { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string UserState { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string UserZIP { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string UserOrg { get; set; }
        [Column(TypeName = "varchar(300)")]
        public string UserTitle { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string UserEmail1 { get; set; }
        [Column(TypeName = "varchar(255)")]
        public string UserEmail2 { get; set; }
        [Column(TypeName = "varchar(1000)")]
        public string UserDisciplineOrProfession { get; set; }
       
        public System.Nullable<bool> Listerv { get; set; }
        public System.Nullable<bool> IEAccess { get; set; }
        [Column(TypeName = "varchar(1000)")]
        public string APIKey { get; set; }
        public System.Nullable<int> Email1Verified { get; set; }
        public System.Nullable<int> Email2Verified { get; set; }
        public System.Nullable<DateTime> DateLogin { get; set; }
        public System.Nullable<bool> NewsletterSubEmail1 { get; set; }
        public System.Nullable<bool> NewsletterSubEmail2 { get; set; }
      
       
    }
}
