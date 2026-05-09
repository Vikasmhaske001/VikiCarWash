using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VikiCarWash.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddBookingStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCompleted",
                table: "CarWashBookings");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "CarWashBookings",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "CarWashBookings");

            migrationBuilder.AddColumn<bool>(
                name: "IsCompleted",
                table: "CarWashBookings",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
