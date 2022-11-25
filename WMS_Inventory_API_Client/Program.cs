using WMS_Inventory_API_Client.Services;
using WMS_Inventory_API_Client.Services.Interfaces;
namespace WMS_Inventory_API_Client
{
    public class Program
    {
        public static ServiceDescriptor? account { get; private set; }
        public static ServiceDescriptor? content { get; private set; }
        public static ServiceDescriptor? container { get; private set; }
        public static ServiceDescriptor? storageLocation { get; private set; }
       
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // Add services to the container
            builder.Services.AddControllersWithViews();

            builder.Services.AddHttpClient<IAccountService, AccountService>(c=>
            c.BaseAddress = new Uri("https://localhost:7153/"));
            
            builder.Services.AddHttpClient<IContentService, ContentService>(c=>
            c.BaseAddress = new Uri("https://localhost:7153/"));
            
            builder.Services.AddHttpClient<IContainerService, ContainerService>(c=>
            c.BaseAddress = new Uri("https://localhost:7153/"));

            builder.Services.AddHttpClient<IStorageLocationService, StorageLocationService>(c=>
            c.BaseAddress = new Uri("https://localhost:7153/"));
            
            var app = builder.Build();
            // Configure the HTTP request pipeline.
            
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            
            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
                
            app.Run();
        }
    }
}