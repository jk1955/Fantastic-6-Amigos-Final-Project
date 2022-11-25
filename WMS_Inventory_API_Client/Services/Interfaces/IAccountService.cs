using WMS_Inventory_API_Client.Models;
namespace WMS_Inventory_API_Client.Services.Interfaces
{
    public interface IAccountService
    {
        Task<IEnumerable<Account>> FindAll();
        Task<Account> FindOne(int id);
    }
}