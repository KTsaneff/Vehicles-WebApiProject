using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApiDemo.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehicleType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Engine = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductionDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "Brand", "Engine", "Model", "ProductionDate", "VehicleType" },
                values: new object[,]
                {
                    { 1, "Toyota", "Petrol", "Sequoia", new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SUV" },
                    { 2, "Ford", "Diesel", "Explorer", new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SUV" },
                    { 3, "Honda", "Petrol", "Civic", new DateTime(2023, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Car" },
                    { 4, "Tesla", "Electric", "Model 3", new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Car" },
                    { 5, "Chevrolet", "Hybrid", "Impala", new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Car" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vehicles");
        }
    }
}
