using JobApplicationAPI.Models;
namespace JobApplicationAPI.Services.Interfaces;

public interface ICompanyService 
{
    public List<Company> GetAllCompanies();
    public Company GetCompanyById(int id);
    public Company CreateCompany(Company company);
    public Company UpdateCompany(int id, Company company);
    public void DeleteCompany(int id);
}
