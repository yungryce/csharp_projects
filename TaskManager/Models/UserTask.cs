using System.ComponentModel.DataAnnotations;

namespace TaskManager.Models
{
    public class UserTask
    {
        public UserTask(User user, Task task)
        {
            User = user ?? throw new ArgumentNullException(nameof(user));
            Task = task ?? throw new ArgumentNullException(nameof(task));
        }
        
        public int UserId { get; set; }
        [Required]
        public User User { get; set; }

        public int TaskId { get; set; }
        public Task Task { get; set; }
    }
}
