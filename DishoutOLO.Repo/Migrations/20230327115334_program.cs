using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DishoutOLO.Repo.Migrations
{
    /// <inheritdoc />
    public partial class program : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Menus",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ProgramId",
                table: "Menus",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "TaxRate4",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "TaxRate3",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "TaxRate2",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "TaxRate1",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ItemName",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

        //    migrationBuilder.CreateTable(
        //        name: "Programs",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            ProgramName = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //            IsActive = table.Column<bool>(type: "bit", nullable: false),
        //            CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
        //            CreatedBy = table.Column<int>(type: "int", nullable: true),
        //            ModifiedBy = table.Column<int>(type: "int", nullable: true),
        //            ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Programs", x => x.Id);
        //        });

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Menus_ProgramId",
        //        table: "Menus",
        //        column: "ProgramId");

        //    migrationBuilder.AddForeignKey(
        //        name: "FK_Menus_Programs_ProgramId",
        //        table: "Menus",
        //        column: "ProgramId",
        //        principalTable: "Programs",
        //        principalColumn: "Id",
        //        onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Menus_Programs_ProgramId",
                table: "Menus");

            migrationBuilder.DropTable(
                name: "Programs");

            migrationBuilder.DropIndex(
                name: "IX_Menus_ProgramId",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "ProgramId",
                table: "Menus");

            migrationBuilder.AlterColumn<string>(
                name: "TaxRate4",
                table: "Items",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TaxRate3",
                table: "Items",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TaxRate2",
                table: "Items",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TaxRate1",
                table: "Items",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
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
        }
    }
}
