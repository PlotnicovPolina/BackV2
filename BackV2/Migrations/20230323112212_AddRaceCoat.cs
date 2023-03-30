using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackV2.Migrations
{
    /// <inheritdoc />
    public partial class AddRaceCoat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Coat",
                table: "Race",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "Parameters",
                table: "Race",
                columns: new[] { "Size", "Coat" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "Parameters",
                table: "Race");

            migrationBuilder.DropColumn(
                name: "Coat",
                table: "Race");
        }
    }
}
