//using System;
//using Microsoft.EntityFrameworkCore.Migrations;

//#nullable disable

//namespace DishoutOLO.Repo.Migrations
//{
//    /// <inheritdoc />
//    public partial class ini : Migration
//    {
//        /// <inheritdoc />
//        protected override void Up(MigrationBuilder migrationBuilder)
//        {
//            migrationBuilder.DropTable(
//                name: "ItemGroup");

//            migrationBuilder.CreateTable(
//                name: "ItemGroups",
//                columns: table => new
//                {
//                    Id = table.Column<int>(type: "int", nullable: false)
//                        .Annotation("SqlServer:Identity", "1, 1"),
//                    itemGroup = table.Column<string>(type: "nvarchar(max)", nullable: false),
//                    ItemId = table.Column<int>(type: "int", nullable: false),
//                    DisplayOrder = table.Column<string>(type: "nvarchar(max)", nullable: false),
//                    IsActive = table.Column<bool>(type: "bit", nullable: false),
//                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
//                    CreatedBy = table.Column<int>(type: "int", nullable: false),
//                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
//                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_ItemGroups", x => x.Id);
//                    table.ForeignKey(
//                        name: "FK_ItemGroups_ItemGroups_ItemId",
//                        column: x => x.ItemId,
//                        principalTable: "ItemGroups",
//                        principalColumn: "Id",
//                        onDelete: ReferentialAction.Cascade);
//                });

//            migrationBuilder.CreateIndex(
//                name: "IX_Items_CategoryId",
//                table: "Items",
//                column: "CategoryId");

//            migrationBuilder.CreateIndex(
//                name: "IX_ItemGroups_ItemId",
//                table: "ItemGroups",
//                column: "ItemId");

//            migrationBuilder.AddForeignKey(
//                name: "FK_Items_Categories_CategoryId",
//                table: "Items",
//                column: "CategoryId",
//                principalTable: "Categories",
//                principalColumn: "Id",
//                onDelete: ReferentialAction.Cascade);
//        }

//        /// <inheritdoc />
//        protected override void Down(MigrationBuilder migrationBuilder)
//        {
//            migrationBuilder.DropForeignKey(
//                name: "FK_Items_Categories_CategoryId",
//                table: "Items");

//            migrationBuilder.DropTable(
//                name: "ItemGroups");

//            migrationBuilder.DropIndex(
//                name: "IX_Items_CategoryId",
//                table: "Items");

//            migrationBuilder.CreateTable(
//                name: "ItemGroup",
//                columns: table => new
//                {
//                    Id = table.Column<int>(type: "int", nullable: false)
//                        .Annotation("SqlServer:Identity", "1, 1"),
//                    CreatedBy = table.Column<int>(type: "int", nullable: false),
//                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
//                    DisplayOrder = table.Column<string>(type: "nvarchar(max)", nullable: false),
//                    IsActive = table.Column<bool>(type: "bit", nullable: false),
//                    ItemId = table.Column<int>(type: "int", nullable: false),
//                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
//                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
//                    itemGroup = table.Column<string>(type: "nvarchar(max)", nullable: false)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_ItemGroup", x => x.Id);
//                });
//        }
//    }
//}
