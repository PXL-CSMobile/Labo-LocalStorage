using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PieShop.API.Migrations
{
    /// <inheritdoc />
    public partial class InitDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    PurchasePrice = table.Column<double>(type: "float", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InStock = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pies", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Pies",
                columns: new[] { "Id", "Description", "ImageUrl", "InStock", "Name", "Price", "PurchasePrice" },
                values: new object[,]
                {
                    { new Guid("0ac44f1c-84fb-4bcc-8e1f-49fcc8f2a17c"), "Plain cheese cake. Plain pleasure.", "https://gillcleerenpluralsight.blob.core.windows.net/files/cheesecakesmall.jpg", true, "Cheese cake", 12.949999999999999, 7.5 },
                    { new Guid("11db10f5-c461-490f-a7a3-5ba5af3a58af"), "You'll love it!", "https://gillcleerenpluralsight.blob.core.windows.net/files/blueberrycheesecakesmall.jpg", true, "Blueberry cheese cake", 18.949999999999999, 11.949999999999999 },
                    { new Guid("27529374-72aa-40cc-9819-993440356582"), "My God, so sweet!", "https://gillcleerenpluralsight.blob.core.windows.net/files/rhubarbpiesmall.jpg", true, "Rhubarb pie", 12.949999999999999, 6.5 },
                    { new Guid("27629373-72aa-40cc-9819-993440356585"), "Happy holidays with this pie!", "https://gillcleerenpluralsight.blob.core.windows.net/files/christmasapplepiesmall.jpg", true, "Christmas apple pie", 12.949999999999999, 6.5 },
                    { new Guid("27629374-72aa-40cc-9819-993440356585"), "Sweet as peach!", "https://gillcleerenpluralsight.blob.core.windows.net/files/peachpiesmall.jpg", true, "Peach pie", 12.949999999999999, 6.5 },
                    { new Guid("70822596-265d-49e3-8ccc-cd996093e601"), "Our famous apple pies!", "https://gillcleerenpluralsight.blob.core.windows.net/files/applepiesmall.jpg", true, "Apple Pie", 15.949999999999999, 9.5 },
                    { new Guid("71a9453f-7a6b-40ac-9d66-e659296ef128"), "A summer classic!", "https://gillcleerenpluralsight.blob.core.windows.net/files/cherrypiesmall.jpg", true, "Cherry pie", 15.949999999999999, 9.5 },
                    { new Guid("8c9ac766-bc2f-40f0-acb1-b0ad6157c07b"), "Our delicious strawberry pie!", "https://gillcleerenpluralsight.blob.core.windows.net/files/strawberrypiesmall.jpg", true, "Strawberry pie", 12.949999999999999, 7.5 },
                    { new Guid("c956b141-3fc7-4176-9fed-a726a9eb47fa"), "You'll love it!", "https://gillcleerenpluralsight.blob.core.windows.net/files/strawberrycheesecakesmall.jpg", true, "Strawberry cheese cake", 12.949999999999999, 6.5 },
                    { new Guid("caa2a5d5-99d4-423c-b1f3-1b0e48c483c3"), "A Christmas favorite", "https://gillcleerenpluralsight.blob.core.windows.net/files/cranberrypiesmall.jpg", true, "Cranberry pie", 12.949999999999999, 6.5 },
                    { new Guid("faa549e9-f940-4a2d-b5fe-93d3a9edbce7"), "Our Halloween favorite", "https://gillcleerenpluralsight.blob.core.windows.net/files/pumpkinpiesmall.jpg", true, "Pumpkin Pie", 12.949999999999999, 6.5 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pies");
        }
    }
}
