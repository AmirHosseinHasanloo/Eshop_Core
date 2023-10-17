using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddRel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductGroupGroupId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductGroupGroupId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_ProductGroupGroupId",
                table: "Users",
                column: "ProductGroupGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductGroupGroupId",
                table: "Products",
                column: "ProductGroupGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductGroups_ProductGroupGroupId",
                table: "Products",
                column: "ProductGroupGroupId",
                principalTable: "ProductGroups",
                principalColumn: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_ProductGroups_ProductGroupGroupId",
                table: "Users",
                column: "ProductGroupGroupId",
                principalTable: "ProductGroups",
                principalColumn: "GroupId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductGroups_ProductGroupGroupId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_ProductGroups_ProductGroupGroupId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_ProductGroupGroupId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductGroupGroupId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductGroupGroupId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ProductGroupGroupId",
                table: "Products");
        }
    }
}
