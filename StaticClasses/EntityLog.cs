using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TRACIE_API_IE.Interface;
using TRACIE_API_IE.Models;

namespace TRACIE_API_IE.StaticClasses
{
    public class EntityLog: IEventLog
    {
        private readonly TracieIEContext _context;
        private readonly IConfiguration _configuration;
        public EntityLog(TracieIEContext context)
        {
           
            _context = context;
        }
        public bool UserLog_AddEvent(int userID, int eventTypeID, string eventDesc, string eventTitle, int serverID = 0, int entryPointID = 0, int hostServer = 0)
        {
            bool result = true;
            try
            {
                IE_tblLogEventUser ul = new IE_tblLogEventUser();
                ul.UserID = userID;
                ul.EventTypeID = eventTypeID;
                ul.DateCreated = DateTime.Now;
                ul.CreatedBy = userID;
                ul.EventDesc = eventDesc;
                ul.EventTitle = eventTitle;
                if (serverID > 0)
                    ul.ServerID = serverID;
                if (entryPointID > 0)
                    ul.EntryPointID = entryPointID;

                _context.IE_tblLogEventUser.Add(ul);
                _context.SaveChanges();
                if (ul.EventTypeID == 5)
                {

                    var usr = _context.IE_tblUserContactInformation.Where(u => u.UserContactID == userID).SingleOrDefault();
                    if (usr != null)
                    {
                        usr.DateLogin = ul.DateCreated;
                        _context.SaveChanges();
                    }

                }
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }

        public int SaveError(string errLocation = "", string errMessage = "", string errTitle = "", string errDesc = "", 
                                       string errVar1 = "", string errVar2 = "", string errVar3 = "", string errVar4 = "", string errVar5 = "", int serverID = 0, int userID = 0, int EventTypeID = 11)
        {
            int result = 0;
            try
            {
                    IE_tblLogErr lgerr = new IE_tblLogErr();
                    lgerr.DateCreated = DateTime.Now;
                    lgerr.ErrDesc = TrimString(errDesc, 500);
                    lgerr.ErrLocation = TrimString(errLocation, 100);
                    lgerr.ErrMessage = TrimString(errMessage, 2000);
                    lgerr.ErrTitle = TrimString(errTitle, 100);
                  
                    lgerr.EventTypeID = EventTypeID;
                    if (serverID >0)
                    {
                        lgerr.ServerID = serverID;
                    }
                    if (userID > 0)
                    {
                        lgerr.UserID = userID;
                    }
                     _context.IE_tblLogErr.Add(lgerr);
                     _context.SaveChanges();

                    result = 1;
                
            }
            catch(Exception ex)
            {

            }
            return result;
           
        }
         public string TrimString(string stringToTrim, int maxLen)
            {
                string result = stringToTrim;
                if (result != null && result.Length > maxLen)
                {
                    result = result.Substring(0, maxLen);
                }
                return result;
            }
    }
}
