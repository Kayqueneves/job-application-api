using JobApplicationAPI.Models;
using JobApplicationAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JobApplicationAPI.Controller;

[ApiController]
[Route("api/[controller]")]
public class CompanyControllerController : ControllerBase
{
    public ICompanyService companyService;
    public CompanyControllerController(ICompanyService companyService)
    {
        this.companyService = companyService;
    }

    [HttpGet]
    public ActionResult<List<Company>> Get()
    {
        return Ok(companyService.GetAllCompanies());
    }
    [HttpPost]
    public ActionResult<Company> Post(Company company)
    {
        return Ok(companyService.CreateCompany(company));
    }
    [HttpGet("{id}")]
    public ActionResult<Company> Get(int id)
    {
        var company = companyService.GetCompanyById(id);
        if (company == null)
        {
            return NotFound();
        }
        return Ok(company);
    }
    [HttpPut("{id}")]
    public ActionResult<Company> Put(int id, Company company)
    {
        try
        {
            var updatedCompany = companyService.UpdateCompany(id, company);
            return Ok(updatedCompany);
        }
        catch (InvalidOperationException)
        {
            return NotFound();
        }
    }
    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        try
        {
            companyService.DeleteCompany(id);
            return NoContent();
        }
        catch (InvalidOperationException)
        {
            return NotFound();
        }
    }
}
