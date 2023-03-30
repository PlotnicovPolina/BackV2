using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackV2.Migrations
{
    /// <inheritdoc />
    public partial class AddRaceSize : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "lifespan",
                table: "Race",
                newName: "Lifespan");

            migrationBuilder.AddColumn<int>(
                name: "Size",
                table: "Race",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Size",
                table: "Race");

            migrationBuilder.RenameColumn(
                name: "Lifespan",
                table: "Race",
                newName: "lifespan");
        }
    }
}
