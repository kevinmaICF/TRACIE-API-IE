using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using TRACIE_API_IE.IEBL;
using TRACIE_API_IE.Interface;
using TRACIE_API_IE.Models;

namespace TRACIE_API_AC.StaticClasses
{
    public class Helper : IHelper
    {
      

        protected readonly IMemoryCache _memoryCache;
        private readonly IUserRepository _repository;
     
        public Helper(IMemoryCache memoryCache,IUserRepository repository)
        {
            _memoryCache = memoryCache;
            _repository = repository;

        }


        public string Code(string str)
        {
            string strResult = str.Replace("@", "_at_").Replace(".", "_dot_");

            return strResult;
        }

        public string DeCode(string str)
        {
            string strResult = str.Replace("_at_", "@").Replace("_dot_", ".");
            return strResult;
        }
        public object GetValue(string key)
        {


            return _memoryCache.Get(key);
        }
        public object GetUserRoles(string key)
        {


            return _memoryCache.Get(key);
        }
        public List<AspNetUserTokens> Add(string key, List<AspNetUserTokens> value)
        {
            var cacheEntryOptions = new MemoryCacheEntryOptions()
                     .SetSlidingExpiration(TimeSpan.FromDays(30));

            return _memoryCache.Set(key, value, cacheEntryOptions);

        }
      
        public void Delete(string key)
        {

            var obj = _memoryCache.Get(key);
            if (obj != null)
            {
                _memoryCache.Remove(key);
            }
        }
        public void Deleteuserroles(string key)
        {

            var obj = _memoryCache.Get(key);
            if (obj != null)
            {
                _memoryCache.Remove(key);
            }
        }

        public List<AspNetUserRoles> Adduserroles(string key, List<AspNetUserRoles> value)
        {
            var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromDays(30));

            return _memoryCache.Set(key, value, cacheEntryOptions);
        }
        public List<int> LoggedInUserRoleID(HttpRequest req,out string adminUserName)
        {
            List<int> ur = new List<int>();
            adminUserName = "";
            var req1 = req.Headers["Authorization"].FirstOrDefault();
           
            try
            {
                if (req1!=null)
                {
                    string auth =  req.Headers["Authorization"].FirstOrDefault();
                    if (String.IsNullOrEmpty(auth))
                    {
                        ur = null;
                    }
                    else
                    {
                        string[] autherizationHeaderArray = auth.Split(',');
                        if (autherizationHeaderArray.Length > 1)
                        {
                            string username = autherizationHeaderArray[1];
                            if (String.IsNullOrEmpty(username))
                            {
                                ur = null;
                            }
                            else
                            {
                                adminUserName = username;
                                ur = _repository.GetUserRolesByUserName(username);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ur = null;
            }
            return ur;
        }
        public int LoggedInUserContactID(HttpRequest req)
        {
            int UserID = 0;
            try
            {
                   string auth = req.Headers["Authorization"].FirstOrDefault();
                    if (String.IsNullOrEmpty(auth))
                    {
                        UserID = 0;
                    }
                    else
                    {
                      string[] autherizationHeaderArray = auth.Split(',');
                      if(autherizationHeaderArray.Length > 1)
                      {
                           string username = autherizationHeaderArray[1];
                            if (String.IsNullOrEmpty(username))
                            {
                                UserID = 0;
                            }
                            else
                            {
                               UserID = _repository.GetUserID(username);
                            }
                        }
                    }
            }
            catch(Exception ex)
            {
                UserID = 0;
            }
            return UserID;
        }
    }
}
