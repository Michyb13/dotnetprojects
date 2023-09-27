using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TodoList.Models
{
    public class TodoItemModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "The text field is required")]
        public string Text { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}