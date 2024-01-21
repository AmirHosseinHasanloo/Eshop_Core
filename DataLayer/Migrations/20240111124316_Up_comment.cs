using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class Up_comment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "ProductComments");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "ProductComments");

            migrationBuilder.DropColumn(
                name: "WebSite",
                table: "ProductComments");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "ProductComments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProductComments_UserId",
                table: "ProductComments",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductComments_Users_UserId",
                table: "ProductComments",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductComments_Users_UserId",
                table: "ProductComments");

            migrationBuilder.DropIndex(
                name: "IX_ProductComments_UserId",
                table: "ProductComments");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ProductComments");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "ProductComments",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "ProductComments",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "WebSite",
                table: "ProductComments",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);
        }
    }
}
