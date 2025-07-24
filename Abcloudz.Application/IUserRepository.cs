namespace Abcloudz.Application;

public interface IRepository<T>
{
    Task<List<T>> GetUsers();
    Task AddUser(T user);
}