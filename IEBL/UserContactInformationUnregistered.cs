using System;

namespace TRACIE_API_IE.IEBL
{
    public class UserContactInformationUnregistered : BaseViewModel
    {
         public int UserUnregisteredID { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }

        public string UserFullName { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
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
    }
}