using JobApplicationAPI.Data;
using JobApplicationAPI.Models;
using JobApplicationAPI.Services.Interfaces;

namespace JobApplicationAPI.Services;

public class ApplicationDatabaseService : IApplicationService
{
    private readonly AppDbContext banco;
    public ApplicationDatabaseService(AppDbContext banco)
    {
        this.banco = banco;
    }
    public Application CreateApplication(Application application)
    {
        banco.Add(application);
        banco.SaveChanges();
        return application;
    }

    public void DeleteApplication(int id)
    {
        var application = banco.Find<Application>(id);
        if (application != null)
        {
            banco.Remove(application);
            banco.SaveChanges();
        }
    }

    public List<Application> GetAllApplications()
    {
        return banco.Set<Application>().ToList();
    }

    public Application GetApplicationById(int id)
    {
    return banco.Find<Application>(id);
    }

    public Application UpdateApplication(int id, Application application)
    {
        var existingApplication = banco.Find<Application>(id);
        if (existingApplication == null)
        {
            throw new InvalidOperationException("Application not found");
        }

        banco.Entry(existingApplication).CurrentValues.SetValues(application);
        banco.SaveChanges();
        return existingApplication;
    }
    public List<Application> GetApplicationsByUser(int user)
    {
        return banco.Applications.Where(a => a.UserId == user).ToList();
    }
    public List<Application> GetApplicationsByJob(int job)
    {
        return banco.Applications.Where(a => a.JobId == job).ToList();
    }
}
