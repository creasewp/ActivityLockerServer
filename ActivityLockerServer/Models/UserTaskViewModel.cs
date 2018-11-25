using ActivityLockerServer.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ActivityLockerServer.Models
{
    public class UserTaskViewModel : UserActivity
    {
        public UserTaskViewModel()
        {
        }

        public UserTaskViewModel(string userId, ApplicationDbContext context)
        {
            UserGroups = context.UserGroups.Where(item => item.UserId == userId).OrderBy(item => item.Description).ToList();
        }

        public IList<UserGroup> UserGroups { get; set; }
        public IList<string> SelectedUserGroups { get; set; }
    }
}
