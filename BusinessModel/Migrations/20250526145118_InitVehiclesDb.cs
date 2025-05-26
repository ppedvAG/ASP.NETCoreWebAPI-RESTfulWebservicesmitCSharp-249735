using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BusinessModel.Migrations
{
    /// <inheritdoc />
    public partial class InitVehiclesDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    VehicleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Manufacturer = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Model = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fuel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TopSpeed = table.Column<int>(type: "int", nullable: false),
                    Color = table.Column<int>(type: "int", nullable: false),
                    Registered = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.VehicleId);
                    table.ForeignKey(
                        name: "FK_Vehicles_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId");
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Email", "Name" },
                values: new object[,]
                {
                    { new Guid("1c4aefcf-3f50-1dbe-bc37-dc2c83eba16a"), "Shawn.Wehner47@yahoo.com", "Shawn Wehner" },
                    { new Guid("3cb7f9b3-85d1-23ad-aa3a-2e6b8da00bd3"), "Shelly.Dickinson@yahoo.com", "Shelly Dickinson" },
                    { new Guid("53b46ce3-c495-45f8-bb21-e3223be699bd"), "Bonnie9@hotmail.com", "Bonnie Klocko" },
                    { new Guid("56e4d356-6ad4-1ceb-297d-f43ba57605ae"), "Rudolph27@hotmail.com", "Rudolph Wisoky" },
                    { new Guid("64d280ee-2551-7735-094e-204bbdabd40d"), "Ivan94@gmail.com", "Ivan White" },
                    { new Guid("67d62fc2-d2f4-37af-dba6-43cb097790ef"), "Beatrice14@yahoo.com", "Beatrice Graham" },
                    { new Guid("693781a7-9a81-ebad-b3bf-2989fd0051c6"), "Elbert71@hotmail.com", "Elbert McGlynn" },
                    { new Guid("8fb4415b-f183-c2fc-5d0e-0b8f61bbefc4"), "Saul.Greenfelder80@hotmail.com", "Saul Greenfelder" },
                    { new Guid("96ba173e-04ae-3bcd-9986-9e56f0adbf3a"), "Carol70@gmail.com", "Carol Schultz" },
                    { new Guid("a8fa1f63-5668-733f-4067-ba52b67539ea"), "Della.Klein@gmail.com", "Della Klein" }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "VehicleId", "Color", "Fuel", "Manufacturer", "Model", "OrderId", "Registered", "TopSpeed", "Type" },
                values: new object[,]
                {
                    { new Guid("006adfca-3234-d9a6-8458-ba625ef11604"), 41, "Diesel", "Ferrari", "Roadster", null, new DateTime(2006, 12, 22, 5, 3, 0, 422, DateTimeKind.Unspecified).AddTicks(2981), 230, "Cargo Van" },
                    { new Guid("06accc59-f220-b0ab-6df5-3f239bdf43c0"), 126, "Hybrid", "Mini", "ATS", null, new DateTime(2013, 12, 31, 1, 25, 22, 756, DateTimeKind.Unspecified).AddTicks(5655), 190, "Extended Cab Pickup" },
                    { new Guid("06dcf357-27fb-124c-6fd4-4e017ead058d"), 78, "Electric", "Audi", "Durango", null, new DateTime(2013, 2, 12, 23, 58, 49, 837, DateTimeKind.Unspecified).AddTicks(1136), 300, "Convertible" },
                    { new Guid("08958e61-1d92-66f1-e6e1-b6068af32981"), 56, "Hybrid", "Toyota", "Prius", null, new DateTime(2018, 4, 10, 19, 10, 5, 769, DateTimeKind.Unspecified).AddTicks(1329), 280, "Convertible" },
                    { new Guid("098b6ecc-5714-b09a-36cf-d6280bb3c707"), 35, "Diesel", "Porsche", "A4", null, new DateTime(2015, 1, 5, 20, 13, 4, 66, DateTimeKind.Unspecified).AddTicks(4443), 100, "Extended Cab Pickup" },
                    { new Guid("0af6fda0-05a9-bbbd-8f5c-a96bc06147f9"), 50, "Diesel", "Fiat", "Expedition", null, new DateTime(2012, 3, 17, 6, 18, 8, 119, DateTimeKind.Unspecified).AddTicks(5964), 110, "Wagon" },
                    { new Guid("0bd0bf25-e516-0354-b8a6-aa71bae89d6a"), 171, "Diesel", "Jeep", "2", null, new DateTime(2007, 12, 19, 21, 28, 15, 242, DateTimeKind.Unspecified).AddTicks(2188), 210, "SUV" },
                    { new Guid("0cd2476d-22ff-a160-fe82-636220dd5ec1"), 109, "Hybrid", "Bugatti", "Aventador", null, new DateTime(2011, 1, 6, 16, 53, 52, 237, DateTimeKind.Unspecified).AddTicks(3211), 100, "Hatchback" },
                    { new Guid("10b568e4-c9ac-6fff-4f70-a8ba24cfce1b"), 175, "Hybrid", "Smart", "A8", null, new DateTime(1999, 11, 15, 14, 47, 14, 530, DateTimeKind.Unspecified).AddTicks(3888), 170, "SUV" },
                    { new Guid("123dcc42-932a-575f-1891-4e024f1a8b37"), 49, "Electric", "Mazda", "2", null, new DateTime(2011, 10, 20, 15, 25, 53, 699, DateTimeKind.Unspecified).AddTicks(1825), 290, "Passenger Van" },
                    { new Guid("15d9db3a-360b-74af-09bc-8d06139b8a12"), 143, "Gasoline", "Chevrolet", "Ranchero", null, new DateTime(2013, 2, 2, 16, 0, 10, 364, DateTimeKind.Unspecified).AddTicks(5518), 210, "Passenger Van" },
                    { new Guid("1619e292-deeb-4447-3ab6-6090fabe4307"), 142, "Diesel", "Volkswagen", "Sentra", null, new DateTime(1990, 4, 7, 18, 14, 20, 114, DateTimeKind.Unspecified).AddTicks(6169), 180, "Hatchback" },
                    { new Guid("16cd8fde-2f40-7667-eaab-9a9125d17462"), 163, "Diesel", "Mercedes Benz", "Focus", null, new DateTime(1990, 11, 11, 18, 22, 53, 520, DateTimeKind.Unspecified).AddTicks(803), 180, "Extended Cab Pickup" },
                    { new Guid("19eee610-a1d2-705e-ee10-bebaa1d66332"), 145, "Diesel", "BMW", "Land Cruiser", null, new DateTime(1992, 2, 22, 15, 12, 15, 647, DateTimeKind.Unspecified).AddTicks(512), 300, "Hatchback" },
                    { new Guid("1a1d848b-0130-6ce4-423d-012e9b06ee37"), 145, "Electric", "Chevrolet", "ATS", null, new DateTime(2018, 4, 6, 22, 4, 31, 644, DateTimeKind.Unspecified).AddTicks(6978), 120, "Convertible" },
                    { new Guid("1e0f0cef-238d-454c-64f9-cc86122741b9"), 137, "Diesel", "Honda", "Model T", null, new DateTime(1992, 5, 29, 2, 39, 43, 938, DateTimeKind.Unspecified).AddTicks(9682), 200, "Passenger Van" },
                    { new Guid("204e0977-bd4b-d4ab-0dae-11f2d59ab044"), 87, "Electric", "Cadillac", "Fortwo", null, new DateTime(1993, 12, 31, 9, 55, 26, 940, DateTimeKind.Unspecified).AddTicks(2492), 220, "Passenger Van" },
                    { new Guid("2182eca5-e13f-42c6-f9dc-37bee9511e96"), 113, "Electric", "Chrysler", "Malibu", null, new DateTime(2003, 11, 29, 11, 0, 26, 744, DateTimeKind.Unspecified).AddTicks(27), 270, "Passenger Van" },
                    { new Guid("26ce265d-e3c3-e9bb-638d-cff1ef0589c7"), 147, "Hybrid", "Chevrolet", "Alpine", null, new DateTime(2021, 7, 27, 9, 50, 17, 365, DateTimeKind.Unspecified).AddTicks(5050), 240, "Crew Cab Pickup" },
                    { new Guid("2ae91fbb-c575-5b81-41b4-8f83f1fcc25d"), 100, "Gasoline", "Kia", "Altima", null, new DateTime(2006, 3, 19, 5, 27, 3, 405, DateTimeKind.Unspecified).AddTicks(9827), 170, "Sedan" },
                    { new Guid("2ecd2447-545c-91fc-cb8f-2fb63e6dad3b"), 150, "Hybrid", "Dodge", "Element", null, new DateTime(1991, 9, 12, 0, 29, 25, 445, DateTimeKind.Unspecified).AddTicks(5446), 180, "Extended Cab Pickup" },
                    { new Guid("317dd763-be0b-b0c6-2cb2-85df0a0aec73"), 44, "Diesel", "Kia", "LeBaron", null, new DateTime(2015, 9, 30, 10, 55, 30, 836, DateTimeKind.Unspecified).AddTicks(4947), 240, "Crew Cab Pickup" },
                    { new Guid("31e0ac69-24dd-d202-5526-f477402f12e2"), 130, "Hybrid", "Mini", "Cruze", null, new DateTime(1992, 11, 25, 4, 53, 21, 573, DateTimeKind.Unspecified).AddTicks(2147), 210, "Sedan" },
                    { new Guid("3538837d-c2c3-140b-7037-0e7728949097"), 157, "Gasoline", "Smart", "Camry", null, new DateTime(2014, 11, 8, 22, 32, 18, 554, DateTimeKind.Unspecified).AddTicks(7882), 280, "Coupe" },
                    { new Guid("3791e585-6cc3-b1c1-685a-953a6212a7cf"), 109, "Gasoline", "Mercedes Benz", "Roadster", null, new DateTime(2010, 11, 3, 2, 18, 6, 879, DateTimeKind.Unspecified).AddTicks(4971), 110, "SUV" },
                    { new Guid("39a63b1b-76fc-b554-a80f-1321d36c9b18"), 40, "Electric", "Audi", "Model 3", null, new DateTime(1998, 11, 3, 18, 44, 33, 135, DateTimeKind.Unspecified).AddTicks(796), 160, "Cargo Van" },
                    { new Guid("3b1ab42d-16a4-1ab3-1303-1cb588c82b5f"), 150, "Hybrid", "Hyundai", "Aventador", null, new DateTime(1999, 9, 27, 18, 48, 40, 304, DateTimeKind.Unspecified).AddTicks(6100), 110, "Coupe" },
                    { new Guid("3c2e96c4-9a05-1c50-36e1-72479b804065"), 91, "Electric", "BMW", "Jetta", null, new DateTime(1993, 7, 13, 10, 26, 24, 211, DateTimeKind.Unspecified).AddTicks(4072), 100, "Hatchback" },
                    { new Guid("3c3e5451-603c-7507-0cf1-f8b7e03d3190"), 106, "Gasoline", "Porsche", "ATS", null, new DateTime(2015, 3, 28, 14, 30, 27, 971, DateTimeKind.Unspecified).AddTicks(8568), 140, "Hatchback" },
                    { new Guid("40c0a3d7-0104-01f1-9927-7179d3d5aa42"), 141, "Gasoline", "Maserati", "Volt", null, new DateTime(2013, 12, 14, 19, 31, 30, 210, DateTimeKind.Unspecified).AddTicks(9295), 210, "Convertible" },
                    { new Guid("417ab0c9-9841-e4fe-f00e-18adc5bdf4ba"), 76, "Electric", "Dodge", "Mercielago", null, new DateTime(2014, 3, 13, 17, 28, 22, 199, DateTimeKind.Unspecified).AddTicks(3796), 280, "Wagon" },
                    { new Guid("4280e11f-668e-a858-50bd-ea058034ecd2"), 31, "Electric", "Kia", "Expedition", null, new DateTime(2019, 10, 17, 9, 57, 21, 230, DateTimeKind.Unspecified).AddTicks(2348), 300, "Extended Cab Pickup" },
                    { new Guid("4354ce0f-86ca-cf10-7573-c686424c3009"), 111, "Hybrid", "Mercedes Benz", "Grand Cherokee", null, new DateTime(1993, 10, 21, 18, 26, 23, 134, DateTimeKind.Unspecified).AddTicks(8356), 140, "Hatchback" },
                    { new Guid("46d24d60-75ad-f42d-55bd-86371979060d"), 120, "Hybrid", "Jaguar", "CX-9", null, new DateTime(2009, 5, 18, 20, 38, 5, 243, DateTimeKind.Unspecified).AddTicks(8184), 210, "Coupe" },
                    { new Guid("4af80b60-3e17-1dfd-8462-c009ca918154"), 150, "Electric", "BMW", "F-150", null, new DateTime(1990, 4, 16, 16, 27, 45, 17, DateTimeKind.Unspecified).AddTicks(2554), 250, "Crew Cab Pickup" },
                    { new Guid("57dfe75b-d6d1-ec53-0beb-388733e9a472"), 48, "Gasoline", "Volvo", "Accord", null, new DateTime(2009, 3, 25, 14, 30, 37, 354, DateTimeKind.Unspecified).AddTicks(4653), 240, "SUV" },
                    { new Guid("59c2ac19-7a94-bb04-9b52-759bbb43f4b5"), 153, "Diesel", "Porsche", "Silverado", null, new DateTime(1994, 6, 25, 1, 45, 36, 699, DateTimeKind.Unspecified).AddTicks(3278), 220, "Sedan" },
                    { new Guid("5d6ac921-e645-bf40-348b-b9e98b124ad4"), 170, "Hybrid", "Audi", "Silverado", null, new DateTime(2000, 2, 1, 20, 59, 19, 231, DateTimeKind.Unspecified).AddTicks(7590), 280, "Sedan" },
                    { new Guid("61e4cca9-c8c0-98c1-d46d-18c08ff15e9c"), 151, "Gasoline", "Jaguar", "Malibu", null, new DateTime(1996, 5, 2, 9, 5, 11, 822, DateTimeKind.Unspecified).AddTicks(9467), 140, "Passenger Van" },
                    { new Guid("680f3f97-4f7a-f041-4437-2f7eb2c714a0"), 79, "Hybrid", "Maserati", "Element", null, new DateTime(2017, 2, 26, 1, 2, 10, 542, DateTimeKind.Unspecified).AddTicks(7121), 260, "Crew Cab Pickup" },
                    { new Guid("6b325708-1c3d-9195-f070-53b2d5765263"), 70, "Hybrid", "Toyota", "Fiesta", null, new DateTime(2015, 10, 16, 15, 0, 11, 460, DateTimeKind.Unspecified).AddTicks(1521), 150, "Convertible" },
                    { new Guid("6b676e09-f1e7-460d-d827-baed2722fbb9"), 96, "Gasoline", "Ford", "Colorado", null, new DateTime(1990, 5, 21, 15, 32, 52, 850, DateTimeKind.Unspecified).AddTicks(9627), 110, "Cargo Van" },
                    { new Guid("6f833e07-6cbf-6139-021d-a5d53df4fdb1"), 76, "Electric", "Bugatti", "Land Cruiser", null, new DateTime(2011, 3, 1, 19, 44, 4, 533, DateTimeKind.Unspecified).AddTicks(1711), 210, "Coupe" },
                    { new Guid("7113de1b-d977-f0ba-a203-93da379b42a1"), 71, "Electric", "Kia", "Wrangler", null, new DateTime(1993, 12, 30, 10, 38, 16, 854, DateTimeKind.Unspecified).AddTicks(8968), 110, "Sedan" },
                    { new Guid("75b652ba-ea39-b4aa-7f82-ea75551b3e68"), 73, "Hybrid", "Land Rover", "Charger", null, new DateTime(2005, 6, 30, 18, 51, 54, 584, DateTimeKind.Unspecified).AddTicks(9082), 190, "Cargo Van" },
                    { new Guid("76682cb9-03df-6842-fed0-4b161ebeaaa4"), 61, "Hybrid", "Ferrari", "Grand Cherokee", null, new DateTime(1999, 11, 1, 5, 7, 46, 873, DateTimeKind.Unspecified).AddTicks(5307), 130, "SUV" },
                    { new Guid("78ae1d05-3b95-4031-b419-5fb60b073b30"), 84, "Hybrid", "Honda", "Land Cruiser", null, new DateTime(1992, 8, 7, 4, 1, 40, 855, DateTimeKind.Unspecified).AddTicks(7730), 150, "Convertible" },
                    { new Guid("7d0037c3-fac8-907e-bb09-ff57e9bccb7a"), 146, "Diesel", "Bentley", "LeBaron", null, new DateTime(2019, 2, 10, 9, 58, 1, 649, DateTimeKind.Unspecified).AddTicks(6898), 280, "Convertible" },
                    { new Guid("808e6e58-571c-936b-be21-4a55b8c465d9"), 174, "Gasoline", "Bugatti", "Wrangler", null, new DateTime(2015, 6, 15, 7, 28, 5, 333, DateTimeKind.Unspecified).AddTicks(6459), 110, "Crew Cab Pickup" },
                    { new Guid("885a74c8-413f-d273-bbc3-762e21631ffa"), 172, "Electric", "Lamborghini", "Roadster", null, new DateTime(2012, 4, 18, 3, 37, 36, 190, DateTimeKind.Unspecified).AddTicks(8261), 230, "Passenger Van" },
                    { new Guid("89e9ea31-9314-e14b-1437-c4a7d24a4028"), 52, "Diesel", "Jeep", "Impala", null, new DateTime(2016, 7, 20, 7, 20, 19, 569, DateTimeKind.Unspecified).AddTicks(1634), 260, "Cargo Van" },
                    { new Guid("8ae56a38-9ec7-e2fc-4853-efb3f9b73cd1"), 148, "Electric", "Fiat", "911", null, new DateTime(1990, 3, 17, 9, 40, 0, 377, DateTimeKind.Unspecified).AddTicks(2197), 130, "SUV" },
                    { new Guid("8c0d3f96-691b-4cc0-a8e0-3f05846b6734"), 122, "Diesel", "Mercedes Benz", "Cruze", null, new DateTime(1992, 8, 14, 12, 50, 59, 129, DateTimeKind.Unspecified).AddTicks(8378), 270, "Crew Cab Pickup" },
                    { new Guid("8e75add9-8587-cc0f-622e-347596b979ca"), 28, "Diesel", "Mazda", "Impala", null, new DateTime(2009, 2, 19, 6, 38, 51, 859, DateTimeKind.Unspecified).AddTicks(6221), 140, "Sedan" },
                    { new Guid("8e7c7406-87b9-1880-10e0-4480ea1527ee"), 71, "Hybrid", "Volvo", "Jetta", null, new DateTime(2007, 12, 3, 2, 59, 56, 923, DateTimeKind.Unspecified).AddTicks(9807), 130, "Convertible" },
                    { new Guid("9195a032-88c5-663c-edb8-21a01c4efdbf"), 165, "Diesel", "Porsche", "ATS", null, new DateTime(1997, 2, 16, 21, 29, 14, 402, DateTimeKind.Unspecified).AddTicks(7108), 100, "Coupe" },
                    { new Guid("9553b46c-f8c4-bb45-21e3-223be699bd78"), 32, "Diesel", "Cadillac", "Challenger", null, new DateTime(1992, 12, 11, 1, 38, 14, 405, DateTimeKind.Unspecified).AddTicks(1666), 270, "Crew Cab Pickup" },
                    { new Guid("96ba173e-04ae-3bcd-9986-9e56f0adbf3a"), 50, "Gasoline", "Kia", "Taurus", null, new DateTime(1992, 11, 19, 5, 40, 6, 742, DateTimeKind.Unspecified).AddTicks(682), 180, "SUV" },
                    { new Guid("9c911090-df69-85f9-f3fe-c57bd8ffa96c"), 129, "Hybrid", "Jaguar", "El Camino", null, new DateTime(2005, 4, 16, 20, 34, 31, 596, DateTimeKind.Unspecified).AddTicks(6569), 140, "Cargo Van" },
                    { new Guid("a34f83f4-fc7f-300a-f0cc-bef25b6334f6"), 75, "Hybrid", "Ferrari", "Colorado", null, new DateTime(1992, 6, 20, 18, 38, 51, 457, DateTimeKind.Unspecified).AddTicks(9546), 210, "Coupe" },
                    { new Guid("a59bfb55-2750-46b8-9d4a-7ad780dfb3bf"), 74, "Hybrid", "Audi", "Ranchero", null, new DateTime(1999, 1, 22, 3, 22, 6, 495, DateTimeKind.Unspecified).AddTicks(6471), 180, "Crew Cab Pickup" },
                    { new Guid("a5cc3829-7d2c-bbca-c4c8-0e5b83be5b41"), 48, "Electric", "Chrysler", "Model T", null, new DateTime(2013, 2, 3, 5, 48, 50, 296, DateTimeKind.Unspecified).AddTicks(7020), 100, "Convertible" },
                    { new Guid("a7d99d8e-4a4d-c60f-6398-e10e78b6b2cc"), 106, "Hybrid", "Audi", "A4", null, new DateTime(2003, 8, 15, 5, 3, 12, 13, DateTimeKind.Unspecified).AddTicks(5851), 270, "Cargo Van" },
                    { new Guid("aac27e00-53dc-8df7-431a-4d309c23d30c"), 34, "Hybrid", "Bugatti", "Model 3", null, new DateTime(2008, 1, 13, 16, 31, 21, 236, DateTimeKind.Unspecified).AddTicks(9236), 280, "Passenger Van" },
                    { new Guid("ac145341-0da4-ba8f-8d5f-38d3c8aee043"), 77, "Hybrid", "Kia", "Grand Caravan", null, new DateTime(1999, 4, 14, 4, 24, 15, 257, DateTimeKind.Unspecified).AddTicks(6408), 210, "Minivan" },
                    { new Guid("ac34f8de-1fce-8789-ef67-85b4b153e890"), 96, "Gasoline", "Mazda", "Fiesta", null, new DateTime(2011, 6, 18, 21, 26, 47, 41, DateTimeKind.Unspecified).AddTicks(4098), 110, "Extended Cab Pickup" },
                    { new Guid("aee4427e-fa9c-fc15-59a4-01ecdc416b86"), 97, "Hybrid", "Fiat", "Alpine", null, new DateTime(2014, 11, 14, 12, 37, 36, 685, DateTimeKind.Unspecified).AddTicks(650), 160, "SUV" },
                    { new Guid("afa886b3-7672-a763-8137-69819aadebb3"), 106, "Electric", "Audi", "Escalade", null, new DateTime(2002, 10, 28, 8, 52, 32, 934, DateTimeKind.Unspecified).AddTicks(3650), 260, "Convertible" },
                    { new Guid("b0df83c5-b1da-5025-bb3c-67891b904f04"), 44, "Gasoline", "Lamborghini", "Fiesta", null, new DateTime(1992, 11, 23, 0, 30, 11, 272, DateTimeKind.Unspecified).AddTicks(9364), 290, "Sedan" },
                    { new Guid("b4e5f92f-7184-82f5-7b4c-b3c188b2058b"), 62, "Diesel", "Polestar", "Altima", null, new DateTime(2015, 1, 13, 0, 34, 26, 78, DateTimeKind.Unspecified).AddTicks(6355), 290, "SUV" },
                    { new Guid("bb21a500-047c-4112-6168-2882be81dac1"), 103, "Electric", "Ferrari", "Ranchero", null, new DateTime(2021, 10, 29, 11, 56, 4, 199, DateTimeKind.Unspecified).AddTicks(7300), 160, "Coupe" },
                    { new Guid("bf090896-582b-0914-81b2-1c4d90ee1b7e"), 148, "Electric", "Land Rover", "Altima", null, new DateTime(1991, 5, 22, 7, 24, 34, 473, DateTimeKind.Unspecified).AddTicks(4739), 180, "Hatchback" },
                    { new Guid("c233bdf6-3030-072b-9951-ce3e47de6120"), 158, "Gasoline", "BMW", "Model S", null, new DateTime(2004, 5, 30, 15, 50, 6, 404, DateTimeKind.Unspecified).AddTicks(6007), 140, "Cargo Van" },
                    { new Guid("c2ed6317-ea7f-95a9-c22b-47fceda30db0"), 45, "Diesel", "Honda", "CX-9", null, new DateTime(1990, 7, 27, 10, 31, 46, 628, DateTimeKind.Unspecified).AddTicks(854), 240, "Convertible" },
                    { new Guid("c618fc38-34f3-faf5-3dc6-1e360d3d8f69"), 137, "Hybrid", "Ferrari", "Taurus", null, new DateTime(2010, 9, 29, 13, 47, 50, 292, DateTimeKind.Unspecified).AddTicks(1860), 260, "Extended Cab Pickup" },
                    { new Guid("c93eb3fa-c775-64a7-809f-23a7d7c6757a"), 79, "Diesel", "Ferrari", "XC90", null, new DateTime(1994, 12, 22, 17, 42, 1, 582, DateTimeKind.Unspecified).AddTicks(609), 220, "Crew Cab Pickup" },
                    { new Guid("cf2dd82b-4aef-501c-3fbe-1dbc37dc2c83"), 166, "Electric", "Volvo", "ATS", null, new DateTime(2008, 12, 23, 14, 12, 3, 887, DateTimeKind.Unspecified).AddTicks(8026), 130, "Sedan" },
                    { new Guid("d017495d-1de8-4709-ee84-9b1ab31b3986"), 129, "Diesel", "Land Rover", "XTS", null, new DateTime(1997, 10, 9, 2, 14, 42, 549, DateTimeKind.Unspecified).AddTicks(423), 200, "Sedan" },
                    { new Guid("d0b61a99-8bab-8ba8-f5fe-50f86e73e136"), 60, "Hybrid", "Polestar", "Beetle", null, new DateTime(2020, 12, 11, 23, 8, 49, 571, DateTimeKind.Unspecified).AddTicks(5512), 280, "Passenger Van" },
                    { new Guid("d1931064-5d44-e6a2-6491-4aa3ce637548"), 105, "Electric", "Nissan", "1", null, new DateTime(2020, 1, 5, 1, 29, 7, 32, DateTimeKind.Unspecified).AddTicks(9592), 220, "Sedan" },
                    { new Guid("d281f688-4534-f073-1985-5dcfdc5239b6"), 73, "Diesel", "Nissan", "1", null, new DateTime(1995, 1, 17, 6, 26, 41, 776, DateTimeKind.Unspecified).AddTicks(1547), 130, "Hatchback" },
                    { new Guid("d30ba08d-bd81-642e-fda7-19a2773a5671"), 44, "Gasoline", "Kia", "Fortwo", null, new DateTime(2009, 10, 20, 23, 54, 44, 776, DateTimeKind.Unspecified).AddTicks(5), 140, "SUV" },
                    { new Guid("d356df07-56e4-6ad4-eb1c-297df43ba576"), 147, "Gasoline", "Toyota", "Countach", null, new DateTime(2016, 1, 19, 12, 18, 45, 203, DateTimeKind.Unspecified).AddTicks(7344), 300, "Coupe" },
                    { new Guid("d4481753-a5a5-37aa-5587-0c9f3688cb39"), 164, "Hybrid", "Fiat", "Mustang", null, new DateTime(2008, 3, 18, 15, 8, 56, 309, DateTimeKind.Unspecified).AddTicks(7698), 230, "Convertible" },
                    { new Guid("d528f786-e8a1-6f70-0fba-c013640f9118"), 139, "Electric", "Mercedes Benz", "Civic", null, new DateTime(1990, 12, 27, 18, 44, 33, 5, DateTimeKind.Unspecified).AddTicks(2070), 290, "Wagon" },
                    { new Guid("db37afd2-43a6-09cb-7790-efe5c49df914"), 138, "Hybrid", "Lamborghini", "F-150", null, new DateTime(2009, 4, 23, 8, 28, 13, 407, DateTimeKind.Unspecified).AddTicks(2577), 180, "Convertible" },
                    { new Guid("dd16a7cd-242e-dc92-d3d8-5598e4dadffa"), 161, "Diesel", "Volkswagen", "Fortwo", null, new DateTime(2017, 11, 9, 5, 17, 15, 910, DateTimeKind.Unspecified).AddTicks(3560), 150, "Passenger Van" },
                    { new Guid("dd33745a-5de8-0b29-d622-fe9ff58d7c2d"), 72, "Gasoline", "Bentley", "F-150", null, new DateTime(2020, 1, 29, 12, 16, 47, 908, DateTimeKind.Unspecified).AddTicks(116), 260, "Passenger Van" },
                    { new Guid("dff1c635-d6c9-254f-11b6-b48be8d86ad4"), 89, "Gasoline", "Dodge", "Malibu", null, new DateTime(2002, 5, 5, 22, 41, 4, 337, DateTimeKind.Unspecified).AddTicks(7342), 160, "Crew Cab Pickup" },
                    { new Guid("e14702f2-80d4-7209-4696-2b17ffd4ebb2"), 127, "Hybrid", "Fiat", "Grand Cherokee", null, new DateTime(2015, 1, 11, 17, 33, 23, 139, DateTimeKind.Unspecified).AddTicks(469), 250, "SUV" },
                    { new Guid("e1da0fe2-e120-bd38-0ccc-5b889be0bcef"), 33, "Electric", "Ford", "Camaro", null, new DateTime(1991, 6, 18, 10, 31, 50, 263, DateTimeKind.Unspecified).AddTicks(4711), 290, "Passenger Van" },
                    { new Guid("e3388c23-12ba-78cf-d63e-93bd03ba1d95"), 30, "Diesel", "Volkswagen", "Jetta", null, new DateTime(2017, 2, 5, 7, 32, 24, 588, DateTimeKind.Unspecified).AddTicks(9286), 280, "Wagon" },
                    { new Guid("eca79984-d82c-ac58-df38-d4b04395c41b"), 48, "Electric", "Polestar", "Challenger", null, new DateTime(1993, 8, 19, 18, 41, 29, 75, DateTimeKind.Unspecified).AddTicks(9692), 170, "Passenger Van" },
                    { new Guid("ed3fa262-1c00-c39d-255d-568f68de614a"), 113, "Gasoline", "Maserati", "CTS", null, new DateTime(2021, 9, 14, 9, 8, 25, 907, DateTimeKind.Unspecified).AddTicks(278), 170, "Passenger Van" },
                    { new Guid("ed71c8a2-0224-1e5f-70c7-432bfe4941e2"), 36, "Diesel", "Mini", "Taurus", null, new DateTime(1993, 9, 24, 9, 59, 14, 299, DateTimeKind.Unspecified).AddTicks(8690), 190, "Convertible" },
                    { new Guid("ed9206ad-94fc-6870-dad2-459531438d08"), 62, "Hybrid", "Chrysler", "Land Cruiser", null, new DateTime(1993, 2, 3, 23, 17, 4, 785, DateTimeKind.Unspecified).AddTicks(8840), 220, "Hatchback" },
                    { new Guid("ee7da52a-28c2-1bfc-2082-58844afdcd31"), 118, "Hybrid", "Nissan", "Ranchero", null, new DateTime(2005, 2, 15, 23, 28, 55, 656, DateTimeKind.Unspecified).AddTicks(2591), 150, "SUV" },
                    { new Guid("f2ec4aa8-84c2-b5b5-e9f0-90771aa58917"), 162, "Gasoline", "Chevrolet", "El Camino", null, new DateTime(2020, 9, 13, 3, 14, 10, 137, DateTimeKind.Unspecified).AddTicks(9410), 250, "Minivan" },
                    { new Guid("f5ba9244-a3d2-14c1-b668-2a206e2ff8e6"), 114, "Diesel", "Lamborghini", "XC90", null, new DateTime(2016, 2, 23, 7, 24, 46, 336, DateTimeKind.Unspecified).AddTicks(2541), 210, "Minivan" },
                    { new Guid("f5e0e49f-710e-2d05-7eef-e9b3e53e429b"), 127, "Hybrid", "Chevrolet", "Camry", null, new DateTime(2012, 11, 17, 7, 53, 54, 639, DateTimeKind.Unspecified).AddTicks(1035), 260, "Hatchback" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_OrderId",
                table: "Vehicles",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
