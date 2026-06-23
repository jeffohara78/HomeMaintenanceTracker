namespace HomeMaintenanceTracker;

public class TaskManager
{ 
    private List<MaintenanceTask> tasks = new List<MaintenanceTask>();
    private int nextId = 1;

    public void AddTask(string title, string area, string priority, DateTime dueDate)
    { 
        MaintenanceTask task = new MaintenanceTask(nextId, title, area, priority, dueDate);
        tasks.Add(task);
        nextId++;
    }

    public List<MaintenanceTask> GetAllTasks()
    { 
        return tasks;
    }

    public List<MaintenanceTask> GetOverDueTasks()
    { 
        return tasks
            .Where(t => !t.IsComplete && t.DueDate < DateTime.Today)
            .ToList();
    }

    public MaintenanceTask? FindTaskById(int id)
    {
        return tasks.FirstOrDefault(t => t.Id == id);
    }

    public bool MarkTaskComplete(int Id)
    { 
        MaintenanceTask? task = FindTaskById(Id);

        if (task == null)
        {
            return false;
        }

        task.IsComplete = true;
        return true;
    }

    public int GetCompletedCount()
    { 
        return tasks.Count(t => t.IsComplete);
    }

    public int GetOpenCount()
    { 
        return tasks.Count(t => t.IsComplete);

    }

    public int GetOverdueCount()
    {
        return GetOverDueTasks().Count;
    }
}