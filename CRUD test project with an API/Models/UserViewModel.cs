namespace CRUD_test_project_with_an_API.Models
{
    public class UserViewModel
    {
        public List<User> Users { get; init; }
        public bool IsSaveButtonShowing { get; init; }
        public UserViewModel(List<User> users, bool isSaveButtonShowing = false)
        { 
            Users = users;
            IsSaveButtonShowing = isSaveButtonShowing;
        }
        public UserViewModel()
        {
            Users = new List<User>();
        }
    }
}
