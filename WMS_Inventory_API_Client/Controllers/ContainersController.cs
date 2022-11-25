using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using WMS_Inventory_API_Client.Models;
using WMS_Inventory_API_Client.Services.Interfaces;
using Container = WMS_Inventory_API_Client.Models.Container;

namespace WebMVC_API_Client.Controllers
{
    public class ContainerController : Controller
    {
        private IContainerService? _service;
        private IStorageLocationService? _serviceStorageLocation;

        private static readonly HttpClient client = new HttpClient();

        private string requestUri = "https://localhost:7153/api/Containers/";

        public ContainerController(IContainerService service, IStorageLocationService serviceStorageLocation)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _serviceStorageLocation = serviceStorageLocation ?? throw new ArgumentNullException(nameof(serviceStorageLocation));

            client.DefaultRequestHeaders.Accept.Clear();

            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            client.DefaultRequestHeaders.Add("User-Agent", "Jim's API");
        }

        // Example: https://localhost:7153/api/Containers
        public async Task<IActionResult> Index()
        {
            TempData["Message"] = "";

            var response = await _service.FindAll();
            if (response == null)
            {
                TempData["Message"] = "API Request Not Found";
                return RedirectToAction("Index", "Container");
            }

            return View(response);
        }

        // GET: Container/Details/5
        public async Task<IActionResult> Details(int id)
        {
            TempData["Message"] = "";

            var container = await _service.FindOne(id);
            if (container == null)
            {
                TempData["Message"] = "API Request Not Found";
                return RedirectToAction("Index", "Container");
            }

            return View(container);
        }

        // GET: Container/Create
        public async Task<IActionResult> Create()
        {
            TempData["Message"] = "";

            var response = await _serviceStorageLocation.FindAll();

            ViewData["StorageLocationId"] = new SelectList(response, "Id", "LocationName");
            return View();
        }

        // POST: Container/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Type,Description,StorageLocationID")] Container container) - Jim K 11/23/2022
        public async Task<IActionResult> Create(Container container)
        {
            TempData["Message"] = "";

            container.Id = null;
            var resultPost = await client.PostAsync<Container>(requestUri, container, new JsonMediaTypeFormatter());

            return RedirectToAction(nameof(Index));
        }

        // GET: Container/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            TempData["Message"] = "";

            var response = await _serviceStorageLocation.FindAll();
            ViewData["StorageLocationId"] = new SelectList(response, "Id", "LocationName");

            var container = await _service.FindOne(id);
            if (container == null)
            {
                TempData["Message"] = "API Request Not Found";
                return RedirectToAction("Index", "Container");
            }

            return View(container);
        }

        // POST: Container/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Type,Description,StorageLocationID,StorageLocation")] Container container) - Jim K 11/23/2022
        public async Task<IActionResult> Edit(int id, Container container)
        {
            TempData["Message"] = "";

            if (id != container.Id)
            {
                TempData["Message"] = "API Request Not Found";
                return RedirectToAction("Index", "Container");
            }

            var resultPut = await client.PutAsync<Container>(requestUri + container.Id.ToString(), container, new JsonMediaTypeFormatter());
            return RedirectToAction(nameof(Index));
        }

        // GET: Container/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            TempData["Message"] = "";

            var container = await _service.FindOne(id);
            if (container == null)
            {
                TempData["Message"] = "API Request Not Found";
                return RedirectToAction("Index", "Container");
            }

            return View(container);
        }

        // POST: Container/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var resultDelete = await client.DeleteAsync(requestUri + id.ToString());
            return RedirectToAction(nameof(Index));
        }
    }
}