using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackV2.Migrations
{
    /// <inheritdoc />
    public partial class ResolveConflict : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "Parameters",
                table: "Race");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "Race");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Race",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Race",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(60)",
                oldMaxLength: 60);

            migrationBuilder.AddColumn<int>(
                name: "Size",
                table: "Race",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "Parameters",
                table: "Race",
                columns: new[] { "Size", "Coat" });
        }
    }
}
