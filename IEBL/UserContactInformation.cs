using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TRACIE_API_IE.IEBL
{
     public class UserContactInformation : BaseViewModel
    {
        public int UserContactID { get; set; }
        [Display(Name = "First name")]
        public string UserFirstName { get; set; }
        [Display(Name = "Last name")]
        public string UserLastName { get; set; }
        [Display(Name = "Name")]
        public string UserFullName { get; set; }
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public string UserEmailID { get; set; }
        public string UId { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<System.DateTime> DateUpdated { get; set; }
        [Display(Name = "Preferred Title")]
        public string UserPrefTitle { get; set; }
        [Display(Name = "Primary Phone Number")]
        public string UserPhone1 { get; set; }
        [Display(Name = "Extension")]
        public string UserPhone1Ext { get; set; }
        [Display(Name = "Alternate Phone Number")]
        public string UserPhone2 { get; set; }
        [Display(Name = "Extension")]
        public string UserPhone2Ext { get; set; }
        [Display(Name = "Street Address")]
        public string UserStreet1 { get; set; }
        [Display(Name = "Street Address Line 2")]
        public string UserStreet2 { get; set; }
        [Display(Name = "City")]
        public string UserCity { get; set; }
        [Display(Name = "State/Territory")]
        public string UserState { get; set; }
        [Display(Name = "ZIP Code")]
        public string UserZIP { get; set; }
        [Display(Name = "Name of Agency/Entity")]
        public string UserOrg { get; set; }
        [Display(Name = "Title/Position")]
        public string UserTitle { get; set; }
        [Display(Name = "Primary Email")]
        public string UserEmail1 { get; set; }
        [Display(Name = "Alternate Email")]
        public string UserEmail2 { get; set; }
        [Display(Name = "Discipline/Profession")]
        public string UserDisciplineOrProfession { get; set; }

        public bool? IEAccess { get; set; }
        public int? IEAccessStatus { get; set; }
        public int? SMEAccessStatus { get; set; }
        public bool? EmailConfirmed { get; set; }
        public Nullable<System.DateTime> LastLogin { get; set; }
        public string APIKey { get; set; }

        public string Password { get; set; }
        public string selectedroles { get; set; }
        public int? Email1Verified { get; set; }
        public int? Email2Verified { get; set; }

        public bool? NewsletterSubEmail1 { get; set; }
        public bool? NewsletterSubEmail2 { get; set; }
        public DateTime LastActivity { get; set; }
        public List<int> ur { get; set; } = new List<int>();
        public List<string> users { get; set; } = new List<string>();



    }
}