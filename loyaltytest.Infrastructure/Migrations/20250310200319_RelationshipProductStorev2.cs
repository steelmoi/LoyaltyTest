using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace loyaltytest.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RelationshipProductStorev2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "ProductStore",
                columns: table => new
                {
                    ProductsProductId = table.Column<long>(type: "bigint", nullable: false),
                    StoresStoreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductStore", x => new { x.ProductsProductId, x.StoresStoreId });
                    table.ForeignKey(
                        name: "FK_ProductStore_Product_ProductsProductId",
                        column: x => x.ProductsProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductStore_Store_StoresStoreId",
                        column: x => x.StoresStoreId,
                        principalTable: "Store",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductStore_StoresStoreId",
                table: "ProductStore",
                column: "StoresStoreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductStore");

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
    }
}
