using JobApplicationAPI.Models;
namespace JobApplicationAPI.Services.Interfaces;

public interface IJobService
{
    public List<Job> Search(string title, string? location, string? technology);
    public Job GetJobById(int id);
    public Job CreateJob(Job job);
    public Job UpdateJob(int id, Job job);
    public void DeleteJob(int id);
}
