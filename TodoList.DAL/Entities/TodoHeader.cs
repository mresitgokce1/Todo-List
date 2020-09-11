using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Todo_List.DAL.Entities
{
    public class TodoHeader
    {
        [Key]
        public int headerId { get; set; }
        public string Header { get; set; }
        public int userId { get; set; }
        [ForeignKey("userId")]
        public virtual Users user { get; set; }
        public virtual ICollection<todoList> TodoLists { get; set; }
    }
}
