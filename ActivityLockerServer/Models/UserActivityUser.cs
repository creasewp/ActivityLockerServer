using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ActivityLockerServer.Models
{
    public enum UserActivityUserStatus
    {
        Waiting,
        Active,
        Exited
    }

    public class UserActivityUser
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public UserActivityUserStatus Status { get; set; }

    }
}
