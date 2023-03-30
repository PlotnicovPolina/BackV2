using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackV2.Migrations
{
    /// <inheritdoc />
    public partial class SizeTest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Race_Size_SizeId",
                table: "Race");

            migrationBuilder.DropIndex(
                name: "IX_Race_SizeId",
                table: "Race");

            migrationBuilder.DropColumn(
                name: "SizeEnum",
                table: "Race");

            migrationBuilder.DropColumn(
                name: "SizeId",
                table: "Race");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SizeEnum",
                table: "Race",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SizeId",
                table: "Race",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Race_SizeId",
                table: "Race",
                column: "SizeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Race_Size_SizeId",
                table: "Race",
                column: "SizeId",
                principalTable: "Size",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
