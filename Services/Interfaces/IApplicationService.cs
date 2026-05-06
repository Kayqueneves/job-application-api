using JobApplicationAPI.Models;

namespace JobApplicationAPI.Services.Interfaces;

public interface IApplicationService 
{
    List<Application> GetAllApplications();
    Application GetApplicationById(int id);
    Application CreateApplication(Application application);
    Application UpdateApplication(int id, Application application);
    void DeleteApplication(int id);
    List<Application> GetApplicationsByUser(int user);
    List<Application> GetApplicationsByJob(int job);
}
