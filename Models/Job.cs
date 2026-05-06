namespace JobApplicationAPI.Models;

public class Job
{
    public int Id { get; set; }
    public string Technology { get; set; }
    public string Title { get; set; }
    public string Location { get; set; }
    public decimal Salary { get; set; }
    public DateTime PostedDate { get; set; }
    public int CompanyId { get; set; }
    
}
