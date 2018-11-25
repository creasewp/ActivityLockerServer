using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ActivityLockerServer.Models
{
    public class UserActivity
    {
        public string Id { get; set; }
        public string Description { get; set; }
        [Display(Name = "Activity Code")]
        public string Code { get; set; }
        [Display(Name = "Activity Url")]
        public string Url { get; set; }
        public string UserId { get; set; }
        public string TenantId { get; set; }
        public List<UserActivityUser> ActivityUsers { get; set; }

    }
}
