using JobApplicationAPI.Models;
using JobApplicationAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JobApplicationAPI.Controller;

[ApiController]
[Route("api/[controller]")]
public class ApplicationControllerController : ControllerBase
{
    public IApplicationService applicationService;
    public ApplicationControllerController(IApplicationService applicationService)
    {
        this.applicationService = applicationService;
    }
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(applicationService.GetAllApplications());
    }
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var application = applicationService.GetApplicationById(id);
        if (application == null)
        {
            return NotFound();
        }
        return Ok(application);
    }
    [HttpPost]
    public IActionResult Post(Application application)
    {
        applicationService.CreateApplication(application);

        return Ok(application);
    }
    [HttpPut("{id}")]
    public IActionResult Put(int id, Application application)
    {
        try
        {
            var updatedApplication = applicationService.UpdateApplication(id, application);
            return Ok(updatedApplication);
        }
        catch (InvalidOperationException)
        {
            return NotFound();
        }
    }
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        try
        {
            applicationService.DeleteApplication(id);
            return NoContent();
        }
        catch (InvalidOperationException)
        {
            return NotFound();
        }
        [HttpGet("user/{userId}")]

         IActionResult GetByUser(int userId)
        {
            var applications = applicationService.GetApplicationsByUser(userId);
            return Ok(applications);
        }
        [HttpGet("job/{jobId}")]
         IActionResult GetByJob(int jobId)
        {
            var applications = applicationService.GetApplicationsByJob(jobId);
            return Ok(applications);
        }
    }
}
