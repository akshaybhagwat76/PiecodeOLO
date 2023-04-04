using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DishoutOLO.Repo.Migrations
{
    /// <inheritdoc />
    public partial class coupen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuAvailabilities_Menus_MenuId",
                table: "MenuAvailabilities");

            migrationBuilder.DropForeignKey(
                name: "FK_Menus_Programs_ProgramId",
                table: "Menus");

            migrationBuilder.DropIndex(
                name: "IX_Menus_ProgramId",
                table: "Menus");

            migrationBuilder.DropIndex(
                name: "IX_MenuAvailabilities_MenuId",
                table: "MenuAvailabilities");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Menus");

            migrationBuilder.RenameColumn(
                name: "utC_ToTime",
                table: "MenuAvailabilities",
                newName: "week");

            migrationBuilder.RenameColumn(
                name: "utC_FromTime",
                table: "MenuAvailabilities",
                newName: "fromtime");

            migrationBuilder.RenameColumn(
                name: "daysList",
                table: "MenuAvailabilities",
                newName: "endtime");

            migrationBuilder.AlterColumn<string>(
                name: "ProgramId",
                table: "Menus",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MenuId",
                table: "MenuAvailabilities",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "TaxRate4",
                table: "Items",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "TaxRate3",
                table: "Items",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "TaxRate2",
                table: "Items",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "TaxRate1",
                table: "Items",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ItemName",
                table: "Items",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Coupens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CouponName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CouponCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MinOrderAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RedemptionType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiscountTypePercentageval = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coupens", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Coupens");

            migrationBuilder.RenameColumn(
                name: "week",
                table: "MenuAvailabilities",
                newName: "utC_ToTime");

            migrationBuilder.RenameColumn(
                name: "fromtime",
                table: "MenuAvailabilities",
                newName: "utC_FromTime");

            migrationBuilder.RenameColumn(
                name: "endtime",
                table: "MenuAvailabilities",
                newName: "daysList");

            migrationBuilder.AlterColumn<int>(
                name: "ProgramId",
                table: "Menus",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Menus",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "MenuId",
                table: "MenuAvailabilities",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TaxRate4",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "TaxRate3",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "TaxRate2",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "TaxRate1",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "ItemName",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_ProgramId",
                table: "Menus",
                column: "ProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuAvailabilities_MenuId",
                table: "MenuAvailabilities",
                column: "MenuId");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuAvailabilities_Menus_MenuId",
                table: "MenuAvailabilities",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Menus_Programs_ProgramId",
                table: "Menus",
                column: "ProgramId",
                principalTable: "Programs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
