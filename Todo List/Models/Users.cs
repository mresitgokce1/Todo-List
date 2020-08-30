using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Todo_List.Models
{
    public class Users
    {
        [Key]
        public int userId { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public int roleId { get; set; }
        public virtual UserRoles userRoles { get; set; }
    }
}
