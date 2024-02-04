using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class Up_OrderAgainNow : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSend",
                table: "OrderDetail");

            migrationBuilder.AddColumn<bool>(
                name: "IsSend",
                table: "Order",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSend",
                table: "Order");

            migrationBuilder.AddColumn<bool>(
                name: "IsSend",
                table: "OrderDetail",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
