using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Todo_List.Models
{
    public class todoHeader
    {
        public int headerId { get; set; }
        public string Header { get; set; }
        public int userId { get; set; }
        public virtual Users user { get; set; }
        public virtual ICollection<TodoList> TodoLists { get; set; }
    }
}
