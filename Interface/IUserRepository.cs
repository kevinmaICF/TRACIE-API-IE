using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TRACIE_API_IE.IEBL;

namespace TRACIE_API_IE.Interface
{
   public interface IUserRepository
   {
        List<UserContactInformationLight> GetAllLight(int userID = 0, int hostServer = 0);
        //int RejectUser(int UserContactID, int StatusID, int RejectedBy = 0, string Notes = "");

        //UserContactInformation GetUserByID(int usercontactid, int hostServer = 0);
        //List<ACUserRejected> GetRejectedIEUser(int usercontactid = 0);
        //List<ACUserPending> GetPendingIEUser(string uid);
        //int GetUserIEStatus(int usercontactid = 0, int hostServer = 0,string uid="");

        //UserLockout UserLockoutInformation(int userID=0, int hostServer = 0);
        bool UpdateUserInformation(UserContactInformation userObject, int userID = 0, int hostServer = 0);
     // bool UserLog_AddEvent(int userID, int eventTypeID, string eventDesc, string eventTitle, int serverID = 0, int entryPointID = 0, int hostServer = 0);

        List<string> GetAllUsersEmail();
        List<int> GetUserRolesByUserName(string userName = "");

        List<UserContactInformation> GetAllUser();
        //int SaveReasonForAccess(string email, string reason, int userID = 0, int hostServer = 0);
        // List<String> GetAllUsersEmailsByscope(int scope, string term);
        UserContactInformation GetUserContactInformationbyName(string userName, int userID = 0, int hostServer = 0);
          UserContactInformation GetUserContactInformationLight(string userName, int userID = 0, int hostServer = 0);
          //UserContactInformationLight GetUserContactInformationLightbyscope(string userName, int scope = 1, int userID = 0, int hostServer = 0);
          UserContactInformationUnregistered GetUnregisteredUserByID(int usercontactid, int hostServer = 0);
          bool UpdateUnregisteredUserInformation(UserContactInformationUnregistered userObject, int userID = 0, int hostServer = 0);
         int DeleteUnregisteredUser(int id = 0, int hostServer = 0, int userID = 0);
    
         //bool MoveTagsUnregToReg(int unregUserID, int userID, int hostServer = 0);
          //bool ResendRegistrationLink(int userID = 0, int hostServer = 0);
          string GetUsercheck(int usercontactID = 0);
          //List<IEUser> GetPendingIEUsers();
          //List<IEUser> GetRejectedIEUsers(int statusID = 0);
        //string PasswordValidationGetToken(string uID, int userID = 0, int hostServer = 0);
          //int ApproveUser(int UserContactID, int RoleID,int UserId, int hostServer = 0);
          //int AddNotification (int UserContactID, int TemplateID);
         //string GetUsersRegisteredWTagFilter(TagFilter tFilter);
         //string GetUsersUnRegisteredWTagFilter(TagFilter tFilter); 
         //string GetUsersAllWTagFilter(TagFilter tFilter);

          int GetUserID(string username="");
        string GetUserUID(string username="");
        int UserIsRegistered(ValVal usr);
        string UpdatePrimaryemail(UserContactInformation userObject, int userID = 0, int hostServer = 0);
       

        //int FailedLoginClear(string username = "", int clearstatusid = 5, int serverid = 0, int entrypointid = 0);
        
       int UnregisteredUserGetID(string emailAddress = "", int hostServer = 0, int userID = 0);

       // string CheckIEUsersStatus(string Useremail = null);
    
    
    }
}
