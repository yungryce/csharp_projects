using System;
using System.Linq;

namespace TaskManager
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new TaskDbContext())
            {
                // Add a new user
                var user = new User { Name = "John Doe" };
                context.Users.Add(user);
                context.SaveChanges();

                // Add a new task
                var task = new Task
                {
                    Title = "Sample Task",
                    Description = "This is a sample task.",
                    DueDate = DateTime.Now.AddDays(7),
                    IsCompleted = false
                };
                context.Tasks.Add(task);
                context.SaveChanges();

                // Establish many-to-many relationship
                var userTask = new UserTask
                {
                    UserId = user.Id,
                    TaskId = task.Id
                };
                context.UserTasks.Add(userTask);
                context.SaveChanges();

                // Retrieve and display tasks for the user
                var userWithTasks = context.Users
                    .Where(u => u.Id == user.Id)
                    .Select(u => new
                    {
                        u.Name,
                        Tasks = u.UserTasks.Select(ut => ut.Task).ToList()
                    })
                    .FirstOrDefault();

                Console.WriteLine($"User: {userWithTasks.Name}");
                foreach (var t in userWithTasks.Tasks)
                {
                    Console.WriteLine($"Task: {t.Title}, Due: {t.DueDate}, Completed: {t.IsCompleted}");
                }
            }
        }
    }
}
