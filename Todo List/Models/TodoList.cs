using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Todo_List.Models
{
    public class TodoList
    {
        public int todoId { get; set; }
        public string todo { get; set; }
        public int headerId { get; set; }
        public virtual todoHeader todoHeader { get; set; }
        public int userId { get; set; }
        public virtual Users user { get; set; }
    }
}
