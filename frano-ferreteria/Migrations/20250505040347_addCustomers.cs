using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace frano_ferreteria.Migrations
{
    /// <inheritdoc />
    public partial class addCustomers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Items",
                newName: "UnitPrice");

            migrationBuilder.RenameColumn(
                name: "Total",
                table: "Bills",
                newName: "UnitPrice");

            migrationBuilder.RenameColumn(
                name: "NombreCliente",
                table: "Bills",
                newName: "PaymentMethod");

            migrationBuilder.AddColumn<int>(
                name: "BillId",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Bills",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Bills",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_BillId",
                table: "Items",
                column: "BillId");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_CustomerId",
                table: "Bills",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_Customers_CustomerId",
                table: "Bills",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Bills_BillId",
                table: "Items",
                column: "BillId",
                principalTable: "Bills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bills_Customers_CustomerId",
                table: "Bills");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_Bills_BillId",
                table: "Items");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Items_BillId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Bills_CustomerId",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "BillId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Bills");

            migrationBuilder.RenameColumn(
                name: "UnitPrice",
                table: "Items",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "UnitPrice",
                table: "Bills",
                newName: "Total");

            migrationBuilder.RenameColumn(
                name: "PaymentMethod",
                table: "Bills",
                newName: "NombreCliente");
        }
    }
}
