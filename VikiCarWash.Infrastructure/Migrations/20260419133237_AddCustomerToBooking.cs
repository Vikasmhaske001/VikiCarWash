using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VikiCarWash.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddCustomerToBooking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarWashBookings_Customers_CustomerId",
                table: "CarWashBookings");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "CarWashBookings");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "CarWashBookings",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CarWashBookings_Customers_CustomerId",
                table: "CarWashBookings",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarWashBookings_Customers_CustomerId",
                table: "CarWashBookings");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "CarWashBookings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "CarWashBookings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_CarWashBookings_Customers_CustomerId",
                table: "CarWashBookings",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id");
        }
    }
}
