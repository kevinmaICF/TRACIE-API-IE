using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TRACIE_API_IE.IEBL;
using TRACIE_API_IE.filter;
using TRACIE_API_IE.Models;

namespace TRACIE_API_IE.Interface
{
    public interface IHelper
    {
      
        string Code(string str);
        string DeCode(string str);
        object GetValue(string key);
        List<AspNetUserTokens> Add(string key, List<AspNetUserTokens> value);
        void Delete(string key);
       
        object GetUserRoles(string key);
        List<AspNetUserRoles> Adduserroles(string key, List<AspNetUserRoles> value);
        void Deleteuserroles(string key);
        List<int> LoggedInUserRoleID(HttpRequest req,out string adminUserName);
   
         int LoggedInUserContactID(HttpRequest req);
     
        
    }
}

