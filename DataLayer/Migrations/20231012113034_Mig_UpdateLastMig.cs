using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class Mig_UpdateLastMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SelectedGroups_ProductGroups_ProductGroupGroupId",
                table: "SelectedGroups");

            migrationBuilder.DropIndex(
                name: "IX_SelectedGroups_ProductGroupGroupId",
                table: "SelectedGroups");

            migrationBuilder.DropColumn(
                name: "ProductGroupGroupId",
                table: "SelectedGroups");

            migrationBuilder.CreateIndex(
                name: "IX_SelectedGroups_GroupId",
                table: "SelectedGroups",
                column: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_SelectedGroups_ProductGroups_GroupId",
                table: "SelectedGroups",
                column: "GroupId",
                principalTable: "ProductGroups",
                principalColumn: "GroupId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SelectedGroups_ProductGroups_GroupId",
                table: "SelectedGroups");

            migrationBuilder.DropIndex(
                name: "IX_SelectedGroups_GroupId",
                table: "SelectedGroups");

            migrationBuilder.AddColumn<int>(
                name: "ProductGroupGroupId",
                table: "SelectedGroups",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SelectedGroups_ProductGroupGroupId",
                table: "SelectedGroups",
                column: "ProductGroupGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_SelectedGroups_ProductGroups_ProductGroupGroupId",
                table: "SelectedGroups",
                column: "ProductGroupGroupId",
                principalTable: "ProductGroups",
                principalColumn: "GroupId");
        }
    }
}
