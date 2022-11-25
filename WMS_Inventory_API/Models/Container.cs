using System.Diagnostics.Metrics;

namespace WMS_Inventory_API.Models
{
    public class Container
    {
        public int Id { get; set; }
        public string? Type { get; set; }
        public string? Description { get; set; }
        public int? StorageLocationId { get; set; }
        public virtual StorageLocation? StorageLocation { get; set; }
        public virtual List<Content>? Content { get; set; }
    }
}
