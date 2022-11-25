using WMS_Inventory_API_Client.Models;
namespace WMS_Inventory_API_Client.Services.Interfaces
{
    public interface IStorageLocationService
    {
        Task<IEnumerable<StorageLocation>> FindAll();
        Task<StorageLocation> FindOne(int id);
    }
}