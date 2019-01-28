using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TRACIE_API_IE.Models
{
    public class AspNetUsers
    {
        public string ID { get; set; }
        public System.Nullable<int> AccessFailedCount { get; set; }
        public string ConcurrencyStamp { get; set; }
        [StringLength(256)]
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public  System.Nullable<bool> LockoutEnabled { get; set; }
        public System.Nullable<DateTimeOffset> LockoutEnd { get; set; }
        [StringLength(256)]
        public string NormalizedEmail { get; set; }
        [StringLength(256)]
        public string NormalizedUserName { get; set; }
        public string PasswordHash { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public string SecurityStamp { get; set; }
        public System.Nullable<bool> TwoFactorEnabled { get; set; }
        public string UserName { get; set; }
        public List<AspNetUserRoles> AspNetUserRoles { get; set; }
    }
}
