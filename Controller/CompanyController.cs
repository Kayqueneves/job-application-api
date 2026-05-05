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
    public ActionResult<Company> Post(Company newCompany)
    {
        return Ok(companyService.CreateCompany(newCompany));
    }
}
