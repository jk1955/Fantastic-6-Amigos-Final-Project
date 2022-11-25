using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using WMS_Inventory_API_Client.Services.Interfaces;
using System.Diagnostics.Metrics;
using WMS_Inventory_API_Client.Helpers;
using System.ComponentModel.Design;

namespace WMS_Inventory_API_Client.Models
{
    public class Content : IContainerService
    {
        public int? Id { get; set; }
        public int? Quantity { get; set; }
        public string? Description { get; set; }
        public int? ContainerId { get; set; }
        public virtual Container? Container { get; set; }

        private static readonly HttpClient client = new HttpClient();

        public Content(int? ContainerId, int? quantity, string? description, int? containerId, Container? container)
        {
            Id = ContainerId;
            Quantity = quantity;
            Description = description;
            this.ContainerId = containerId;
            var tmp_container = (Container)this.FindOne((int)this.ContainerId).Result;
            if (tmp_container != null)
            {
                Container = tmp_container as Container;
            }
            else
            {
                Container = null;
            }

        }

        public Content()
        {
            return;
        }

        public Task<IEnumerable<Container>> FindAll()
        {
            throw new NotImplementedException();
        }

        public async Task<Container> FindOne(int id)
        {
            client.DefaultRequestHeaders.Accept.Clear();

            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            client.DefaultRequestHeaders.Add("User-Agent", "Jim's API");

            string requestUri = "https://localhost:7153/api/Containers/";

            var request = requestUri + id.ToString();
            var responseGet = await client.GetAsync(request);

            var response = await responseGet.ReadContentAsync<Container>();
            if (response != null)
            {
                var container = new Container(response.Id, response.Type, response.Description, response.StorageLocationId, response.StorageLocation, response.content);
                return (Container)container;
            }
            else
            {
                return null;
            }
        }
    }

}
