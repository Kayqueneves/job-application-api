using System.ComponentModel;
using JobApplicationAPI.Models;
using Microsoft.EntityFrameworkCore;
using JobApplicationAPI.Data;
using JobApplicationAPI.Services.Interfaces;

namespace JobApplicationAPI.Services;



    

public class JobDatabaseService : IJobService
{
    private readonly AppDbContext banco;
    public JobDatabaseService(AppDbContext banco)
{
    this.banco = banco;
}
    
    public Job CreateJob(Job job)
    {
        banco.Add(job);
        banco.SaveChanges();
        return job;
    }

    public void DeleteJob(int id)
    {
        var job = banco.Find<Job>(id);
        if (job != null)
        {
            banco.Remove(job);
            banco.SaveChanges();
        }
    }

    public List<Job> Search(string title, string? location, string? technology)
    {
        var query = banco.Jobs.AsQueryable();
        if (!string.IsNullOrEmpty(title))
        {
            query = query.Where(j => EF.Functions.Like(j.Title, $"{title}%"));

            if (!string.IsNullOrEmpty(technology))
            {
                query = query.Where(j => EF.Functions.Like(j.Technology, $"{technology}%"));
            }
            if (!string.IsNullOrEmpty(location))
            {
                query = query.Where(j => EF.Functions.Like(j.Location, $"{location}%"));
            }
            return query.ToList();
        }

        return query.ToList();

    }

    public Job GetJobById(int id)
    {
       var job = banco.Find<Job>(id);
        if (job != null)
        {
            return job;
        }
        throw new InvalidOperationException("Job not found");
    }

    public Job UpdateJob(int id, Job job)
    {
        var existingJob = banco.Find<Job>(id);
        if (existingJob == null)
        {
            throw new InvalidOperationException("Job not found");
        }

        // Update the properties of the existing job with the new values
        existingJob.Location = job.Location;
        existingJob.Salary = job.Salary;
        existingJob.PostedDate = job.PostedDate;
        existingJob.CompanyId = job.CompanyId;  
        existingJob.Technology = job.Technology;
        existingJob.Title = job.Title;
        // ... update other properties as needed

        banco.Update(existingJob);
        banco.SaveChanges();
        return existingJob;
    }

  

}
