using Microsoft.AspNetCore.Mvc;
using JobApplicationAPI.Models;
using JobApplicationAPI.Services;
using JobApplicationAPI.Services.Interfaces;

namespace JobApplicationAPI.Controller;

[ApiController]
[Route("api/[controller]")]
public class JobControllerController : ControllerBase
{
    public IJobService JobService;
    public JobControllerController(IJobService jobService)
    {
        this.JobService = jobService;
    }
    [HttpGet]
    public ActionResult<Job> Get()
    {
        return Ok(JobService.GetAllJobs());
    }
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var job = JobService.GetJobById(id);
        if(job == null)
        {
            return NotFound();
        }
        return Ok(job);
    }
    [HttpPost]
    public IActionResult Post(Job job)
    {
        JobService.CreateJob(job);

        return Ok(job);
    }
   
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        JobService.DeleteJob(id);
        return NoContent();
    }
}
