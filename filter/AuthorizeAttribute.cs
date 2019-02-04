using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


using TRACIE_API_IE.Interface;
using TRACIE_API_IE.Models;


namespace TRACIE_API_IE.filter
{
    public class AuthorizeValidateAttribute : TypeFilterAttribute
    {
        public AuthorizeValidateAttribute()
        : base(typeof(AuthorizeActionFilter))


        {

        }
    }
    
    public class AuthorizeActionFilter : IAsyncActionFilter
    {
        private readonly TracieIEContext _context;
        private string APPID = "m9kH3u655GKZ@334391";
        string username = "";
        private readonly IConfiguration _configuration;
        private readonly IHelper _helper;
      

        public AuthorizeActionFilter(TracieIEContext context, IConfiguration configuration, IHelper helper)
        {
            _configuration = configuration;
            _context = context;
            _helper = helper;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
        
            var req = context.HttpContext.Request;
           
      
            string rawAuthzHeader = req.Headers["Authorization"].FirstOrDefault();
            string[] autherizationHeaderArray = rawAuthzHeader.Split(',');
            if (autherizationHeaderArray[1] == null)
            {
                context.Result = new UnauthorizedResult();
            }
            else
            {
                if (autherizationHeaderArray[0] != null)
                {
                    var APPId = autherizationHeaderArray[0];
                    username = autherizationHeaderArray[1];
                    var valid = await isValidRequest(req, APPId, username);


                    if (!valid)
                    {
                        context.Result = new UnauthorizedResult();

                    }
                    else
                    {
                        await next();
                    }



                }
                else
                {
                  
                    context.Result = new UnauthorizedResult();
                }

            }

        }

        public  void AddCacheValue(string username, string APPId)
        {
                if (username != null && username != "")
                {
                    var usr = _context.AspNetUsers.Where(u => u.UserName.ToLower() == username.ToLower()).FirstOrDefault();
                    if (usr != null)
                    {
                        List<AspNetUserTokens> usritems = _context.AspNetUserTokens.ToList();

                        _helper.Add("UserAPIkey", usritems);
                    }


                }

        }
        public void AddUserRoleCacheValue(string username)
        {
            if (username != null && username != "")
            {
                var usr = _context.AspNetUsers.Where(u => u.UserName.ToLower() == username.ToLower()).FirstOrDefault();
                if (usr != null)
                {
                    List<AspNetUserRoles> usrroleitems = _context.AspNetUserRoles.ToList();

                    _helper.Adduserroles("UserRole", usrroleitems);
                }


            }

        }
        public  List<AspNetUserTokens> checkapikey(string APPId,string userID)
        {
            bool value = false;
            IEnumerable<AspNetUserTokens> data =
                  (IEnumerable<AspNetUserTokens>)_helper.GetValue("UserAPIkey");
                   var usr = _context.AspNetUsers.Where(u => u.UserName.ToLower() == userID.ToLower()).FirstOrDefault();

            List<AspNetUserTokens> user = data.ToList().Where(s => s.Value.ToLower() == APPId.ToLower()&& s.UserId.ToLower()==usr.ID.ToLower()).ToList();
            return user;
        }
      
        public  bool CheckValue(string username, string APPId)
        {
            bool value = false;
            bool userrolecheck = false;
            var result = _helper.GetValue("UserAPIkey");
            List<AspNetUserTokens> user = null;
           
            if (username != "")
            {
                if (result == null)
                {
                    AddCacheValue(username, APPId);
                    
                }
                var resultkey = _helper.GetValue("UserAPIkey");
                user = checkapikey(APPId,username);
             
               
                if (user.Count > 0 && user != null)
                {
                   value=true;
                }
                else
                {
                    _helper.Delete("UserAPIkey"); 
                  
                    AddCacheValue(username, APPId);
                 
                    user = checkapikey(APPId,username);
                    if (user.Count > 0 && user != null)
                    {
                      
                             value = true; 
                        
                    }
                }

            }
            return value;
        }

        public string Decrypt(string cipherString, string key)
        {
            byte[] keyArray;
            byte[] toEncryptArray = Convert.FromBase64String(cipherString);






            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
            hashmd5.Clear();


            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            tdes.Clear();
            return UTF8Encoding.UTF8.GetString(resultArray);
        }
        private async Task<bool> isValidRequest(HttpRequest req, string APPId, string username)
        {
            try
            {
               
                bool value = false;
                string requestHttpMethod = req.Method;
                string APIkey = _configuration["APIKey"];
               
                if (username != "")
                {
                    value = CheckValue(username, APPId);
                }

                else
                {

                    string decreptedtext = Decrypt(APPId, APIkey);
                    if ((APPID.ToLower() == decreptedtext.ToLower()))
                        value = true;
                    else
                        value = false;

                }
              
                return value;

            }
            catch (Exception ex)
            {
                throw new UnauthorizedAccessException();
            }


        }


     
    }
}
