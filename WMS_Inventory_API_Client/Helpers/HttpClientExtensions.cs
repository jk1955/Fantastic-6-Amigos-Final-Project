using System.Text.Json;

namespace WMS_Inventory_API_Client.Helpers
{
    public static class HttpClientExtensions
    {
        public static async Task<T?> ReadContentAsync<T>(this HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode == false)
            {
                //throw new ApplicationException($"Something went wrong calling the API: {response.ReasonPhrase}");
                return default;
            }


            var dataAsString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            var result = JsonSerializer.Deserialize<T>(
                dataAsString, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

            return result;
        }
    }
}
