using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TaskManager.Models
{
    public class User : BaseModel
    {
        public User()
        {
            // Initialize collections or other properties if needed
            Email = "";
            Username = "";
            FirstName = "";
            LastName = "";
            Password = "";

            // Initialize collections in the constructor
            Tasks = new List<Task>();
        }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        // Navigation property for one-to-many relationship with tasks
        public ICollection<Task> Tasks { get; set; }

        // Navigation property for many-to-many relationship with tasks
        // public ICollection<UserTask> UserTasks { get; set; }
    }
}