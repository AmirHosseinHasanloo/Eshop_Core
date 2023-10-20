using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class Mig_UpdateUserTB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_ProductGroups_ProductGroupGroupId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_ProductGroupGroupId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ProductGroupGroupId",
                table: "Users");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductGroupGroupId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_ProductGroupGroupId",
                table: "Users",
                column: "ProductGroupGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_ProductGroups_ProductGroupGroupId",
                table: "Users",
                column: "ProductGroupGroupId",
                principalTable: "ProductGroups",
                principalColumn: "GroupId");
        }
    }
}
