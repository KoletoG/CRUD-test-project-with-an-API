using Microsoft.AspNetCore.Mvc;

namespace CRUD_test_project_with_an_API.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
