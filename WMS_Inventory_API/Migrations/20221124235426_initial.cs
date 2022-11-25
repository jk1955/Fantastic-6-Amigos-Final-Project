using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WMS_Inventory_API.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCode = table.Column<int>(type: "int", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StorageLocation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCode = table.Column<int>(type: "int", nullable: true),
                    Longitude = table.Column<double>(type: "float", nullable: true),
                    Latitude = table.Column<double>(type: "float", nullable: true),
                    AccountId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StorageLocation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Container",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StorageLocationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Container", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Content",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContainerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Content", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "Id", "Address1", "Address2", "City", "Email", "Name", "Password", "State", "ZipCode" },
                values: new object[] { 1, "5814 N 17th St", "", "Tampa", "charles.baker@gmail.com", "Charles Baker", "password", "FL", 33610 });

            migrationBuilder.InsertData(
                table: "StorageLocation",
                columns: new[] { "Id", "AccountId", "Address1", "Address2", "City", "Latitude", "LocationName", "Longitude", "State", "ZipCode" },
                values: new object[] { 1, 1, "5814 N 17th St", "", "Tampa", -82.440321999999995, "Home Shop", 27.995778000000001, "FL", 33610 });

            migrationBuilder.InsertData(
                table: "StorageLocation",
                columns: new[] { "Id", "AccountId", "Address1", "Address2", "City", "Latitude", "LocationName", "Longitude", "State", "ZipCode" },
                values: new object[] { 2, 1, "1711 E Hillsborough Ave", "", "Tampa", -82.441528000000005, "Extra Space Storage", 28.000686999999999, "FL", 33610 });

            migrationBuilder.InsertData(
                table: "Container",
                columns: new[] { "Id", "Description", "StorageLocationId", "Type" },
                values: new object[,]
                {
                    { 1, "Brown corrugated box containing hand tools", 2, "Box" },
                    { 2, "Clear plastic w/ blue lid - metal fasteners", 2, "Tote" },
                    { 3, "Blue painted wooden chest - fishing tackle", 1, "Chest" },
                    { 4, "Far left cabinet under built in work bench", 1, "Cabinet" }
                });

            migrationBuilder.InsertData(
                table: "Content",
                columns: new[] { "Id", "ContainerId", "Description", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, "5 lbs box 2 inch cut nails", 1 },
                    { 2, 1, "1 lbs box 2 1/2 in cut nails", 3 },
                    { 3, 1, "Misc boxes of cut nails - finish, box, brad", 6 },
                    { 4, 1, "Misc boxes wood screws, brass/bronze, #8/9, 3/4 in - 1 1/2 in", 4 },
                    { 5, 2, "Mom's winter clothes - slacks, tops, sweaters", 25 },
                    { 6, 3, "Box of fly reels - Berkley, Ross, Pflueger", 1 },
                    { 7, 3, "Leonard 37H flyrod", 1 },
                    { 8, 3, "Orvis Fullflex fly/spin rod", 1 },
                    { 9, 3, "Box of spinning reels - Shakespeare, Micron, Mitchell", 1 },
                    { 10, 4, "Makita 7 1/4 in track saw", 1 },
                    { 11, 4, "Parallel guides for Makita track", 1 },
                    { 12, 4, "Makita 10 in circular saw", 1 },
                    { 13, 4, "Skilsaw 5 1/2 in circular saw", 1 },
                    { 14, 4, "Ryobi One+ tools - 1/2 in drill, finish sander, brad nailer", 3 },
                    { 15, 4, "Milwaukee 7 1/4 in circular saw", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Container_StorageLocationId",
                table: "Container",
                column: "StorageLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Content_ContainerId",
                table: "Content",
                column: "ContainerId");

            migrationBuilder.CreateIndex(
                name: "IX_StorageLocation_AccountId",
                table: "StorageLocation",
                column: "AccountId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Content");

            migrationBuilder.DropTable(
                name: "Container");

            migrationBuilder.DropTable(
                name: "StorageLocation");

            migrationBuilder.DropTable(
                name: "Account");
        }
    }
}
