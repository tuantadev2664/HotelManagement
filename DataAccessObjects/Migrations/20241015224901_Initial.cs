using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerFullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Telephone = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CustomerBirthday = table.Column<DateOnly>(type: "date", nullable: false),
                    CustomerStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerID);
                });

            migrationBuilder.CreateTable(
                name: "RoomType",
                columns: table => new
                {
                    RoomTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomTypeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TypeDescription = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    TypeNote = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomType", x => x.RoomTypeID);
                });

            migrationBuilder.CreateTable(
                name: "BookingReservation",
                columns: table => new
                {
                    BookingReservationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingDate = table.Column<DateOnly>(type: "date", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingReservation", x => x.BookingReservationID);
                    table.ForeignKey(
                        name: "FK_BookingReservation_Customer_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customer",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoomInformation",
                columns: table => new
                {
                    RoomID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RoomDescription = table.Column<string>(type: "nvarchar(220)", maxLength: 220, nullable: true),
                    RoomMaxCapacity = table.Column<int>(type: "int", nullable: true),
                    RoomStatus = table.Column<int>(type: "int", nullable: false),
                    RoomPricePerDate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RoomTypeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomInformation", x => x.RoomID);
                    table.ForeignKey(
                        name: "FK_RoomInformation_RoomType_RoomTypeID",
                        column: x => x.RoomTypeID,
                        principalTable: "RoomType",
                        principalColumn: "RoomTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookingDetail",
                columns: table => new
                {
                    BookingReservationID = table.Column<int>(type: "int", nullable: false),
                    RoomID = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: false),
                    ActualPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingDetail", x => new { x.BookingReservationID, x.RoomID });
                    table.ForeignKey(
                        name: "FK_BookingDetail_BookingReservation_BookingReservationID",
                        column: x => x.BookingReservationID,
                        principalTable: "BookingReservation",
                        principalColumn: "BookingReservationID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookingDetail_RoomInformation_RoomID",
                        column: x => x.RoomID,
                        principalTable: "RoomInformation",
                        principalColumn: "RoomID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "CustomerID", "CustomerBirthday", "CustomerFullName", "CustomerStatus", "EmailAddress", "Password", "Telephone" },
                values: new object[,]
                {
                    { 1, new DateOnly(1990, 1, 1), "Nguyen Van A", 0, "nguyenvana@example.com", "password123", "0123456789" },
                    { 2, new DateOnly(1985, 5, 15), "Tran Thi B", 0, "tranthib@example.com", "password456", "0987654321" },
                    { 3, new DateOnly(1985, 5, 15), "Tran Thi C", 0, "test@example.com", "123", "0987654321" }
                });

            migrationBuilder.InsertData(
                table: "RoomType",
                columns: new[] { "RoomTypeID", "RoomTypeName", "TypeDescription", "TypeNote" },
                values: new object[,]
                {
                    { 1, "Standard", "Basic room with essential amenities", "Includes free breakfast" },
                    { 2, "Deluxe", "Spacious room with additional features", "Sea view, includes free breakfast and gym access" }
                });

            migrationBuilder.InsertData(
                table: "RoomInformation",
                columns: new[] { "RoomID", "RoomDescription", "RoomMaxCapacity", "RoomNumber", "RoomPricePerDate", "RoomStatus", "RoomTypeID" },
                values: new object[,]
                {
                    { 1, "Standard room with queen bed", 2, "101", 100m, 0, 1 },
                    { 2, "Deluxe room with king bed and balcony", 3, "202", 200m, 0, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookingDetail_RoomID",
                table: "BookingDetail",
                column: "RoomID");

            migrationBuilder.CreateIndex(
                name: "IX_BookingReservation_CustomerID",
                table: "BookingReservation",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_EmailAddress",
                table: "Customer",
                column: "EmailAddress",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RoomInformation_RoomTypeID",
                table: "RoomInformation",
                column: "RoomTypeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingDetail");

            migrationBuilder.DropTable(
                name: "BookingReservation");

            migrationBuilder.DropTable(
                name: "RoomInformation");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "RoomType");
        }
    }
}
