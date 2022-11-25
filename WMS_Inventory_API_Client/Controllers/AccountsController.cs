using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using WMS_Inventory_API_Client.Models;
using WMS_Inventory_API_Client.Services.Interfaces;

namespace WMS_Inventory_API_Client.Controllers

{
    public class AccountsController : Controller
    {
        private IAccountService? _service;
        private static readonly HttpClient client = new HttpClient();
        private string requestUri = "https://localhost:7153/api/Accounts/";
        public AccountsController(IAccountService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("User-Agent", "Jim's API");
        }
        // Example: https://localhost:7153/api/Accounts
        public async Task<IActionResult> Index()
        {
            var response = await _service.FindAll();
            return View(response);
        }
        // GET: Account/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var account = await _service.FindOne(id);
            if (account == null)
            {
                return NotFound();
            }
            return View(account);
        }
        // GET: Account/Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: Account/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Address1,Address2,City,State,ZipCode,Email,Password")] Account account)
        {
            account.Id = null;
            var resultPost = await client.PostAsync<Account>(requestUri, account, new JsonMediaTypeFormatter());
            return RedirectToAction(nameof(Index));
        }
        // GET: Account/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var account = await _service.FindOne(id);
            if (account == null)
            {
                return NotFound();
            }
            return View(account);
        }
        // POST: Account/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Address1,Address2,City,State,ZipCode,Email,Password")] Account account)
        {
            if (id != account.Id)
            {
                return NotFound();
            }
            var resultPut = await client.PutAsync<Account>(requestUri + account.Id.ToString(), account, new JsonMediaTypeFormatter());
            return RedirectToAction(nameof(Index));
        }
        // GET: Account/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var account = await _service.FindOne(id);
            if (account == null)
            {
                return NotFound();
            }
            return View(account);
        }
        // POST: Account/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var resultDelete = await client.DeleteAsync(requestUri + id.ToString());
            return RedirectToAction(nameof(Index));
        }
    }
}