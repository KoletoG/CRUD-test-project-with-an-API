using CRUD_test_project_with_an_API.Exceptions;
using CRUD_test_project_with_an_API.Models;
using CRUD_test_project_with_an_API.Repositories;
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
        private readonly IUserRepository _userRepository;
        public UserController(ILogger<UserController> logger, IUserRepository userRepository)
        {
            _logger= logger;
            _userRepository= userRepository;
        }
        public async Task<IActionResult> GetUsersFromAPI()
        {
            try {
                string api = "https://jsonplaceholder.typicode.com/users";
                HttpResponseMessage response = await client.GetAsync(api);
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    var usersAPI = System.Text.Json.JsonSerializer.Deserialize<List<User>>(json);
                    foreach (var user in usersAPI)
                    {
                        user.Address.SetLatLng();
                    }
                    return View("Index", new UserViewModel(usersAPI));
                }
                else
                {
                    throw new HttpRequestException();
                }
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, $"An error has occured in {nameof(GetUsersFromAPI)}");
                return View("Error");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveUser(List<User> users)
        {
            try
            {

                List<Address> addresses = new List<Address>();
                /*
                List<User> newUsers = new List<User>();
                List<User> usersToUpdate = new List<User>();
                */
                foreach (var user in users)
                {
                    if (string.IsNullOrEmpty(user.Note))
                    {
                        user.Note = "";
                    }
                    user.Address.UserId = user.Id;
                    addresses.Add(user.Address);
                    /*
                    var resultFromFetch = await _userRepository.FetchUser(user.Id);
                    if (resultFromFetch == default)
                    {
                        newUsers.Add(user);
                        user.Address.UserId = user.Id;
                        addresses.Add(user.Address);
                    }
                    else
                    {
                        if (resultFromFetch.Note != user.Note || resultFromFetch.IsActive!=user.IsActive)
                        {
                            usersToUpdate.Add(user);
                        }
                    }
                    */
                }
                /*
                if (users.Any())
                {
                    await _userRepository.UpdateUsers(usersToUpdate);
                }
                if(newUsers.Any())
                {
                    await _userRepository.AddUsers(newUsers);
                }
                if (addresses.Any())
                {
                    await _userRepository.AddAddress(addresses);
                }*/
                await _userRepository.AddUsers(users);
                await _userRepository.AddAddress(addresses);
                TempData["Message"] = "Users save successfully!";
                return View("Index", new UserViewModel());
            }
            catch (DbCustomException)
            {
                TempData["Message"] = "There was a problem with saving the users!";
                return View("Index", new UserViewModel());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error has occured in {nameof(SaveUser)}");
                return View("Error");
            }
        }
        public IActionResult Index()
        {
            TempData["Message"] = "";
            return View(new UserViewModel());
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
