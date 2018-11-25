using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ActivityLockerServer.Models
{
    public class UserGroup
    {
        public string Id { get; set; }
        [Display(Name="Class")]
        public string Description { get; set; }
        public string WebAddress { get; set; }
        public string UserId { get; set; }
        public string TenantId { get; set; }

    }
}
