using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace frano_ferreteria.Migrations
{
    /// <inheritdoc />
    public partial class AddBillCustomersRelations__12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bills_Items_ItemId",
                table: "Bills");

            migrationBuilder.DropIndex(
                name: "IX_Bills_ItemId",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "Bills");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "Bills",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bills_ItemId",
                table: "Bills",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_Items_ItemId",
                table: "Bills",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id");
        }
    }
}
