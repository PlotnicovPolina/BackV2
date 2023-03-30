using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackV2.Migrations
{
    /// <inheritdoc />
    public partial class DeleteCoatProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Coat",
                table: "Race");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Coat",
                table: "Race",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
