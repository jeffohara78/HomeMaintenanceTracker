namespace HomeMaintenanceTracker;

public class MaintenanceTask
{ 
    public int Id { get; set; }
    public string Title { get; set; }
    public string Area { get; set; }
    public string Priority { get; set; }
    public DateTime DueDate { get; set; }
    public bool IsComplete { get; set; }

    public MaintenanceTask(int id, string title, string area, string priority, DateTime dueDate)
    {
        Id = id;
        Title = title;
        Area = area;
        Priority = priority;
        DueDate = dueDate;
        IsComplete = false;
    }
}