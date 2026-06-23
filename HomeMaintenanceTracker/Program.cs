/* Jeff O'Hara
 * 6/23/2026
 * 
 * Lets users add home tasks, assign priority, mark tasks complete, view overdue items, and see a dashboard
 * summary. 
 */

using HomeMaintenanceTracker;

TaskManager manager = new TaskManager();
bool running = true;

while (running)
{
    Console.Clear();
    Console.WriteLine("===== HOME MAINTENANCE TRACKER =====");
    Console.WriteLine("1. Add maintenance task");
    Console.WriteLine("2. View all tasks");
    Console.WriteLine("3. View overdue tasks");
    Console.WriteLine("4. Mark task as complete");
    Console.WriteLine("5. Dashboard summary");
    Console.WriteLine("6. Exit");
    Console.Write("Choose an option: ");

    string? choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            AddMaintenanceTask(manager);
            break;
        case "2":
            ViewTasks(manager.GetAllTasks()); 
            break;
        case "3":
            ViewTasks(manager.GetOverDueTasks());
            break;
        case "4":
            MarkComplete(manager);
            break;
        case "5":
            ShowDashboard(manager);
            break;
        case "6":
            running = false;
            break;
        default:
            Console.WriteLine("Invalid choice. Press Enter to try again.");
            Console.ReadLine();
            break;
    }
}

static void AddMaintenanceTask(TaskManager manager)
{
    Console.Clear();
    Console.WriteLine("===== ADD MAINTENANCE TASK =====");

    Console.Write("Task Title: ");
    string title = Console.ReadLine() ?? "";

    Console.Write("Area of home: ");
    string area = Console.ReadLine() ?? "";

    Console.Write("Priority (Low, Medium, High): ");
    string priority = Console.ReadLine() ?? "";

    DateTime dueDate;

    while (true)
    {
        Console.Write("Due date (MM/DD/YYYY): ");
        string? input = Console.ReadLine();

        if (DateTime.TryParse(input, out dueDate))
        {
            break;
        }

        Console.WriteLine("Invalid date. Please try again.");
    }

    manager.AddTask(title, area, priority, dueDate);

    Console.WriteLine();
    Console.WriteLine("Task added successfully.");
    Console.WriteLine("Press Enter to return to the menu.");
    Console.ReadLine();

}
static void ViewTasks(List<MaintenanceTask> tasks)
{
    Console.Clear();
    Console.WriteLine("===== TASK LIST =====");

    if (tasks.Count == 0)
    {
        Console.WriteLine("No tasks found.");
    }
    else
    {
        foreach (MaintenanceTask task in tasks)
        {
            string status = task.IsComplete ? "Complete" : "Open";

            Console.WriteLine("-----------------------------------");
            Console.WriteLine($"ID: {task.Id}");
            Console.WriteLine($"Title: {task.Title}");
            Console.WriteLine($"Area: {task.Area}");
            Console.WriteLine($"Priority: {task.Priority}");
            Console.WriteLine($"Due Date: {task.DueDate.ToShortDateString()}");
            Console.WriteLine($"Status: {status}");
        }
    }

    Console.WriteLine();
    Console.WriteLine("Press Enter to return to the menu.");
    Console.ReadLine();
}

static void MarkComplete(TaskManager manager)
{
    Console.Clear();
    Console.WriteLine("===== MARK TASK COMPLETE =====");

    Console.Write("Enter task ID: ");
    string? input = Console.ReadLine();

    if (int.TryParse(input, out int id))
    {
        bool success = manager.MarkTaskComplete(id);

        Console.WriteLine(success
            ? "Task marked as complete."
            : "Task not found.");
    }
    else
    {
        Console.WriteLine("Invalid ID.");
    }

    Console.WriteLine("Press Enter to return to the menu.");
    Console.ReadLine();
}

static void ShowDashboard(TaskManager manager)
{
    Console.Clear();
    Console.WriteLine("===== DASHBOARD SUMMARY =====");
    Console.WriteLine($"Open tasks: {manager.GetOpenCount()}");
    Console.WriteLine($"Completed tasks: {manager.GetCompletedCount()}");
    Console.WriteLine($"Overdue tasks: {manager.GetOverdueCount()}");

    Console.WriteLine();
    Console.WriteLine("Press Enter to return to the menu.");
    Console.ReadLine();
}
