using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VikiCarWash.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCarWashCenter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "CarWashCenters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "CarWashCenters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "CarWashCenters",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "CarWashCenters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Rating",
                table: "CarWashCenters",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "CarWashCenters");

            migrationBuilder.DropColumn(
                name: "City",
                table: "CarWashCenters");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "CarWashCenters");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "CarWashCenters");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "CarWashCenters");
        }
    }
}
