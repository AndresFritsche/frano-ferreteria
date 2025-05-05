using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace frano_ferreteria.Migrations
{
    /// <inheritdoc />
    public partial class AddBillCustomersRelations__2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bills_Items_ItemId",
                table: "Bills");

            migrationBuilder.AlterColumn<int>(
                name: "ItemId",
                table: "Bills",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_Items_ItemId",
                table: "Bills",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bills_Items_ItemId",
                table: "Bills");

            migrationBuilder.AlterColumn<int>(
                name: "ItemId",
                table: "Bills",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_Items_ItemId",
                table: "Bills",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
