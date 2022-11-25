using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Host.Mef;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using WMS_Inventory_API_Client.Models;
using WMS_Inventory_API_Client.Services.Interfaces;
namespace WMS_Inventory_API_Client.Controllers
{
    public class StorageLocationController : Controller
    {
        private IStorageLocationService? _service;
        private IAccountService? _serviceAccount;
        private static readonly HttpClient client = new HttpClient();
        private string requestUri = "https://localhost:7153/api/StorageLocations/";

        public StorageLocationController(IStorageLocationService service, IAccountService serviceAccount)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _serviceAccount = serviceAccount ?? throw new ArgumentNullException(nameof(serviceAccount));
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("User-Agent", "Inventory API");
        }
        // Example: https://localhost:7256/api/StorageLocations
        public async Task<IActionResult> Index()
        {
            var response = await _service.FindAll();
            return View(response);
        }
        // GET: StorageLocation/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var storageLocation = await _service.FindOne(id);
            if (storageLocation == null)
            {
                return NotFound();
            }
            return View(storageLocation);
        }
        // GET: StorageLocation/Create
        public async Task<IActionResult> Create()
        {
            var response = await _serviceAccount.FindAll();
            ViewData["AccountId"] = new SelectList(response, "Id", "Name");
            return View();
        }
        // POST: StorageLocation/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id, LocationName, Address1, Address2, City, State, ZipCode, Longitude, Latitude, AccountId")] StorageLocation storageLocation)
        {
            storageLocation.Id = null;
            var resultPost = await client.PostAsync<StorageLocation>(requestUri, storageLocation, new JsonMediaTypeFormatter());
            return RedirectToAction(nameof(Index));
        }
        // GET: StorageLocation/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var storageLocation = await _service.FindOne(id);
            if (storageLocation == null)
            {
                return NotFound();
            }
            return View(storageLocation);
        }
        // POST: StorageLocation/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id, LocationName, Address1, Address2, City, State, ZipCode, Longitude, Latitude, AccountId")] StorageLocation storageLocation)
        {
            if (id != storageLocation.Id)
            {
                return NotFound();
            }
            var resultPut = await client.PutAsync<StorageLocation>(requestUri + storageLocation.Id.ToString(), storageLocation, new JsonMediaTypeFormatter());
            return RedirectToAction(nameof(Index));
        }
        // GET: StorageLocation/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var storageLocation = await _service.FindOne(id);
            if (storageLocation == null)
            {
                return NotFound();
            }
            return View(storageLocation);
        }
        // POST: StorageLocation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var resultDelete = await client.DeleteAsync(requestUri + id.ToString());
            return RedirectToAction(nameof(Index));
        }
    }
}