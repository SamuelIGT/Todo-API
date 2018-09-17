using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TodoAPI.Models
{
    public class TodoItem{
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        public bool IsCompleted { get; set; }

    }
}
