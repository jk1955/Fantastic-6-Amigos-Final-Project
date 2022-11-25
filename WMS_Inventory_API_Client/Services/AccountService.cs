using WMS_Inventory_API_Client.Helpers;
using WMS_Inventory_API_Client.Models;
using WMS_Inventory_API_Client.Services.Interfaces;

namespace WMS_Inventory_API_Client.Services
{
    public class AccountService : IAccountService
    {
        private readonly HttpClient _client;
        public const string BasePath = "/api/Accounts/";
        public AccountService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }
        public async Task<IEnumerable<Account>> FindAll()
        {
            var responseGet = await _client.GetAsync(BasePath);
            var response = await responseGet.ReadContentAsync<List<Account>>();
            if (response != null)
            {
                return response;
            }
            else
            {
                return null;
            }
        }

        public async Task<Account> FindOne(int id)
        {
            var request = BasePath + id.ToString();
            var responseGet = await _client.GetAsync(request);
            var response = await responseGet.ReadContentAsync<Account>();

            if (response != null)
            {
                var account = new Account(response.Id, response.Name, response.Address1, response.Address2, response.City, response.State, response.ZipCode, response.Email, response.Password);
                return account;
            }
            else
            {
                return null;
            }
        }
    }
}