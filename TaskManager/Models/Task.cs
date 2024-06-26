using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TaskManager.Models
{
    public class Task : BaseModel
    {
        public Task()
        {
            // Initialize collections in the constructor
            Title = "";
            Description = "";
            User = new User();
            // UserTasks = new List<UserTask>();
        }
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }
         [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsCompleted { get; set; }

        // Foreign key for User
        public int UserId { get; set; }
        public User User { get; set; }

        // public ICollection<UserTask> UserTasks { get; set; }
    }
}
