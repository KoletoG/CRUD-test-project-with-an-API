using CRUD_test_project_with_an_API.Models;

namespace CRUD_test_project_with_an_API.Repositories
{
    public interface IUserRepository
    {
        Task AddUsers(List<User> users); 
        Task AddAddress(List<Address> addresses);
    }
}
