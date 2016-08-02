/* This code sample is for a custom login screen.  The application logs members in using a custom login form.
 * The isValid method determines whether the user's credentials are valid 
 */ 

namespace Rewards_3_.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Data;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using System.Diagnostics;
    using System.Text;
    using System.Threading.Tasks;
    public partial class user
    {
  
  // db set for application
        private rewardsEntities db = new rewardsEntities();
        [Display(Name="User name")]
        public string userId { get; set; }
        [DataType(DataType.Password)]
        public string password { get; set; }
//        public string email { get; set; }
        [Display(Name="Remember me?")]
        public bool rememberMe { get; set; }
        public bool isValid(string userName, string password)
        {
            try
            {
                var queryResult = db.users.SingleOrDefault(u => u.userId == userName);
                if (queryResult != null) {
                    return true;
                    queryResult.password = Encode(password); 
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("There was a problem processing the login. " + ex.Message);
                return false;
            }
        }

        /*
         * Add password security.  Code taken from Code Project.
         * Eventually this method should go in a helper class.
          */
        public string Encode(string value)
        {
            var hash = System.Security.Cryptography.SHA1.Create();
            var encoder = new System.Text.ASCIIEncoding();
            var combined = encoder.GetBytes(value ?? "");
            return BitConverter.ToString(hash.ComputeHash(combined)).ToLower().Replace("-", "");
        }
    }
}
