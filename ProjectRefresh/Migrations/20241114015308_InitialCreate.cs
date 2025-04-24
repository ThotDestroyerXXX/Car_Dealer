using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectRefresh.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MsCar",
                columns: table => new
                {
                    Car_id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    model = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    year = table.Column<int>(type: "int", nullable: true),
                    license_plate = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    number_of_car_seats = table.Column<int>(type: "int", nullable: true),
                    transmission = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    price_per_day = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MsCar", x => x.Car_id);
                });

            migrationBuilder.CreateTable(
                name: "MsCustomer",
                columns: table => new
                {
                    Customer_id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    phone_number = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    driver_license_number = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MsCustomer", x => x.Customer_id);
                });

            migrationBuilder.CreateTable(
                name: "MsEmployees",
                columns: table => new
                {
                    Employee_id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    position = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    phone_number = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MsEmployees", x => x.Employee_id);
                });

            migrationBuilder.CreateTable(
                name: "MsCarImages",
                columns: table => new
                {
                    Image_car_id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    Car_id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    image_link = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MsCarImages", x => x.Image_car_id);
                    table.ForeignKey(
                        name: "FK_MsCarImages_MsCar_Car_id",
                        column: x => x.Car_id,
                        principalTable: "MsCar",
                        principalColumn: "Car_id");
                });

            migrationBuilder.CreateTable(
                name: "TrRental",
                columns: table => new
                {
                    Rental_id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    rental_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    return_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    total_price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    payment_status = table.Column<bool>(type: "bit", nullable: true),
                    Customer_id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    Car_id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrRental", x => x.Rental_id);
                    table.ForeignKey(
                        name: "FK_TrRental_MsCar_Car_id",
                        column: x => x.Car_id,
                        principalTable: "MsCar",
                        principalColumn: "Car_id");
                    table.ForeignKey(
                        name: "FK_TrRental_MsCustomer_Customer_id",
                        column: x => x.Customer_id,
                        principalTable: "MsCustomer",
                        principalColumn: "Customer_id");
                });

            migrationBuilder.CreateTable(
                name: "TrMaintenances",
                columns: table => new
                {
                    Maintenance_id = table.Column<int>(type: "int", maxLength: 36, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    maintenance_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    description = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    cost = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Car_id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    Employee_id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrMaintenances", x => x.Maintenance_id);
                    table.ForeignKey(
                        name: "FK_TrMaintenances_MsCar_Car_id",
                        column: x => x.Car_id,
                        principalTable: "MsCar",
                        principalColumn: "Car_id");
                    table.ForeignKey(
                        name: "FK_TrMaintenances_MsEmployees_Employee_id",
                        column: x => x.Employee_id,
                        principalTable: "MsEmployees",
                        principalColumn: "Employee_id");
                });

            migrationBuilder.CreateTable(
                name: "TrPayments",
                columns: table => new
                {
                    Payment_id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    payment_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    amount = table.Column<double>(type: "float", nullable: true),
                    payment_method = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Rental_id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrPayments", x => x.Payment_id);
                    table.ForeignKey(
                        name: "FK_TrPayments_TrRental_Rental_id",
                        column: x => x.Rental_id,
                        principalTable: "TrRental",
                        principalColumn: "Rental_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MsCarImages_Car_id",
                table: "MsCarImages",
                column: "Car_id");

            migrationBuilder.CreateIndex(
                name: "IX_TrMaintenances_Car_id",
                table: "TrMaintenances",
                column: "Car_id");

            migrationBuilder.CreateIndex(
                name: "IX_TrMaintenances_Employee_id",
                table: "TrMaintenances",
                column: "Employee_id");

            migrationBuilder.CreateIndex(
                name: "IX_TrPayments_Rental_id",
                table: "TrPayments",
                column: "Rental_id");

            migrationBuilder.CreateIndex(
                name: "IX_TrRental_Car_id",
                table: "TrRental",
                column: "Car_id");

            migrationBuilder.CreateIndex(
                name: "IX_TrRental_Customer_id",
                table: "TrRental",
                column: "Customer_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MsCarImages");

            migrationBuilder.DropTable(
                name: "TrMaintenances");

            migrationBuilder.DropTable(
                name: "TrPayments");

            migrationBuilder.DropTable(
                name: "MsEmployees");

            migrationBuilder.DropTable(
                name: "TrRental");

            migrationBuilder.DropTable(
                name: "MsCar");

            migrationBuilder.DropTable(
                name: "MsCustomer");
        }
    }
}
