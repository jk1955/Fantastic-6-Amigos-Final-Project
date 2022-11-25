namespace WMS_Inventory_API.Models
{
    public class Content
    {
        public int Id { get; set; }
        public int? Quantity { get; set; }
        public string? Description { get; set; }
        public int? ContainerId { get; set; }
        public virtual Container? Container { get; set; }
    }
}
