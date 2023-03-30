using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackV2.Migrations
{
    /// <inheritdoc />
    public partial class CheckProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddCheckConstraint(
                name: "SizeBound",
                table: "Race",
                sql: "Race.SizeId > 0 and Race.SizeId < 4");

            migrationBuilder.AddForeignKey(
                name: "FK_Race_Size_SizeId",
                table: "Race",
                column: "SizeId",
                principalTable: "Size",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Race_Size_SizeId",
                table: "Race");

            migrationBuilder.DropIndex(
                name: "IX_Race_SizeId",
                table: "Race");

            migrationBuilder.DropCheckConstraint(
                name: "SizeBound",
                table: "Race");

            migrationBuilder.DropColumn(
                name: "SizeId",
                table: "Race");
        }
    }
}
