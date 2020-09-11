using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Todo_List.DAL.Entities
{
    public class todoList
    {
        [Key]
        public int todoId { get; set; }
        public string todo { get; set; }
        public int headerId { get; set; }
        [ForeignKey("headerId")]
        public virtual TodoHeader todoHeader { get; set; }

    }
}
