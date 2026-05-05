using JobApplicationAPI.Models;

namespace JobApplicationAPI.Services.Interfaces;

public interface IUserService
{
    public List<User> GetAllUsers();
    public User GetUserById(int id);
    public User CreateUser(User user);
    public User UpdateUser(int id, User user);
    public void DeleteUser(int id);
}
