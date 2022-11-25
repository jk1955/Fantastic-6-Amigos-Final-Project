namespace WMS_Inventory_API_Client.Models
{
    public class Account
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Address1 { get; set; }
        public string? Address2 { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public int? ZipCode { get; set; }
        public string? Email {get; set;}
        public string? Password {get; set;}
        public virtual List<StorageLocation>? storageLocations { get; set; }

        public Account(int? id, string? name, string? address1, string? address2, string? city, string? state, int? zipCode, string? email, string? password)
        {
            Id = id;
            Name = name;
            Address1 = address1;
            Address2 = address2;
            City = city;
            State = state;
            ZipCode = zipCode;
            Email = email;
            Password = password;
        }

        public Account()
        {
            return;
        }
    }
}


