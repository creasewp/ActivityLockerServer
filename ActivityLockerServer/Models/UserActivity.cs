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
        [Display(Name = "Student Activity")]
        public string Description { get; set; }
        [Display(Name = "Task Code")]
        public string Code { get; set; }
        [Display(Name = "Task web address")]
        public string Url { get; set; }
        //public string UserGroupId { get; set; }
        public UserGroup UserGroup { get; set; }
        public string UserId { get; set; }
        public string TenantId { get; set; }
        public List<UserActivityUser> ActivityUsers { get; set; }

        public DateTime CreatedDateTime { get; set; }
        public DateTime ActiveBeforeDateTime { get; set; }
    }
}
