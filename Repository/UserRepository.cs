using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using TRACIE_API_IE.factorypattern.Interface;
using TRACIE_API_IE.Interface;
using TRACIE_API_IE.Models;
using TRACIE_API_IE.IEBL;
using Microsoft.Extensions.Configuration;

namespace TRACIE_API_IE.Repository
{
    public class UserRepository : Repository<UserContactInformation>, IUserRepository
    {
        private readonly IViewModelFactory _factory;
        private readonly IEventLog _eventlog;
       
         

        /// private readonly ITagRepository _tagRepository;
        public List<UserContactInformation> listuser { get; set; } = new List<UserContactInformation>();
        public List<UserContactInformationLight> listusercontact { get; set; } = new List<UserContactInformationLight>();
        public List<string> users {get;set;} = new List<string>(); 
        public List<string> users1 {get;set;} = new List<string>(); 
        public List<string> users2 {get;set;} = new List<string>(); 
        //public List<IEUser> ieuserpending {get;set;} = new List<IEUser>();
        //   public List<IEUser> ieuserrejected {get;set;} = new List<IEUser>();
        public UserRepository(TracieIEContext context, IViewModelFactory factory,IEventLog log) : base(context)
        {
            _factory = factory;
            _eventlog = log;
           
        


        }
        public List<UserContactInformationLight> GetAllLight(int userID = 0, int hostServer = 0)
        {
            var usersData = from rec in _context.IE_tblUserContactInformation
                            join u in _context.AspNetUsers on rec.UId equals u.ID

                           
                            select new
                            {
                                UserContactID = rec.UserContactID,
                                UId = rec.UId,
                                UserFirstName = rec.UserFirstName,
                                UserLastName = rec.UserLastName,
                                UserPhone1 = rec.UserPhone1,
                                UserOrg = rec.UserOrg,
                                IEAccess = rec.IEAccess,
                                EmailConfirmed = u.EmailConfirmed,
                                NewsletterSubEmail1 = rec.NewsletterSubEmail1,
                                NewsletterSubEmail2 = rec.NewsletterSubEmail2,
                                UserEmail1 = rec.UserEmail1,
                                UserEmail2 = rec.UserEmail2,
                                LastLogin = rec.DateLogin,
                                LastActivity = rec.DateLogin,
                                DateCreated = rec.DateUpdated,
                                DateUpdated = rec.DateUpdated


                            };

            if (usersData != null)
            {
                foreach (var item in usersData)
                {
                    UserContactInformationLight userinfo = _factory.Create<UserContactInformationLight>();
                    userinfo.UserContactID = item.UserContactID;
                    userinfo.UserFullName = item.UserFirstName + " " + item.UserLastName;
                    userinfo.IEAccess = item.IEAccess;
                    userinfo.NewsletterSubEmail1 = item.NewsletterSubEmail1;
                    userinfo.NewsletterSubEmail2 = item.NewsletterSubEmail2;
                   userinfo.EmailConfirmed = item.EmailConfirmed;
                    userinfo.UserPhone1 = item.UserPhone1;
                    userinfo.LastLogin = item.LastLogin;
                    userinfo.UserEmail1 = item.UserEmail1;
                    userinfo.DateCreated = item.DateCreated;
                    userinfo.DateUpdated = item.DateUpdated;
                    listusercontact.Add(userinfo);
                };
            }
            return listusercontact.OrderByDescending(s=>s.LastLogin).ToList();
        }
      
         public UserContactInformation GetUserContactInformationbyName(string userName, int userID = 0, int hostServer = 0)
        {
            UserContactInformation rec = _factory.Create<UserContactInformation>();
            try
            {
                var usr = _context.AspNetUsers.Where(u => u.UserName.ToLower() == userName.ToLower()).FirstOrDefault();
                if(usr!=null)
                {
                    var item = (from c in _context.IE_tblUserContactInformation
                                join u in _context.AspNetUsers on c.UId equals u.ID where c.UId == usr.ID select c).SingleOrDefault();


                    if(item==null)
                    {
                        rec= null;
                    }
                    else
                    {
                            rec.UserContactID = item.UserContactID;
                            rec.UserFirstName = item.UserFirstName;
                            rec.UserLastName = item.UserLastName;
                            rec.UserFullName = item.UserFirstName + " " + item.UserLastName;
                            rec.UId = item.UId;
                            rec.APIKey = item.APIKey;
                            rec.UserEmail1 = item.UserEmail1;
                            rec.UserEmail2 = item.UserEmail2;
                        
                            rec.NewsletterSubEmail1 = item.NewsletterSubEmail1;
                            rec.NewsletterSubEmail2 = item.NewsletterSubEmail2;
                            rec.IEAccess = item.IEAccess;
                            rec.EmailConfirmed = usr.EmailConfirmed;
                    }
                }
                else
                {
                    rec= null;
                }
            }
            catch(Exception ex)
            {

            }
           return rec;
        }


/*
        public UserContactInformation GetUserByID(int usercontactid, int hostServer = 0)
        {
            IE_tblUserContactInformation usersData =  _context.IE_tblUserContactInformation.Where(s => s.UserContactID == usercontactid).SingleOrDefault();
            UserContactInformation userContactInformation = new UserContactInformation()
            {
                UserContactID = usersData.UserContactID,
                UId = usersData.UId,
                UserFirstName = usersData.UserFirstName,
                UserLastName = usersData.UserLastName,
                UserFullName = usersData.UserFirstName + " " + usersData.UserLastName,
                UserEmail1 = usersData.UserEmail1,
                UserEmail2 = usersData.UserEmail2,
                UserPhone1 = usersData.UserPhone1,
                UserPhone1Ext = usersData.UserPhone1Ext,
                UserPhone2 = usersData.UserPhone2,
                UserPhone2Ext = usersData.UserPhone2Ext,
                UserOrg = usersData.UserOrg,
                UserDisciplineOrProfession = usersData.UserDisciplineOrProfession,
                UserCity = usersData.UserCity,
                UserStreet1 = usersData.UserStreet1,
                UserStreet2 = usersData.UserStreet2,
                UserState = usersData.UserState,
                UserZIP = usersData.UserZIP,
                IEAccess = usersData.IEAccess,
                NewsletterSubEmail1 = usersData.NewsletterSubEmail1,
                NewsletterSubEmail2 = usersData.NewsletterSubEmail2,
                Email1Verified = usersData.Email1Verified,
                Email2Verified = usersData.Email2Verified,
                DateCreated = usersData.DateCreated,
                DateUpdated = usersData.DateUpdated,
                IEAccessStatus = GetUserIEStatus(usercontactid, hostServer,usersData.UId),
                EmailConfirmed = (usersData.Email1Verified == null ? false : (usersData.Email1Verified == 1 ? true : false))

            };

            return userContactInformation;
        }


        public int GetUserIEStatus(int usercontactid = 0, int hostServer = 0,string uid="")
        {
            bool? ieStatus = false;
            int status = 0;
            try
            {
                var iestatusobj = _context.IE_tblUserContactInformation.Where(u => u.UserContactID == usercontactid && u.Email1Verified == 1).SingleOrDefault();
                if(iestatusobj != null)
                {
                      ieStatus =  iestatusobj.IEAccess;
                      if(ieStatus == null)
                      {
                            status = checkPendingIEUser(usercontactid,uid);
                      }
                      else 
                      {
                           status =  1;
                      }
                }
              
              
            }
            catch (Exception ex)
            {

            }

            return status;

        }

        public List<ACUserPending> GetPendingIEUser(string uid)
        {
            List<ACUserPending> userpending = new List<ACUserPending>();
            try
            {
                var role = new string[] { "3", "4" };

                var rejecteduser = (from rejectedusers in _context.AC_tblPendingRejectedUser where rejectedusers.StatusID ==8 

                                    select rejectedusers.UserID).ToList();


                var userrolecheck = (from userrolechecks in _context.AspNetUserRoles


                                     select new
                                     {
                                         UserId = userrolechecks.UserId,
                                         RoleId = userrolechecks.RoleId
                                     }).Where(s=>role.Contains(s.RoleId) && s.UserId == uid).ToList().Select(s=>s.UserId).ToList();
               var iependinguser = (from signup in _context.AC_tblAccessSignUp
                                    
                                     join users in _context.AspNetUsers on signup.UserId equals users.ID
                                     join usr in _context.AC_tblUserContactInformation on users.ID equals usr.UId
                                     select new
                                     {
                                         UserId = signup.UserId,
                                         RecID = signup.RecID,
                                         UserContactID = usr.UserContactID,
                                         DateCreated = signup.DateCreated,
                                         SignUpTypeID = signup.SignUpTypeID,
                                         Email = users.Email,
                                         ReasonForAccess = signup.ReasonForAccess,
                                         emailconfirmed = users.EmailConfirmed,
                                         userfirstname = usr.UserFirstName,
                                         userlastname = usr.UserLastName,
                                         userOrg = usr.UserOrg,
                                         StatusID = signup.StatusID
                                        

                                     }).ToList();
                               var   iependinguser1=  iependinguser.Where(c => !rejecteduser.Contains(c.UserContactID) && !userrolecheck.Contains(c.UserId) && c.SignUpTypeID == 2 && c.emailconfirmed == true).ToList();
                foreach(var item in iependinguser1)
                {
                    ACUserPending userpendinglist = _factory.Create<ACUserPending>();
                    userpendinglist.UserContactID = item.UserContactID;
                    userpendinglist.DateCreated = item.DateCreated;
                    userpendinglist.RecID = item.RecID;
                    userpendinglist.SignUpTypeID = item.SignUpTypeID;
                    userpendinglist.Email = item.Email;
                    userpendinglist.emailconfirmed = item.emailconfirmed;
                    userpendinglist.ReasonForAccess = item.ReasonForAccess;
                    userpendinglist.userfirstname = item.userfirstname;
                    userpendinglist.userlastname = item.userlastname;
                    userpendinglist.userOrg = item.userOrg;
                    userpendinglist.StatusID = item.StatusID;
                    userpendinglist.UserId = item.UserId;
                    userpending.Add(userpendinglist);

                }
            }
            catch (Exception ex)
            {

            }
            return userpending;
        }

        public int checkPendingIEUser(int ucontactid,string uid)
        {
            int IEstatus = 0;
            try
            {

              
                 var roles = new string[] { "3", "4" };
                
                var rejecteduser = (from rejectedusers in _context.AC_tblPendingRejectedUser where rejectedusers.StatusID == 8 && rejectedusers.UserID  == ucontactid

                                    select rejectedusers).FirstOrDefault();
                if(rejecteduser == null)
                {
                     
                          var iependinguser = (from signup in _context.AC_tblAccessSignUp join role in _context.AspNetUserRoles on signup.UserId equals role.UserId
                                                where signup.UserId == uid && signup.SignUpTypeID == 2 && !roles.Contains(role.RoleId)
                                                select signup);
                                                
                           if(iependinguser !=null)
                           {
                               IEstatus = 2;
                           }       
                 
               
                }
                else
                {
                    IEstatus = 3;
                }


            }
            catch(Exception ex)
            {

            }
            return IEstatus;
        }

        public List<ACUserRejected> GetRejectedIEUser(int usercontactid = 0)
        {
            List<ACUserRejected> userrejected = new List<ACUserRejected>();
            try
            {
                var ierejecteduser = (from signup in _context.AC_tblAccessSignUp

                                      join users in _context.AspNetUsers on signup.UserId equals users.ID
                                      join usr in _context.AC_tblUserContactInformation on users.ID equals usr.UId
                                      join rejecteduser in _context.AC_tblPendingRejectedUser on usr.UserContactID equals rejecteduser.UserID
                                      select new
                                      {
                                          UserId = signup.UserId,
                                          RecID = signup.RecID,
                                          UserContactID = usr.UserContactID,
                                          DateCreated = signup.DateCreated,
                                          SignUpTypeID = signup.SignUpTypeID,
                                          Email = users.Email,
                                          ReasonForAccess = signup.ReasonForAccess,
                                          emailconfirmed = users.EmailConfirmed,
                                          userfirstname = usr.UserFirstName,
                                          userlastname = usr.UserLastName,
                                          userOrg = usr.UserOrg,
                                          StatusID = signup.StatusID

                                      }).Where(s => s.emailconfirmed == true);
                                      foreach (var item in ierejecteduser)
                                      {
                                         ACUserRejected userrejected1 = _factory.Create<ACUserRejected>();
                                         userrejected1.UserId = item.UserId;
                                         userrejected1.Email = item.Email;
                                         userrejected1.RecID = item.RecID;
                                         userrejected1.UserContactID = item.UserContactID;
                                         userrejected1.DateCreated = item.DateCreated;
                                         userrejected1.SignUpTypeID = item.SignUpTypeID;
                                         userrejected1.ReasonForAccess = item.ReasonForAccess;
                                         userrejected1.emailconfirmed = item.emailconfirmed;
                                         userrejected1.userfirstname = item.userfirstname;
                                         userrejected1.userlastname = item.userlastname;
                                         userrejected1.userOrg = item.userOrg;
                                         userrejected1.StatusID = item.StatusID;
                                         userrejected.Add(userrejected1);

                                      }
            }
            catch (Exception ex)
            {

            }
            return userrejected;
        }
        public UserLockout UserLockoutInformation(int userID=0, int hostServer = 0)
        {
            UserLockout userLockout = _factory.Create<UserLockout>();


            string uid = GetUsercheck(userID);
            if ( !string.IsNullOrEmpty(uid))
            {

                var Rec = (from rec in _context.AspNetUsers
                           where rec.ID == uid
                           select rec).SingleOrDefault();
                if (Rec != null)
                {
                    userLockout.AccessFailedCount = Rec.AccessFailedCount;
                    userLockout.Email = Rec.Email;
                    userLockout.LockoutEnabled = Rec.LockoutEnabled;
                    userLockout.UserID = userID;
                    userLockout.UserName = Rec.UserName;
                    userLockout.LockoutEndDateUtc = Rec.LockoutEnd;
                }
            }
            return userLockout;

        }
        */


        public bool UpdateUserInformation(UserContactInformation userObject, int userID = 0, int hostServer = 0)
        {
            var result = false;
            var usercontactEntity = _context.IE_tblUserContactInformation.SingleOrDefault(u => u.UserContactID == userObject.UserContactID);
            if (userObject != null || usercontactEntity != null)
            {
                usercontactEntity.UserFirstName = userObject.UserFirstName;
                usercontactEntity.UserLastName = userObject.UserLastName;
                usercontactEntity.UserTitle = userObject.UserTitle;
                usercontactEntity.UserPrefTitle = userObject.UserPrefTitle;
                usercontactEntity.UserOrg = userObject.UserOrg;
                usercontactEntity.UserPhone1 = userObject.UserPhone1;
                usercontactEntity.UserPhone1Ext = userObject.UserPhone1Ext;
                usercontactEntity.UserPhone2 = userObject.UserPhone2;
                usercontactEntity.UserPhone2Ext = userObject.UserPhone2Ext;
                usercontactEntity.UserEmail2 = userObject.UserEmail2;
                usercontactEntity.UserStreet1 = userObject.UserStreet1;
                usercontactEntity.UserStreet2 = userObject.UserStreet2;
                usercontactEntity.UserCity = userObject.UserCity;
                usercontactEntity.UserState = userObject.UserState;
                usercontactEntity.UserZIP = userObject.UserZIP;
                usercontactEntity.DateUpdated = DateTime.Now;
                _context.SaveChanges();
                result = true;
            }
            _eventlog.UserLog_AddEvent(usercontactEntity.UserContactID, 10, "User Information Updated", "User Updated", hostServer);
        
            return result;
        }

      

        public List<string> GetAllUsersEmail()
        {
           
            try
            {
                var query = from u in _context.IE_tblUserContactInformation
                            orderby u.UserLastName
                            select u;


                foreach (var value in query)
                {
                    users.Add(value.UserLastName + ", " + value.UserFirstName + "<" + value.UserEmail1 + ">");
                }
            }
            catch (Exception ex)
            {

            }
            return users;
        }

        public List<int> GetUserRolesByUserName(string userName = "")
        {
            List<int> userRoleIDs = new List<int>();
            try
            {
                var userroles = (from roles in _context.AspNetUserRoles
                                 join user in _context.IE_tblUserContactInformation
                                 on roles.UserId equals user.UId
                                 orderby (roles.RoleId)
                                 where user.UserEmail1 == userName
                                 select roles);
                if (userroles != null)
                {
                    foreach (var rec in userroles)
                    {
                        userRoleIDs.Add(int.Parse(rec.RoleId));
                    }
                }
            }
            catch (Exception e)
            {

            }
            return userRoleIDs;

        }

        public List<UserContactInformation> GetAllUser()
        {

            var usersData = from rec in _context.IE_tblUserContactInformation
                            join u in _context.AspNetUsers on rec.UId equals u.ID

                            orderby rec.DateLogin, rec.UserContactID descending
                            select new
                            {
                                UserContactID = rec.UserContactID,
                                UId = rec.UId,
                                UserFirstName = rec.UserFirstName,
                                UserLastName = rec.UserLastName,
                                UserPhone1 = rec.UserPhone1,
                                UserOrg = rec.UserOrg,
                                IEAccess = rec.IEAccess,
                                EmailConfirmed = u.EmailConfirmed,
                                NewsletterSubEmail1 = rec.NewsletterSubEmail1,
                                NewsletterSubEmail2 = rec.NewsletterSubEmail2,
                                UserEmail1 = rec.UserEmail1,
                                UserEmail2 = rec.UserEmail2,
                                LastLogin = rec.DateLogin,
                                LastActivity = rec.DateLogin,
                                DateCreated = rec.DateUpdated,
                                DateUpdated = rec.DateUpdated


                            };

            if (usersData != null)
            {
                foreach (var item in usersData)
                {
                    UserContactInformation userinfo = _factory.Create<UserContactInformation>();
                    userinfo.UserContactID = item.UserContactID;
                    userinfo.UserFullName = item.UserFirstName + " " + item.UserLastName;
                    userinfo.IEAccess = item.IEAccess;
                    userinfo.NewsletterSubEmail1 = item.NewsletterSubEmail1;
                    userinfo.NewsletterSubEmail2 = item.NewsletterSubEmail2;
                    userinfo.EmailConfirmed = item.EmailConfirmed;
                    userinfo.UserPhone1 = item.UserPhone1;
                    userinfo.LastLogin = item.LastLogin;
                    userinfo.UserEmail1 = item.UserEmail1;
                    userinfo.DateCreated = item.DateCreated;
                    userinfo.DateUpdated = item.DateUpdated;
                    listuser.Add(userinfo);
                };
            }
            return listuser;
        }

/*
        public int SaveReasonForAccess(string email, string reason, int userID = 0, int hostServer = 0)
        {
              int result = 0;
              try{
                  var user = _context.AC_tblUserContactInformation.ToList().Where(s=>s.UserEmail1==email).SingleOrDefault();


                AC_tblAccessSignUp accesssignup = new AC_tblAccessSignUp();
              accesssignup.UserId = user.UId;
              accesssignup.ReasonForAccess = reason;
               accesssignup.StatusID = 1;
                accesssignup.DateCreated = DateTime.Now;
               accesssignup.DateUpdated = DateTime.Now;
                _context.AC_tblAccessSignUp.Add(accesssignup);
                _context.SaveChanges();

                AC_tblNotificationmaster master = new AC_tblNotificationmaster();
                master.ProcedureName = "AC_User_EmailRegistrationNotification";
                master.Priority = "10sec";
                master.StatusId = 1;
                _context.AC_tblNotificationmaster.Add(master);
                 _context.SaveChanges();
                result= 1;
              }
              catch(Exception ex){

              }
              return result;
        }

        public List<string> GetAllUsersEmailsByscope(int scope, string term)
        {
             int count1 = 0;
              try{
             var query = (from u in _context.AC_tblUserContactInformation where u.UserFirstName.ToLower().Contains(term.ToLower()) || u.UserLastName.ToLower().Contains(term.ToLower()) || u.UserEmail1.ToLower().Contains(term.ToLower())
                           orderby u.UserLastName select u);

                foreach (var item in query)
                {
                    users1.Add(item.UserLastName + ", " + item.UserFirstName + "<" + item.UserEmail1 + ">");   
                    count1++;            
                }
            if(scope>=2)
            {
                  int count2 = 0; 
                  var query2 = _context.AC_tblContact
                            .Where(x => x.FirstName.ToLower().Contains(term.ToLower()) 
                                     || x.LastName.ToLower().Contains(term.ToLower())
                                     || x.EmailAddress.ToLower().Contains(term.ToLower()))
                            .GroupBy(x => new { x.FirstName, x.LastName, x.EmailAddress }).Select(x => x.FirstOrDefault());
                            foreach (var item1 in query2)
                            {
                                if (!string.IsNullOrEmpty(item1.EmailAddress ))
                                {
                                        count2++;
                                        users2.Add(item1.LastName + ", " + item1.FirstName + "<" + item1.EmailAddress + ">");
                                }
                            }

                            if (count2 > 0)
                            {
                                        if (count1 > 0)
                                        {
                                            var merged = users1.Union(users2); 
                                            users = merged.ToList();
                                        }
                                        else
                                        {
                                            users = users2;
                                        }
                            }
                            else
                            {
                                users = users1;
                            }
            }
            else
            {
                users = users1;
            }
              }catch(Exception ex)
              {

              }
              return users;
        }
        */


        public UserContactInformation GetUserContactInformationLight(string userName, int userID = 0, int hostServer = 0)
        {
            UserContactInformation rec = _factory.Create<UserContactInformation>();
            try
            {
                var usr = _context.AspNetUsers.Where(u => u.UserName.ToLower() == userName.ToLower()).FirstOrDefault();
                if(usr!=null)
                {
                    var item = (from c in _context.IE_tblUserContactInformation
                                join u in _context.AspNetUsers on c.UId equals u.ID where c.UId == usr.ID select c).SingleOrDefault();


                    if(item==null)
                    {
                        rec= null;
                    }
                    else
                    {
                            rec.UserContactID = item.UserContactID;
                            rec.UserFirstName = item.UserFirstName;
                            rec.UserLastName = item.UserLastName;
                            rec.UserFullName = item.UserFirstName + " " + item.UserLastName;
                            rec.DateCreated = item.DateCreated;
                            rec.DateUpdated = item.DateUpdated;
                            rec.UserPrefTitle = item.UserPrefTitle;
                            rec.UserPhone1 = item.UserPhone1;
                            rec.UserPhone1Ext = item.UserPhone1Ext;
                            rec.UserPhone2 = item.UserPhone2;
                            rec.UserPhone2Ext = item.UserPhone2Ext;
                            rec.UserStreet1 = item.UserStreet1;
                            rec.UserStreet2 = item.UserStreet2;
                            rec.UserCity = item.UserCity;
                            rec.UserState = item.UserState;
                            rec.UserZIP = item.UserZIP;
                            rec.UserOrg = item.UserOrg;
                            rec.UserTitle = item.UserTitle;
                            rec.UserEmail1 = item.UserEmail1;
                            rec.UserEmail2 = item.UserEmail2;
                            rec.UserDisciplineOrProfession = item.UserDisciplineOrProfession;
                            rec.NewsletterSubEmail1 = item.NewsletterSubEmail1;
                            rec.NewsletterSubEmail2 = item.NewsletterSubEmail2;
                            rec.IEAccess = item.IEAccess;
                            rec.EmailConfirmed = usr.EmailConfirmed;
                    }
                }
                else
                {
                    rec= null;
                }
            }
            catch(Exception ex)
            {

            }
           return rec;
        }
/*
        public UserContactInformationLight GetUserContactInformationLightbyscope(string userName, int scope = 1, int userID = 0, int hostServer = 0)
        {
           UserContactInformationLight rec = _factory.Create<UserContactInformationLight>();
           try
           {
               var item = (from c in _context.IE_tblUserContactInformation where c.UserEmail1.ToLower() == userName.ToLower() select c).FirstOrDefault();
               if(item!=null)
               {
                     rec.UserContactID = item.UserContactID;
                        rec.UserFullName = item.UserFirstName + " " + item.UserLastName;
                        rec.UserFirstName = item.UserFirstName;
                        rec.UserLastName = item.UserLastName;
                        rec.DateCreated = item.DateCreated;
                        rec.DateUpdated = item.DateUpdated;
                        rec.UserPrefTitle = item.UserPrefTitle;
                        rec.UserPhone1 = item.UserPhone1;
                        rec.UserPhone1Ext = item.UserPhone1Ext;
                        rec.UserPhone2 = item.UserPhone2;
                        rec.UserPhone2Ext = item.UserPhone2Ext;
                        rec.UserStreet1 = item.UserStreet1;
                        rec.UserStreet2 = item.UserStreet2;
                        rec.UserCity = item.UserCity;
                        rec.UserState = item.UserState;
                        rec.UserZIP = item.UserZIP;
                        rec.UserOrg = item.UserOrg;
                        rec.UserTitle = item.UserTitle;
                        rec.UserEmail1 = item.UserEmail1;
                        rec.UserEmail2 = item.UserEmail2;
                        rec.UserDisciplineOrProfession = item.UserDisciplineOrProfession;
               }
                 if (scope > 1)
                    {
                        var itemAC = (from c in _context.AC_tblContact
                                      where c.EmailAddress.ToLower() == userName.ToLower()
                                      select c).FirstOrDefault();

                        if (itemAC != null)
                        {

                            rec.UserContactID = 0;
                            rec.UserFullName = itemAC.FirstName + " " + itemAC.LastName;
                            rec.UserFirstName = itemAC.FirstName;
                            rec.UserLastName = itemAC.LastName;
                            rec.DateCreated = itemAC.DateCreated;
                            rec.DateUpdated = itemAC.DateUpdated;
                            rec.UserPrefTitle = itemAC.PreferredTitle;
                            rec.UserPhone1 = itemAC.Phone1;
                            rec.UserPhone1Ext = itemAC.PhoneExt1;
                            rec.UserPhone2 = itemAC.Phone2;
                            rec.UserPhone2Ext = itemAC.PhoneExt2;
                            rec.UserStreet1 = itemAC.Street1;
                            rec.UserStreet2 = itemAC.Street2;
                            rec.UserCity = itemAC.City;
                            rec.UserState = itemAC.State;
                            rec.UserZIP = itemAC.ZIP;
                            rec.UserOrg = itemAC.Organization;
                            rec.UserTitle = itemAC.TitlePosition;
                            rec.UserEmail1 = itemAC.EmailAddress;
                            rec.UserEmail2 = "";
                            rec.UserDisciplineOrProfession = "";
                        }
                    }

           }
           catch(Exception ex)
           {

           }
           return rec;
        }
*/

        public UserContactInformationUnregistered GetUnregisteredUserByID(int usercontactid, int hostServer = 0)
        {
            UserContactInformationUnregistered userunregistered = _factory.Create<UserContactInformationUnregistered>();
            try
            {
                var user = _context.IE_tblUserContactInformationUnregistered.Where(s=>s.UserUnregisteredID == usercontactid).SingleOrDefault();
                if(user !=null)
                {
                    userunregistered.UserUnregisteredID = user.UserUnregisteredID;
                    userunregistered.UserFirstName= user.UserFirstName;
                    userunregistered.UserLastName = user.UserLastName;
                    userunregistered.UserFullName = user.UserFirstName + " " + user.UserLastName;
                    userunregistered.UserEmail1 = user.UserEmail1;
                    userunregistered.UserEmail2 = user.UserEmail2;
                    userunregistered.UserPhone1 = user.UserPhone1;
                    userunregistered.UserPhone1Ext = user.UserPhone1Ext;
                    userunregistered.UserPhone2 = user.UserPhone2;
                    userunregistered.UserPhone2Ext = user.UserPhone2Ext;
                    userunregistered.UserOrg = user.UserOrg;
                    userunregistered.UserDisciplineOrProfession = user.UserDisciplineOrProfession;
                    userunregistered.UserCity = user.UserCity;
                    userunregistered.UserStreet1 = user.UserStreet1;
                    userunregistered.UserStreet2 = user.UserStreet2;
                    userunregistered.UserState = user.UserState;
                    userunregistered.UserZIP = user.UserZIP;
                    userunregistered.DateCreated = user.DateCreated;
                    userunregistered.DateUpdated = user.DateUpdated;
                }
            }
            catch(Exception ex)
            {

            }
            return userunregistered;
        }

        public bool UpdateUnregisteredUserInformation(UserContactInformationUnregistered userObject, int userID = 0, int hostServer = 0)
        {
             var result = false;
             try
             {
                 var unregistereduser = _context.IE_tblUserContactInformationUnregistered.Where(s=>s.UserUnregisteredID==userObject.UserUnregisteredID).SingleOrDefault();
                 if(unregistereduser!=null)
                 {
                        unregistereduser.DateUpdated = DateTime.Now;
                        unregistereduser.UserDisciplineOrProfession = userObject.UserDisciplineOrProfession;
                        unregistereduser.UserFirstName = userObject.UserFirstName;
                        unregistereduser.UserLastName = userObject.UserLastName;
                        unregistereduser.UserOrg = userObject.UserOrg;
                        unregistereduser.UserPhone1 = userObject.UserPhone1;
                        _context.SaveChanges();
                        result = true;
                 }
                    _eventlog.UserLog_AddEvent(userObject.UserUnregisteredID, 2, "Unregistered User Contact Information Updated", "Unregistered User Updated", hostServer);
               
             }
             catch(Exception ex)
             {

             }
             return result;
        }

    /*
    public bool UserLog_AddEvent(int userID, int eventTypeID, string eventDesc, string eventTitle, int serverID = 0, int entryPointID = 0, int hostServer = 0)
            {
                bool result = true;
                    try
                {
                    AC_tblLogEventUser ul = new AC_tblLogEventUser();
                    ul.UserID = userID;
                    ul.EventTypeID = eventTypeID;
                    ul.DateCreated = DateTime.Now;
                    ul.CreatedBy = userID;
                    ul.EventDesc = eventDesc;
                    ul.EventTitle = eventTitle;
                    ul.ServerID = serverID;
                    ul.EntryPointID = entryPointID;
                    _context.AC_tblLogEventUser.Add(ul);
                    _context.SaveChanges();
                    // record latest login date if it's a login event
                    if (ul.EventTypeID == 5)
                    {
                    
                            var usr = _context.AC_tblUserContactInformation.Where(u => u.UserContactID == userID).SingleOrDefault();
                            if (usr != null)
                            {
                                usr.DateLogin = ul.DateCreated;
                                _context.SaveChanges();
                            }
                    
                    }
                    result = true;
                }
                catch(Exception ex)
                {

                }
                return result;
            }
        */


        public int DeleteUnregisteredUser(int id = 0, int hostServer = 0, int userID = 0)
        {
            int result = 0;
            try
            {
                var dbrec = _context.IE_tblUserContactInformationUnregistered.FirstOrDefault(a=>a.UserUnregisteredID == id);
                if(dbrec !=null)
                {
                    _context.IE_tblUserContactInformationUnregistered.Remove(dbrec);
                    _context.SaveChanges();
                    result = 1;
                }
            }
            catch(Exception ex)
            {

            }
            return result;
        }

        /*
        public bool MoveTagsUnregToReg(int unregUserID, int userID, int hostServer = 0)
        {
           bool result = false;
           try
           {
                var unregtags = (from u in _context.AC_ascUserTagUnregistered
                                  where u.UnregisteredUserID == unregUserID
                                select u).ToList();
                        foreach (var item in unregtags)
                        {
                            AC_ascUserTag regt = new AC_ascUserTag();
                            regt.CreatedBy = item.CreatedBy;
                            regt.DateCreated = DateTime.UtcNow;
                            
                            regt.TagID = item.TagID;
                            regt.UserID = userID;
                            _context.AC_ascUserTag.Add(regt);
                           
                        }
                         _context.SaveChanges();
                         result= true;

                         _context.AC_ascUserTagUnregistered.RemoveRange(_context.AC_ascUserTagUnregistered.Where(c => c.UnregisteredUserID == unregUserID));
                         _context.SaveChanges();
                         result= true;
           }
            catch(Exception ex)
            {

            }
            return result;
        }
        */

        public int GenerateNumber(int numLength)
        {
            Random random = new Random();
            string r = "";
            int i;
            for (i = 1; i <= numLength; i++)
            {
                r += random.Next(1, 9).ToString();
            }
            return int.Parse(r);
        }

/*
        public bool ResendRegistrationLink(int userID = 0, int hostServer = 0)
        {
            var result = false;
            DateTime dtDate = DateTime.Now;
            try
            {
                var query = (from c in _context.AC_tblUserContactInformation where c.UserContactID == userID orderby c.DateCreated descending select c).FirstOrDefault();
                  string encryptedId = null;
                    if (query != null)
                    {
                        encryptedId = query.UId;
                    }
                      var query2 = (from c in _context.AC_tblAccessSignUp
                                  where c.UserId == encryptedId
                                  orderby c.DateCreated descending
                                  select c).FirstOrDefault();

                    if (query2 != null)
                    {
                        query2.StatusID = 1;
                        query2.DateUpdated = DateTime.Now;
                        query2.ValidationKey=GenerateNumber(5);
                    }
            
                    _context.SaveChanges();
                      _eventlog.UserLog_AddEvent(userID, 8, "Successfully re-sent email verification", "Resend Registration Link", hostServer);
               

                    result= true;
            }
            catch(Exception ex)
            {

            }
            return result;
        }



        public List<IEUser> GetPendingIEUsers()
        {
         
            try
            {
                var role = new string[] { "3", "4" };


            var rejecteduser = (from rejectedusers in _context.AC_tblPendingRejectedUser where rejectedusers.StatusID == 7 || rejectedusers.StatusID == 8

                                    select rejectedusers.UserID);




             var iependinguser  = (from signup in _context.AC_tblAccessSignUp
                                     join ur in _context.AspNetUsers on signup.UserId equals ur.ID
                                        join urr in _context.AspNetUserRoles on signup.UserId equals urr.UserId
                                 join acu in _context.AC_tblUserContactInformation on signup.UserId equals acu.UId
                             
                                  where !role.Contains(urr.RoleId) && signup.SignUpTypeID == 2 && ur.EmailConfirmed == true && acu.IEAccess == null && !rejecteduser.Contains(acu.UserContactID)
                                     select new
                                     {
                                        UserId = signup.UserId,
                                         RecID = signup.RecID,
                                         UserContactID = acu.UserContactID,
                                        DateCreated = signup.DateCreated,
                                         SignUpTypeID = signup.SignUpTypeID,
                                         Email = ur.Email,
                                         ReasonForAccess = signup.ReasonForAccess,
                                         emailconfirmed = ur.EmailConfirmed,
                                         userfirstname = acu.UserFirstName,
                                         userlastname = acu.UserLastName,
                                         userOrg = acu.UserOrg,
                                         StatusID = signup.StatusID
                                        

                                     }).ToList().Distinct();
                foreach(var item in iependinguser)
                {
                    IEUser userpendinglist = _factory.Create<IEUser>();
                    userpendinglist.UserContactID = item.UserContactID;
                    userpendinglist.DateCreated = item.DateCreated;
                    userpendinglist.UserFirstName = item.userfirstname;
                    userpendinglist.UserLastName = item.userlastname;
                    userpendinglist.ReasonForAccess = item.ReasonForAccess;
                    userpendinglist.DateCreated = item.DateCreated;
                    userpendinglist.StatusID = item.StatusID;
                   userpendinglist.UserOrg = item.userOrg;
                    userpendinglist.UserEmail1  = item.Email;
                    ieuserpending.Add(userpendinglist);

                }
            }
            catch (Exception ex)
            {

            }
            return ieuserpending.ToList().OrderBy(s=>s.DateCreated).ToList();
        }
   
        public List<IEUser> GetRejectedIEUsers(int statusID = 0)
      {
  
            try
            {
                var ierejecteduser = (from signup in _context.AC_tblAccessSignUp

                                      join users in _context.AspNetUsers on signup.UserId equals users.ID
                                      join usr in _context.AC_tblUserContactInformation on users.ID equals usr.UId
                                      join rejecteduser in _context.AC_tblPendingRejectedUser on usr.UserContactID equals rejecteduser.UserID
                                      select new
                                      {
                                          UserId = signup.UserId,
                                          RecID = signup.RecID,
                                          UserContactID = usr.UserContactID,
                                          DateCreated = signup.DateCreated,
                                          SignUpTypeID = signup.SignUpTypeID,
                                          Email = users.Email,
                                          ReasonForAccess = signup.ReasonForAccess,
                                          emailconfirmed = users.EmailConfirmed,
                                          userfirstname = usr.UserFirstName,
                                          userlastname = usr.UserLastName,
                                          userOrg = usr.UserOrg,
                                          StatusID = rejecteduser.StatusID

                                      }).Where(s => s.emailconfirmed == true);
                                      foreach (var value in ierejecteduser)
                                      {
                                         IEUser userrejected1 = _factory.Create<IEUser>();
                                        userrejected1.UserContactID = value.UserContactID;
                                        userrejected1.UserFirstName = value.userfirstname;
                                        userrejected1.UserLastName = value.userlastname;
                                        userrejected1.DateCreated = value.DateCreated;
                                        userrejected1.ReasonForAccess = value.ReasonForAccess;
                                        userrejected1.UserEmail1 = value.Email;
                                        userrejected1.UserOrg = value.userOrg;
                                        userrejected1.StatusID = value.StatusID;
                                         ieuserrejected.Add(userrejected1);

                                      }
            }
            catch (Exception ex)
            {

            }
            return ieuserrejected.ToList().Where(s=>s.StatusID== (statusID == 0 ? s.StatusID : statusID)).ToList().OrderBy(s=>s.DateCreated).ToList();

      }

        public int ApproveUser(int UserContactID, int RoleID,int ApprovedBy = 0, int hostServer = 0)
        {
            int result = 0;
            try
            {
                AC_tblDashboardNotification notification = new AC_tblDashboardNotification();
                notification.UserContactId = UserContactID;
                notification.NotificationStatusId = 3;
                notification.StatusId = 1;
                notification.DateCreated = DateTime.Now;
                notification.CreatedBy = ApprovedBy;
                notification.UpdatedBy = ApprovedBy;
                notification.DateUpdated = DateTime.Now;
                _context.AC_tblDashboardNotification.Add(notification);
                _context.SaveChanges();
                AC_tblNotificationmaster masternoti = new AC_tblNotificationmaster();
                masternoti.ProcedureName = "AC_DashboardNotification";
                masternoti.Priority = "10sec";
                masternoti.StatusId =  1;
                masternoti.description = "for approve IE Request and reject IE request Notification for users";
                _context.AC_tblNotificationmaster.Add(masternoti);
                _context.SaveChanges();

                              
            }
            catch(Exception ex)
            {
                result=0; 
            }
            return result;
        }

        public int RejectUser(int UserContactID, int StatusID, int RejectedBy = 0, string Notes = "")
        {
             int result=0;
            try
            {
                 AC_tblDashboardNotification notification = new AC_tblDashboardNotification();
                notification.UserContactId = UserContactID;
                notification.NotificationStatusId = StatusID;
                notification.StatusId = 1;
                notification.DateCreated = DateTime.Now;
                notification.CreatedBy = RejectedBy;
                notification.UpdatedBy = RejectedBy;
                notification.DateUpdated = DateTime.Now;
                _context.AC_tblDashboardNotification.Add(notification);
                _context.SaveChanges();
                AC_tblNotificationmaster masternoti = new AC_tblNotificationmaster();
                masternoti.ProcedureName = "AC_DashboardNotification";
                masternoti.Priority = "10sec";
                masternoti.StatusId =  1;
                masternoti.description = "for approve  and reject IE request Notification for users";
                _context.AC_tblNotificationmaster.Add(masternoti);
                _context.SaveChanges();
            }
            catch(Exception ex)
            {

            }
            return result;
        }

        public int AddNotification(int UserContactID, int TemplateID)
        {
             int result = 0;
             try
             {
                   var user = (from u in _context.AC_tblUserContactInformation where u.UserContactID == UserContactID select u).FirstOrDefault();
                   if(user!=null && user.UserEmail1!=null)
                   {
                        var template = (from t in _context.AC_luNotificationTemplate
                                       where t.NotificationTemplateID == TemplateID select t).FirstOrDefault();
                        if(template!=null)
                        {
                            AC_tblNotification tblNotification = new AC_tblNotification();
                            tblNotification.NotificationAddress = user.UserEmail1;
                            tblNotification.NotificationMessage = template.TemplateText.Replace("[First Name]", user.UserFirstName);
                            tblNotification.NotificationMessage = tblNotification.NotificationMessage.Replace("[Last Name]", user.UserLastName);
                            tblNotification.NotificationSubject = template.TemplateSubject;
                            tblNotification.DateCreated = DateTime.Now;
                            tblNotification.StatusID = 1;
                            _context.AC_tblNotification.Add(tblNotification);
                            _context.SaveChanges();
                            AC_tblNotificationmaster master = new AC_tblNotificationmaster();
                            master.ProcedureName ="AC_IESignup_Notification";
                            master.Priority = "10sec";
                            master.StatusId = 1;
                            master.description ="for IE request";
                            _context.AC_tblNotificationmaster.Add(master);
                            _context.SaveChanges();

                            result = tblNotification.NotificationRecID;
                        }
                   }
                result=1;
             }
             catch(Exception ex)
             {
                   result=1; 
             }
            return result;
        }

        public string GetUsersRegisteredWTagFilter(TagFilter tFilter)
        {
            string result="";
            try
            {
                var query = (from ut in _context.AC_ascUserTag 
                            join u in _context.AC_tblUserContactInformation on ut.UserID equals u.UserContactID
                            where tFilter.TagIDList.Contains(ut.TagID.ToString())
                            orderby u.UserFirstName
                            select u).Distinct();
                            foreach(var value in query)
                            {
                                if(!string.IsNullOrEmpty(value.UserEmail1))
                                {
                                     if(value.NewsletterSubEmail1!=null && (bool)value.NewsletterSubEmail1)
                                     {
                                         if(result.Length > 0)
                                         {
                                              result += ";";
                                         }
                                         result += value.UserEmail1;
                                     }   
                                }
                                if(!string.IsNullOrEmpty(value.UserEmail2))
                                {
                                      if (value.NewsletterSubEmail2!=null && (bool)value.NewsletterSubEmail2)
                                        {
                                            if (result.Length > 0)
                                            {
                                                result += ";";
                                            }
                                            result += value.UserEmail2;
                                        }
                                }
                            }
            }
            catch(Exception ex)
            {
                result="";
            }
            return result;
        }

        public string GetUsersUnRegisteredWTagFilter(TagFilter tFilter)
        {
             string result = "";
             try
             {
                  var query = (from ut in _context.AC_ascUserTagUnregistered
                                 join u in _context.AC_tblUserContactInformationUnregistered on ut.UnregisteredUserID equals u.UserUnregisteredID 
                                 where tFilter.TagIDList.Contains(ut.TagID.ToString())
                                 orderby u.UserLastName
                                 select u).Distinct();
                    foreach (var value in query)
                    {
                        if (!string.IsNullOrEmpty(value.UserEmail1))
                        {
                            if ( (bool)value.NewsletterSubEmail1)
                            {
                                if (result.Length > 0)
                                {
                                    result += ";";
                                }
                                result += value.UserEmail1;
                            }
                        }
                    }



             }
             catch(Exception ex)
             {

             }
             return result;
        }

        public string GetUsersAllWTagFilter(TagFilter tFilter)
        {
              string result = "";
              try
              {
                      var query1 = (from ut in _context.AC_ascUserTag
                                 join u in _context.AC_tblUserContactInformation on ut.UserID equals u.UserContactID
                                 where tFilter.TagIDList.Contains(ut.TagID.ToString())
                                 orderby u.UserLastName
                                 select u).Distinct();
                                  foreach (var value in query1)
                                  {
                                    // User might have both emails signed up, so need to check both:
                                        if (!string.IsNullOrEmpty(value.UserEmail1))
                                        {
                                            if (value.NewsletterSubEmail1!=null && (bool)value.NewsletterSubEmail1)
                                            {
                                                if (result.Length > 0)
                                                {
                                                    result += ";";
                                                }
                                                result += value.UserEmail1;
                                            }
                                        }
                                        if (!string.IsNullOrEmpty(value.UserEmail2))
                                        {

                                            if (value.NewsletterSubEmail2!=null && (bool)value.NewsletterSubEmail2)
                                            {
                                                if (result.Length > 0)
                                                {
                                                    result += ";";
                                                }
                                                result += value.UserEmail2;
                                            }
                                        }

                                  }

                        var query2 = (from ut in _context.AC_ascUserTagUnregistered
                                 join u in _context.AC_tblUserContactInformationUnregistered on ut.UnregisteredUserID equals u.UserUnregisteredID
                                 where tFilter.TagIDList.Contains(ut.TagID.ToString())
                                 orderby u.UserLastName
                                 select u).Distinct();
                                 foreach (var item in query2)
                                 {
                                       if (!string.IsNullOrEmpty(item.UserEmail1))
                                        {
                                            //if ((bool)value.NewsletterSubEmail1)
                                            //{
                                            if (result.Length > 0)
                                            {
                                                result += ";";
                                            }
                                            result += item.UserEmail1;
                                            //}
                                        }
                                 }
              }
              catch(Exception ex)
              {

              }
              return result;
        }
        */



        public int GetUserID(string username = "")
        {
            int UserID = 0;
            try
            {
                  var query = (from u in _context.IE_tblUserContactInformation
                                     where u.UserEmail1.ToLower() == username.ToLower()
                                     orderby u.DateCreated
                                    select u).FirstOrDefault();

                                if (query != null)
                                {
                                    UserID = query.UserContactID;
                                }
            }
            catch(Exception ex)
            {

            }
            return UserID;
        }
          public int UnregisteredUserGetID(string emailAddress = "", int hostServer = 0, int userID = 0)
        {
            int UserID = 0;
            try
            {
                  var query = (from u in _context.IE_tblUserContactInformationUnregistered
                                     where u.UserEmail1.ToLower() == emailAddress.ToLower()
                                     orderby u.DateCreated
                                    select u).FirstOrDefault();

                                if (query != null)
                                {
                                    UserID = query.UserUnregisteredID;
                                }
            }
            catch(Exception ex)
            {

            }
            return UserID;
        }
        public string GetUserUID(string username = "")
        {
            string UserID = "";
            try
            {
                  var query = (from u in _context.IE_tblUserContactInformation
                                     where u.UserEmail1.ToLower() == username.ToLower()
                                     orderby u.DateCreated
                                    select u).FirstOrDefault();

                                if (query != null)
                                {
                                    UserID = query.UId;
                                }
            }
            catch(Exception ex)
            {
                UserID="";
            }
            return UserID;
        }
         public string GetUsercheck(int usercontactID = 0)
        {
            string UserID = "";
            try
            {
                  var query = (from u in _context.IE_tblUserContactInformation
                                     where u.UserContactID == usercontactID
                                     orderby u.DateCreated
                                    select u).FirstOrDefault();

                                if (query != null)
                                {
                                    UserID = query.UId;
                                }
            }
            catch(Exception ex)
            {
                UserID="";
            }
            return UserID;
        }
        public int UserIsRegistered(ValVal usr)
        {
            int userid = 0;
            string email = "";
            try
            {
                if (usr != null && !string.IsNullOrEmpty(usr.Val1))
                {
                    email = usr.Val1;
                  
                        var usersData = (from rec in _context.IE_tblUserContactInformation
                                         where (rec.UserEmail1.ToLower() == email.ToLower() && rec.Email1Verified == 1) 
                                            || (rec.UserEmail2.ToLower() == email.ToLower() && rec.Email2Verified == 1)
                                         select rec).FirstOrDefault();

                        if (usersData != null)
                        {
                            userid = usersData.UserContactID;
                        }
                    
                }
            }
            catch(Exception ex)
            {
                    userid=0;
            }
            return userid;

        }

        public string UpdatePrimaryemail(UserContactInformation userObject, int userID = 0, int hostServer = 0)
        {
               var result = "";
               try
               {
                 var usercontactEntity = _context.IE_tblUserContactInformation.SingleOrDefault(u => u.UserEmail1 == userObject.UserEmail2);
                   if (userObject != null || usercontactEntity != null) 
                   {
                        usercontactEntity.UserEmail1 = userObject.UserEmail1;
                        usercontactEntity.UserEmail2 = userObject.UserEmail2;
                        usercontactEntity.DateUpdated = DateTime.Now;
                        _context.SaveChanges();
                        result=usercontactEntity.UserEmail1;
                        
                     }
               }
               catch(Exception ex)
               {

               }
               return result;
        }

      
        /*
        public int FailedLoginClear(string username = "", int clearstatusid = 5, int serverid = 0, int entrypointid = 0)
        {
             int result = 0;
             UserContactInformation user = _factory.Create<UserContactInformation>();
             try
             {
                   user = GetUserContactInformationLight(username);
                      if (user != null)
                      {
                              var recs = from errs in _context.AC_tblLogErrLogin
                                   where errs.UserID == user.UserContactID
                                     && errs.StatusID == 1
                                   select errs;
                                    if (recs != null)
                                    {
                                        foreach (var rec in recs)
                                        {
                                            rec.StatusID = clearstatusid;
                                            rec.DateUpdated = DateTime.Now;
                                        }
                                    }
                                     _context.SaveChanges();
                                     result=1;
                      }
             }
             catch(Exception ex)
             {

             }
             return result;
        }
   
        public string PasswordValidationGetToken(string uID, int userID = 0, int hostServer = 0)
        {
             string token = "";
             try
             {
                   var record = _context.AC_tblPasswordResetMessage.FirstOrDefault(a => a.UserId == uID && a.StatusID != 5 && a.ValidationKey > 10);
                    if (record != null)
                    {
                        token = record.ValidationKey.ToString() + record.DummyKey.ToString();
                    }
             }
             catch(Exception ex)
             {
                token="";
             }
             return token;
        }
        


        public string CheckIEUsersStatus(string Useremail = null)
        {
            string status="";
            try
            {
                var user = _context.IE_tblUserContactInformation.Where(r=>r.UserEmail1 == Useremail).FirstOrDefault();

                int staus=  GetUserIEStatus(user.UserContactID,0,user.UId);
               
              
                if(staus ==2)
                {
                    status = "pending";

                }
                if(staus ==3)
                {
                    status = "rejected";
                }
            }
            catch(Exception ex)
            {
                status="";  
            }
            return status;
        }
        
         */
    }
}
