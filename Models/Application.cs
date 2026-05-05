namespace JobApplicationAPI.Models;

public class Application
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int JobId { get; set; }
    public Job? Job { get; set; }
    public DateTime ApplicationDate { get; set; } = DateTime.Now;
    public string Status { get; set; } = "Pending";
}
