using CRUD_test_project_with_an_API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CRUD_test_project_with_an_API.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        public UserController(ILogger<UserController> logger)
        {
            _logger= logger;
        }
        public IActionResult Index()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
