using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VikiCarWash.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RenameCarType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Cartype",
                table: "CarWashBookings",
                newName: "CarType");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CarType",
                table: "CarWashBookings",
                newName: "Cartype");
        }
    }
}
