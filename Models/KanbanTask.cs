namespace WebApp.Models
{
    public class KanbanTask
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Status { get; set; } = "todo";
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}