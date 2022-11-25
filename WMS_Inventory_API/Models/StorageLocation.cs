namespace WMS_Inventory_API.Models
{
    public class StorageLocation
    {
        public int Id { get; set; }
        public string? LocationName { get; set; }
        public string? Address1 { get; set; }
        public string? Address2 { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public int? ZipCode { get; set; }
        public double? Longitude { get; set; }
        public double? Latitude { get; set; }
        public int? AccountId { get; set; }
        public virtual List<Container>? Container { get; set; }
    }

}
