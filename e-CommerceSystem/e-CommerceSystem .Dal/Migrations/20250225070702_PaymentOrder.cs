using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace e_CommerceSystem_.Dal.Migrations
{
    /// <inheritdoc />
    public partial class PaymentOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaymentId",
                table: "Order");

            migrationBuilder.AddColumn<int>(
                name: "OrderStatus",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderStatus",
                table: "Order");

            migrationBuilder.AddColumn<long>(
                name: "PaymentId",
                table: "Order",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
