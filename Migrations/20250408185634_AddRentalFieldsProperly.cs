using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRentalApi.Migrations
{
    /// <inheritdoc />
    public partial class AddRentalFieldsProperly : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RentalPrice",
                table: "Rentals");

            migrationBuilder.RenameColumn(
                name: "RentalStartDate",
                table: "Rentals",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "RentalEndDate",
                table: "Rentals",
                newName: "EndDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "Rentals",
                newName: "RentalStartDate");

            migrationBuilder.RenameColumn(
                name: "EndDate",
                table: "Rentals",
                newName: "RentalEndDate");

            migrationBuilder.AddColumn<double>(
                name: "RentalPrice",
                table: "Rentals",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
