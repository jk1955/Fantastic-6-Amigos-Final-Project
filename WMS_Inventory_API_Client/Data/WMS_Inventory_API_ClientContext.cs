using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WMS_Inventory_API_Client.Models;

namespace WMS_Inventory_API_Client.Data
{
    public class WMS_Inventory_API_ClientContext : DbContext
    {
        public WMS_Inventory_API_ClientContext (DbContextOptions<WMS_Inventory_API_ClientContext> options)
            : base(options)
        {
        }

        public DbSet<WMS_Inventory_API_Client.Models.Account> Account { get; set; } = default!;

        public DbSet<WMS_Inventory_API_Client.Models.StorageLocation> StorageLocation { get; set; }

        public DbSet<WMS_Inventory_API_Client.Models.Container> Container { get; set; }

        public DbSet<WMS_Inventory_API_Client.Models.Content> Content { get; set; }
    }
}
