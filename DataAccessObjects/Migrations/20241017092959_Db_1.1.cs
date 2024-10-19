using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Db_11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingDetail_BookingReservation_BookingReservationID",
                table: "BookingDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_BookingDetail_Rooms_RoomID",
                table: "BookingDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_BookingReservation_Customers_CustomerID",
                table: "BookingReservation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookingReservation",
                table: "BookingReservation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookingDetail",
                table: "BookingDetail");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "BookingReservation");

            migrationBuilder.RenameTable(
                name: "BookingReservation",
                newName: "BookingReservations");

            migrationBuilder.RenameTable(
                name: "BookingDetail",
                newName: "BookingDetails");

            migrationBuilder.RenameIndex(
                name: "IX_BookingReservation_CustomerID",
                table: "BookingReservations",
                newName: "IX_BookingReservations_CustomerID");

            migrationBuilder.RenameIndex(
                name: "IX_BookingDetail_RoomID",
                table: "BookingDetails",
                newName: "IX_BookingDetails_RoomID");

            migrationBuilder.AddColumn<int>(
                name: "BookingStatu",
                table: "BookingReservations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookingReservations",
                table: "BookingReservations",
                column: "BookingReservationID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookingDetails",
                table: "BookingDetails",
                columns: new[] { "BookingReservationID", "RoomID" });

            migrationBuilder.AddForeignKey(
                name: "FK_BookingDetails_BookingReservations_BookingReservationID",
                table: "BookingDetails",
                column: "BookingReservationID",
                principalTable: "BookingReservations",
                principalColumn: "BookingReservationID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookingDetails_Rooms_RoomID",
                table: "BookingDetails",
                column: "RoomID",
                principalTable: "Rooms",
                principalColumn: "RoomID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookingReservations_Customers_CustomerID",
                table: "BookingReservations",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingDetails_BookingReservations_BookingReservationID",
                table: "BookingDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_BookingDetails_Rooms_RoomID",
                table: "BookingDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_BookingReservations_Customers_CustomerID",
                table: "BookingReservations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookingReservations",
                table: "BookingReservations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookingDetails",
                table: "BookingDetails");

            migrationBuilder.DropColumn(
                name: "BookingStatu",
                table: "BookingReservations");

            migrationBuilder.RenameTable(
                name: "BookingReservations",
                newName: "BookingReservation");

            migrationBuilder.RenameTable(
                name: "BookingDetails",
                newName: "BookingDetail");

            migrationBuilder.RenameIndex(
                name: "IX_BookingReservations_CustomerID",
                table: "BookingReservation",
                newName: "IX_BookingReservation_CustomerID");

            migrationBuilder.RenameIndex(
                name: "IX_BookingDetails_RoomID",
                table: "BookingDetail",
                newName: "IX_BookingDetail_RoomID");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "BookingReservation",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookingReservation",
                table: "BookingReservation",
                column: "BookingReservationID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookingDetail",
                table: "BookingDetail",
                columns: new[] { "BookingReservationID", "RoomID" });

            migrationBuilder.AddForeignKey(
                name: "FK_BookingDetail_BookingReservation_BookingReservationID",
                table: "BookingDetail",
                column: "BookingReservationID",
                principalTable: "BookingReservation",
                principalColumn: "BookingReservationID",
                onDelete: ReferentialAction.Cascade);

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
        }
    }
}
