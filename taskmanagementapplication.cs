public class Task
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsCompleted { get; set; }
}

public class TaskManager
{
    private List<Task> tasks;

    public TaskManager()
    {
        tasks = new List<Task>();
    }

    public void AddTask(Task task)
    {
        tasks.Add(task);
    }

    public void UpdateTask(Task task)
    {
        Task existingTask = tasks.Find(t => t.Id == task.Id);
        if (existingTask != null)
        {
            existingTask.Title = task.Title;
            existingTask.Description = task.Description;
            existingTask.IsCompleted = task.IsCompleted;
        }
    }

    public void DeleteTask(int taskId)
    {
        Task taskToRemove = tasks.Find(t => t.Id == taskId);
        if (taskToRemove != null)
        {
            tasks.Remove(taskToRemove);
        }
    }

    public void MarkTaskAsCompleted(int taskId)
    {
        Task taskToComplete = tasks.Find(t => t.Id == taskId);
        if (taskToComplete != null)
        {
            taskToComplete.IsCompleted = true;
        }
    }

    public List<Task> GetAllTasks()
    {
        return tasks;
    }
}

class Program
{
    private static TaskManager taskManager = new TaskManager();

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Task Management Application");
            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. Update Task");
            Console.WriteLine("3. Delete Task");
            Console.WriteLine("4. Mark Task as Completed");
            Console.WriteLine("5. Show All Tasks");
            Console.WriteLine("6. Exit");
            Console.WriteLine();

            Console.Write("Enter your choice (1-6): ");
            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    AddTask();
                    break;
                case "2":
                    UpdateTask();
                    break;
                case "3":
                    DeleteTask();
                    break;
                case "4":
                    MarkTaskAsCompleted();
                    break;
                case "5":
                    ShowAllTasks();
                    break;
                case "6":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            Console.WriteLine();
        }
    }

    static void AddTask()
    {
        Task task = new Task();

        Console.Write("Enter task title: ");
        task.Title = Console.ReadLine();

        Console.Write("Enter task description: ");
        task.Description = Console.ReadLine();

        taskManager.AddTask(task);
        Console.WriteLine("Task added successfully!");
    }

    static void UpdateTask()
    {
        Console.Write("Enter task ID: ");
        int taskId = Convert.ToInt32(Console.ReadLine());

        Task task = taskManager.GetAllTasks().FirstOrDefault(t => t.Id == taskId);

        if (task == null)
        {
            Console.WriteLine("Task not found!");
            return;
        }

        Console.Write("Enter new task title: ");
        task.Title = Console.ReadLine();

        Console.Write("Enter new task description: ");
        task.Description = Console.ReadLine();

        taskManager.UpdateTask(task);
        Console.WriteLine("Task updated successfully!");
    }

    static void DeleteTask()
    {
        Console.Write("Enter task ID: ");
        int taskId = Convert.ToInt32(Console.ReadLine());

        taskManager.DeleteTask(taskId);
        Console.WriteLine("Task deleted successfully!");
    }

    static void MarkTaskAsCompleted()
    {
        Console.Write("Enter task ID: ");
        int taskId = Convert.ToInt32(Console.ReadLine());

        taskManager.MarkTaskAsCompleted(taskId);
        Console.WriteLine("Task marked as completed!");
    }

    static void ShowAllTasks()
    {
        List<Task> tasks = taskManager.GetAllTasks();

        if (tasks.Count == 0)
        {
            Console.WriteLine("No tasks found!");
            return;
        }

        Console.WriteLine("Tasks:");
        foreach (Task task in tasks)
        {
            Console.WriteLine($"ID: {task.Id}");
            Console.WriteLine($"Title: {task.Title}");
            Console.WriteLine($"Description: {task.Description}");
            Console.WriteLine($"Completed: {(task.IsCompleted ? "Yes" : "No")}");
            Console.WriteLine();
        }
    }
}
