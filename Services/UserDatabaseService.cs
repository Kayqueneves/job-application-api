using System.ComponentModel;
using JobApplicationAPI.Models;
using JobApplicationAPI.Services.Interfaces;
using JobApplicationAPI.Data;

namespace JobApplicationAPI.Services;

public class UserDatabaseService : IUserService{
private readonly AppDbContext banco;
public UserDatabaseService(AppDbContext banco)
{
    this.banco = banco;
}

    public User CreateUser(User user)
    {
        
        banco.Add(user);
        banco.SaveChanges();
        return user;
    }

    public void DeleteUser(int id)
    {
        var user = banco.Find<User>(id);
        if (user != null)
        {
            banco.Remove(user);
            banco.SaveChanges();
        }
    }

    public List<User> GetAllUsers()
    {
        return banco.Set<User>().ToList();
    }

    public User GetUserById(int id)
    {
        return banco.Find<User>(id);
    }

    public User UpdateUser(int id, User user)
    {
        var existingUser = banco.Find<User>(id);
        if (existingUser == null)
        {
            throw new InvalidOperationException("User not found");
        }

        banco.Entry(existingUser).CurrentValues.SetValues(user);
        banco.SaveChanges();
        return existingUser;
    }
}

