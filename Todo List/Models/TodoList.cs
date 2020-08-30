using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Todo_List.Models
{
    public class TodoList
    {
        [Key]
        public int todoId { get; set; }
        public string todo { get; set; }
        public int headerId { get; set; }
        public virtual TodoHeader todoHeader { get; set; }
        public int userId { get; set; }
        public virtual Users user { get; set; }
    }
}
