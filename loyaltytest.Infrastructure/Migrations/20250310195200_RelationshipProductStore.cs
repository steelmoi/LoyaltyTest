using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace loyaltytest.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RelationshipProductStore : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "StoreId",
                table: "Product",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "StoreId1",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Product_StoreId1",
                table: "Product",
                column: "StoreId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Store_StoreId1",
                table: "Product",
                column: "StoreId1",
                principalTable: "Store",
                principalColumn: "StoreId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Store_StoreId1",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_StoreId1",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "StoreId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "StoreId1",
                table: "Product");
        }
    }
}
