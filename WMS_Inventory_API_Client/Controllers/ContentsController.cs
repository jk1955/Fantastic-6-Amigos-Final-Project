using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using WMS_Inventory_API_Client.Models;
using WMS_Inventory_API_Client.Services.Interfaces;
using System.Web;

namespace WMS_Inventory_API_Client.Controllers
{
    public class ContentsController : Controller
    {
        private IContentService? _service;
        private IContainerService? _serviceContainer;

        public Uri UrlReferrer { get; }
        public object Server { get; }

        private static readonly HttpClient client = new HttpClient();

        private string requestUri = "https://localhost:7153/api/Contents/";

        public ContentsController(IContentService service, IContainerService serviceContainer)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _serviceContainer = serviceContainer ?? throw new ArgumentNullException(nameof(serviceContainer));

            client.DefaultRequestHeaders.Accept.Clear();

            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            client.DefaultRequestHeaders.Add("User-Agent", "Jim's API");

        }

        // Example: https://localhost:7153/api/Contents
        public async Task<IActionResult> Index()
        {
            TempData["returnUrl"] = Request.Headers["Referer"].ToString();

            TempData["Message"] = "";

            var response = await _service.FindAll();
            if (response == null)
            {
                TempData["Message"] = "API Request Not Found";
                //return RedirectToAction(nameof(Index));
                return RedirectToAction(ViewBag.returnUrl);
            }

            return View(response);
        }

        // GET: Content/Details/5
        public async Task<IActionResult> Details(int id)
        {
            TempData["returnUrl"] = Request.Headers["Referer"].ToString();

            TempData["Message"] = "";

            var content = await _service.FindOne(id);
            if (content == null)
            {
                TempData["Message"] = "API Request Not Found";

                return RedirectToAction(nameof(Index));
            }

            return View(content);
        }

        // GET: Content/Create
        public async Task<IActionResult> Create()
        {
            TempData["returnUrl"] = Request.Headers["Referer"].ToString();

            TempData["Message"] = "";

            var response = await _serviceContainer.FindAll();

            ViewData["ContainerId"] = new SelectList(response, "Id", "Description");

            return View();
        }

        // POST: Content/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Quantity,Description,containerId")] Content content) - Jim K 11/23/2022
        public async Task<IActionResult> Create(Content content)
        {
            TempData["returnUrl"] = Request.Headers["Referer"].ToString();

            TempData["Message"] = "";

            content.Id = null;
            var resultPost = await client.PostAsync<Content>(requestUri, content, new JsonMediaTypeFormatter());

            return RedirectToAction(nameof(Index));
        }

        // GET: Content/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            TempData["returnUrl"] = Request.Headers["Referer"].ToString();

            TempData["Message"] = "";

            var response = await _serviceContainer.FindAll();
            if (response == null)
            {
                TempData["Message"] = "API Request Not Found";
                return RedirectToAction(nameof(Index));
            }

            ViewData["ContainerId"] = new SelectList(response, "Id", "Description");

            var content = await _service.FindOne(id);
            if (content == null)
            {
                TempData["Message"] = "API Request Not Found";
                return RedirectToAction(nameof(Index));
            }

            return View(content);
        }

        // POST: Content/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Quantity,Description,containerId")] Content content) - Jim K 11/23/2022
        public async Task<IActionResult> Edit(int id, Content content)
        {
            TempData["returnUrl"] = Request.Headers["Referer"].ToString();

            TempData["Message"] = "";

            if (id != content.Id)
            {
                TempData["Message"] = "API Request Not Found";
                return RedirectToAction(nameof(Index));
            }
            
            var resultPut = await client.PutAsync<Content>(requestUri + content.Id.ToString(), content, new JsonMediaTypeFormatter());
            return RedirectToAction(nameof(Index));
            //return Redirect(TempData["returnUrl"].ToString());
        }

        // GET: Content/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            TempData["returnUrl"] = Request.Headers["Referer"].ToString();

            TempData["Message"] = "";

            var content = await _service.FindOne(id);
            if (content == null)
            {
                TempData["Message"] = "API Request Not Found";
                return RedirectToAction("Index", "Contents");
            }

            return View(content);
        }

        // POST: Content/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var resultDelete = await client.DeleteAsync(requestUri + id.ToString());
            return RedirectToAction(nameof(Index));
        }
    }
}