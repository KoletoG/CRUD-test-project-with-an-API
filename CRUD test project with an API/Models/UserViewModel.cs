namespace CRUD_test_project_with_an_API.Models
{
    public class UserViewModel
    {
        public List<User> Users { get; set; }
        public UserViewModel(List<User> users)
        { 
            Users = users;
        }
        public UserViewModel()
        {
            Users = new List<User>();
        }
    }
}
