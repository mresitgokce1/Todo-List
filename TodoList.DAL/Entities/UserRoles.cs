using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Todo_List.DAL.Entities
{
    public class UserRoles
    {
        [Key]
        public int roleId { get; set; }
        public string roleName { get; set; }
        public virtual ICollection<Users> users { get; set; }
        
    }
}
