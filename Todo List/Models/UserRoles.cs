using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Todo_List.Models
{
    public class UserRoles
    {
        public int roleId { get; set; }
        public string roleName { get; set; }
        public virtual ICollection<Users> users { get; set; }
        public virtual ICollection<todoHeader> todoHeaders { get; set; }
        public virtual ICollection<TodoList> todoLists { get; set; }
    }
}
