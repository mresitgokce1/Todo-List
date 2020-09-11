using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Todo_List.DAL.Entities
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

        [ForeignKey("roleId")]
        public virtual UserRoles userRole { get; set; }




        public virtual ICollection<TodoHeader> todoHeaders { get; set; }
    }
}
