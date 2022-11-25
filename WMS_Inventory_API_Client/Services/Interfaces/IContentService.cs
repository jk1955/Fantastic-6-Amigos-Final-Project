using WMS_Inventory_API_Client.Models;
namespace WMS_Inventory_API_Client.Services.Interfaces
{
    public interface IContentService
    {
        Task<IEnumerable<Content>> FindAll();
        Task<Content> FindOne(int id);
    }
}