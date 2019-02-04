using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TRACIE_API_IE.Interface
{
    public interface IEventLog
    {
        bool UserLog_AddEvent(int userID, int eventTypeID, string eventDesc, string eventTitle, int serverID = 0, int entryPointID = 0, int hostServer = 0);
          int SaveError(string errLocation = "", string errMessage = "", string errTitle = "", string errDesc = "", 
                                       string errVar1 = "", string errVar2 = "", string errVar3 = "", string errVar4 = "", string errVar5 = "", int serverID = 0, int userID = 0, int EventTypeID = 11);
    string TrimString(string stringToTrim, int maxLen);
    
    }
}
