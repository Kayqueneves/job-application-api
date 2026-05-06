using JobApplicationAPI.Data;
using JobApplicationAPI.Models;

using JobApplicationAPI.Services.Interfaces;
using SQLitePCL;

namespace JobApplicationAPI.Services;

public class CompanyDatabaseService : ICompanyService
{
    private readonly AppDbContext banco;
    public CompanyDatabaseService(AppDbContext banco)
    {
        this.banco = banco;
    }
     public Company CreateCompany(Company company)
    {
        banco.Add(company);
        banco.SaveChanges();
        return company;
    }
    public List<Company> GetAllCompanies()
    {
        return banco.Set<Company>().ToList();
    }

    public Company GetCompanyById(int id)
    {
        var company = banco.Find<Company>(id);
        if (company != null)
        {
            return company;
        }
        throw new Exception("Company not found ");        
    }

   

    public Company UpdateCompany(int id, Company company)
    {
        var existingCompany = banco.Find<Company>(id);
        if (existingCompany == null)
        {
            throw new Exception("Company not found");
        }
        existingCompany.Name = company.Name;
        existingCompany.Email = company.Email;
        existingCompany.Name = company.Name;
        existingCompany.Location = company.Location;
        existingCompany.Description = company.Description;
        banco.Update(existingCompany);
        banco.SaveChanges();
        return existingCompany;
        

    }

    public void DeleteCompany(int id)
    {
        var company = banco.Find<Company>(id);
        if(company != null)
        {
            banco.Remove(company);
            banco.SaveChanges();
        }
    }


    
}
