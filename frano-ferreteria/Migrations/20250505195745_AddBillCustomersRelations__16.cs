using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace frano_ferreteria.Migrations
{
    /// <inheritdoc />
    public partial class AddBillCustomersRelations__16 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BillId",
                table: "Items");

            migrationBuilder.AddColumn<decimal>(
                name: "Total",
                table: "Items",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Total",
                table: "Items");

            migrationBuilder.AddColumn<int>(
                name: "BillId",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
