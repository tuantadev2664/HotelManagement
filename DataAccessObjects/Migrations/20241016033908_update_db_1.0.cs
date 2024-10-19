using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class update_db_10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingDetail_RoomInformation_RoomID",
                table: "BookingDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_BookingReservation_Customer_CustomerID",
                table: "BookingReservation");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomInformation_RoomType_RoomTypeID",
                table: "RoomInformation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomType",
                table: "RoomType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomInformation",
                table: "RoomInformation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customer",
                table: "Customer");

            migrationBuilder.RenameTable(
                name: "RoomType",
                newName: "RoomTypes");

            migrationBuilder.RenameTable(
                name: "RoomInformation",
                newName: "Rooms");

            migrationBuilder.RenameTable(
                name: "Customer",
                newName: "Customers");

            migrationBuilder.RenameIndex(
                name: "IX_RoomInformation_RoomTypeID",
                table: "Rooms",
                newName: "IX_Rooms_RoomTypeID");

            migrationBuilder.RenameIndex(
                name: "IX_Customer_EmailAddress",
                table: "Customers",
                newName: "IX_Customers_EmailAddress");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomTypes",
                table: "RoomTypes",
                column: "RoomTypeID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rooms",
                table: "Rooms",
                column: "RoomID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "CustomerID");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingDetail_Rooms_RoomID",
                table: "BookingDetail",
                column: "RoomID",
                principalTable: "Rooms",
                principalColumn: "RoomID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookingReservation_Customers_CustomerID",
                table: "BookingReservation",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_RoomTypes_RoomTypeID",
                table: "Rooms",
                column: "RoomTypeID",
                principalTable: "RoomTypes",
                principalColumn: "RoomTypeID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingDetail_Rooms_RoomID",
                table: "BookingDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_BookingReservation_Customers_CustomerID",
                table: "BookingReservation");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_RoomTypes_RoomTypeID",
                table: "Rooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomTypes",
                table: "RoomTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rooms",
                table: "Rooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            migrationBuilder.RenameTable(
                name: "RoomTypes",
                newName: "RoomType");

            migrationBuilder.RenameTable(
                name: "Rooms",
                newName: "RoomInformation");

            migrationBuilder.RenameTable(
                name: "Customers",
                newName: "Customer");

            migrationBuilder.RenameIndex(
                name: "IX_Rooms_RoomTypeID",
                table: "RoomInformation",
                newName: "IX_RoomInformation_RoomTypeID");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_EmailAddress",
                table: "Customer",
                newName: "IX_Customer_EmailAddress");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomType",
                table: "RoomType",
                column: "RoomTypeID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomInformation",
                table: "RoomInformation",
                column: "RoomID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customer",
                table: "Customer",
                column: "CustomerID");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingDetail_RoomInformation_RoomID",
                table: "BookingDetail",
                column: "RoomID",
                principalTable: "RoomInformation",
                principalColumn: "RoomID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookingReservation_Customer_CustomerID",
                table: "BookingReservation",
                column: "CustomerID",
                principalTable: "Customer",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomInformation_RoomType_RoomTypeID",
                table: "RoomInformation",
                column: "RoomTypeID",
                principalTable: "RoomType",
                principalColumn: "RoomTypeID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
