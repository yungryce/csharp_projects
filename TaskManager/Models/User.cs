using System.Collections.Generic;

namespace TaskManager
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<UserTask> UserTasks { get; set; }
    }
}
