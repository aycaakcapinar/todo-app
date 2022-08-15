using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoAppWebAPI.Models
{
    public class ToDoListItem
    {
        [Key]
        public int ToDoId { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        [Required]
        public string Title { get; set; }
        [Column(TypeName = "date")]
        [Required]
        public DateTime CreateDate { get; set; } = DateTime.Now;
        [Required]
        [Column(TypeName = "bit")]
        public Boolean IsCompleted { get; set; } = false;
        [Column(TypeName = "nvarchar(100)")]
        public String Detail { get; set; }
        [Column(TypeName = "nvarchar(10)")]
        public String Priority { get; set; }
    }
}
