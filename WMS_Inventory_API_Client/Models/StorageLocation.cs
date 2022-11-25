using Microsoft.VisualBasic;

namespace WMS_Inventory_API_Client.Models
{
    public class StorageLocation
    {
        public int? Id { get; set; }
        public string? LocationName { get; set; }
        public string? Address1 { get; set; }
        public string? Address2 { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public int? ZipCode { get; set; }
        public double? Longitude { get; set; }
        public double? Latitude { get; set; }
        public int? AccountId { get; set; }
        public virtual List<Container>? container { get; set; }


         public StorageLocation (int? id, string? locationname, string? address1, string? address2, string? city, string? state, int? zipCode, double? longitude, double? latitude, int? accountid, List<Container> containerList)
        {
            Id = id;
            LocationName = locationname;
            Address1 = address1;
            Address2 = address2;
            City = city; 
            State = state; 
            ZipCode = zipCode;
            Longitude = longitude;
            Latitude = latitude;
            AccountId = accountid;
            var tmp_container = containerList ?? new List<Container>();
            container = tmp_container;

        }

        public StorageLocation()
        {
            return;
        }

    }
  


}
