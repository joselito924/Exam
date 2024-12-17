using ExamModel;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ExamWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:7134/api/UserProfile");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var aw = await response.Content.ReadAsStringAsync();
            IEnumerable<UserProfileDTO> userLst = JsonSerializer.Deserialize<IEnumerable<UserProfileDTO>>(aw)!;
            return View(userLst);
        }

        public ActionResult Add()
        {
            return View(new UserProfileDTOAddUpdate());
        }

        // POST: UserProfileController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(UserProfileDTOAddUpdate collection)
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Post, "https://localhost:7134/api/UserProfile");
                var strColl = JsonSerializer.Serialize(collection);
                var content = new StringContent(strColl, null, "application/json");
                request.Content = content;
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                var result = await response.Content.ReadAsStringAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserProfileController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://localhost:7134/api/UserProfile/{id}");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var aw = await response.Content.ReadAsStringAsync();
            UserProfileDTOAddUpdate user = JsonSerializer.Deserialize<UserProfileDTOAddUpdate>(aw)!;
            return View(user);
        }

        // POST: UserProfileController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UserProfileDTOAddUpdate collection)
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Put, $"https://localhost:7134/api/UserProfile/{id}");
                var strColl = JsonSerializer.Serialize(collection);
                var content = new StringContent(strColl, null, "application/json");
                request.Content = content;
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                var result = await response.Content.ReadAsStringAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserProfileController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://localhost:7134/api/UserProfile/{id}");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var aw = await response.Content.ReadAsStringAsync();
            UserProfileDTOAddUpdate user = JsonSerializer.Deserialize<UserProfileDTOAddUpdate>(aw)!;
            return View(user);
        }

        // POST: UserProfileController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, UserProfileDTOAddUpdate collection)
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Delete, $"https://localhost:7134/api/UserProfile/{id}");
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                var aw = await response.Content.ReadAsStringAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

    }
}
