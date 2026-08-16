using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Mvc7_Routing.Migrations
{
    /// <inheritdoc />
    public partial class InitialDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "汽車廠牌製造商"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "汽車名稱"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "汽車售價"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "汽車分類"),
                    Year = table.Column<int>(type: "int", nullable: false, comment: "汽車年份"),
                    SoldNumber = table.Column<int>(type: "int", nullable: false, comment: "汽車年度銷售數字")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Brand", "Category", "ImageUrl", "Name", "Price", "SoldNumber", "Year" },
                values: new object[,]
                {
                    { 1001, "Mercedes", "轎車", "Mercedes_AMG_S63.jpg", "AMG S63", 145695m, 120, 2023 },
                    { 1002, "Audi", "轎車", "Audi_S8.jpg", "S8", 116875m, 200, 2021 },
                    { 1003, "BMW", "轎車", "BMW_M3.jpg", "M3", 66495m, 85, 2021 },
                    { 1004, "AlfaRomeo", "轎車", "AlfaRomeo_GiuliaQuadrifoglio.jpg", "Giulia Quadrifoglio", 73595m, 62, 2022 },
                    { 1005, "Mercedes", "SUV", "MercedesBenz_GLS.jpg", "GLS Class", 68045m, 250, 2019 },
                    { 1006, "Porsche", "SUV", "Porsche_Cayenne.jpg", "Cayenne", 60650m, 160, 2023 },
                    { 1007, "Honda", "SUV", "Honda_CRV.jpg", "CR-V", 24985m, 1200, 2023 },
                    { 1008, "Bugatti", "跑車", "Bugatti_Chiron.jpg", "Chiron", 2998000m, 10, 2023 },
                    { 1009, "Lamborghini", "跑車", "Lamborghini_Huracan.jpg", "Huracan", 203295m, 30, 2022 },
                    { 1010, "Porsche", "跑車", "Porsche_718Boxster.jpg", "718 Boxster", 57050m, 49, 2019 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");
        }
    }
}
