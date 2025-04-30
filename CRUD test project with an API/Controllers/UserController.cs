using CRUD_test_project_with_an_API.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text.Json;

namespace CRUD_test_project_with_an_API.Controllers
{
    public class UserController : Controller
    {
        private static readonly HttpClient client = new HttpClient();
        private readonly ILogger<UserController> _logger;
        public UserController(ILogger<UserController> logger)
        {
            _logger= logger;
        }
        public async Task<IActionResult> GetUsersFromAPI()
        {
            string api = "https://jsonplaceholder.typicode.com/users";
            HttpResponseMessage response = await client.GetAsync(api);
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                var usersAPI = System.Text.Json.JsonSerializer.Deserialize<List<User>>(json);
                foreach(var user in usersAPI)
                {
                    user.Address.SetLatLng();
                }
                return View("Index",new UserViewModel(usersAPI));
            }

            return View("Error");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveUser(List<User> users)
        {
            return RedirectToAction("Index");
        }
        public IActionResult Index()
        {
            return View(new UserViewModel());
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
