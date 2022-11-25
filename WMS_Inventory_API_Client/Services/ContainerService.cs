using System.Diagnostics.Metrics;
using WMS_Inventory_API_Client.Helpers;
using WMS_Inventory_API_Client.Models;
using WMS_Inventory_API_Client.Services.Interfaces;
namespace WMS_Inventory_API_Client.Services
{
    public class ContainerService : IContainerService
    {
        private readonly HttpClient _client;
        public const string BasePath = "/api/Containers/";
        public ContainerService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }
        public async Task<IEnumerable<Container>> FindAll()
        {
            var responseGet = await _client.GetAsync(BasePath);
            var response = await responseGet.ReadContentAsync<List<Container>>();
            if (response != null)
            {
                return response;
            }
            else
            {
                return null;
            }
        }

        public async Task<Container> FindOne(int id)
        {
            var request = BasePath + id.ToString();
            var responseGet = await _client.GetAsync(request);

            var response = await responseGet.ReadContentAsync<Container>();
            if (response != null)
            {
                var container = new Container(response.Id, response.Type, response.Description, response.StorageLocationId, response.StorageLocation, response.content);
                return container;
            }
            else
            {
                return null;
            }

        }
    }
}
