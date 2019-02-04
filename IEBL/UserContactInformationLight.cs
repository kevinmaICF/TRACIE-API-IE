using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
namespace TRACIE_API_IE.IEBL
{
    public class UserContactInformationLight:BaseViewModel
    {
         public int UserContactID { get; set; }
        public string UserFullName { get; set; }

        public string UserFirstName { get; set; }

        public string UserLastName { get; set; }

        public string UserEmailID { get; set; }
        public string UId { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<System.DateTime> DateUpdated { get; set; }

        public string UserPrefTitle { get; set; }

        public string UserPhone1 { get; set; }

        public string UserPhone1Ext { get; set; }

        public string UserPhone2 { get; set; }

        public string UserPhone2Ext { get; set; }

        public string UserStreet1 { get; set; }

        public string UserStreet2 { get; set; }

        public string UserCity { get; set; }

        public string UserState { get; set; }

        public string UserZIP { get; set; }
        public string UserOrg { get; set; }
        public string UserTitle { get; set; }
        public string UserEmail1 { get; set; }
        public string UserEmail2 { get; set; }

        public string UserDisciplineOrProfession { get; set; }
        public bool? IEAccess{get;set;}
        public bool? NewsletterSubEmail1{get;set;} 
        public bool? NewsletterSubEmail2{get;set;}
       public bool? EmailConfirmed {get;set;}
       public DateTime? LastLogin {get;set;}
    }
}